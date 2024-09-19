using Aizen.Core.CQRS.Handler;
using Aizen.Core.CQRS.Message;
using Aizen.Core.UnitOfWork.Abstraction;
using Aizen.Modules.DataStore.Domain.Wallet;
using Aizen.Modules.DataStore.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Aizen.Modules.DataStore.Application.Benefit
{
    public class CancelEarnedBenefitCommandHandler : AizenCommandHandler<CancelEarnedBenefitCommand, AizenCommandResult>
    {
        private readonly IAizenUnitOfWork<DataStoreDbContext> _unitOfWork;

        public CancelEarnedBenefitCommandHandler(IAizenUnitOfWork<DataStoreDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<AizenCommandResult?> Handle(CancelEarnedBenefitCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.GetRepository<WalletEntity>().FirstOrDefaultAsync(
                 predicate: p => p.CardNo == request.CardNumber && p.Id == request.WalletId,
                          include: p => p.Include(x => x.Orders.Where(order => (order.Status == Status.Active || order.Status == Status.Used) && order.CreateDate >= DateTime.Now.AddDays(-180)))
                                                  .ThenInclude(x => x.EarnedBenefits.Where(h=> h.IsDeleted == false))
                                                  
                                    .Include(x=> x.Transactions)                                                                
               );

            entity.CancelEarnedBenefit(request.OrderId, request.EarnedBenefitId);
            _unitOfWork.GetRepository<WalletEntity>().Update(entity);

                        await _unitOfWork.SaveChangesAsync();

            return new AizenCommandResult(isSuccess: true);
        }
    }

}