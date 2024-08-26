using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities;
public class UserApplicationPackageEntity : AizenEntityWithAudit
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public long PackageId { get; set; }
    public ApplicationPackageEntity? Package { get; set; }
    public long ApplicationId { get; set; }
    public ApplicationEntity? Application { get; set; }
    public long ProfileId { get; set; }
    public UserApplicationProfileEntity? Profile { get; set; }
}