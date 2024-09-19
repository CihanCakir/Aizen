using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Modules.Identity.Abstraction.Dto.Authentication;

namespace Aizen.Modules.Identity.Core.Shared
{
    public interface IAizenIdentitySharedService
    {
        public Task<AizenLoginDto> CreateLoginToken(AizenLoginTokenDto request);
        public Task CheckDeviceHasBeenAproval(AizenLoginTokenDto request);
    }
}