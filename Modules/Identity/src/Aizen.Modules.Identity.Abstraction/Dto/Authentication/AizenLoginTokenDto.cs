using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aizen.Modules.Identity.Abstraction.Dto.Authentication
{
    public class AizenLoginTokenDto
    {
        public long UserId { get; set; }
        public long ApplicationId { get; set; }
        public long TenantId { get; set; }
        public string DeviceId { get; set; }
        public string? Email { get; set; }
        public string? NationalityId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string NotificationToken { get; set; }
    }
}