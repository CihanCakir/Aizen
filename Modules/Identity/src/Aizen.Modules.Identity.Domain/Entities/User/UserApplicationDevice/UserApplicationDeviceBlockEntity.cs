using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Domain;

namespace Aizen.Modules.Identity.Domain.Entities
{
    public class UserApplicationDeviceBlockEntity : AizenEntityWithAudit
    {
        public string DeviceName { get; set; }
        public string DeviceId { get; set; }
        public int? DeviceTypeId { get; set; }
        public string IpAddress { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public static UserApplicationDeviceBlockEntity CreateEntity(string deviceName, string deviceId, string ipAddress, int? deviceTypeId = null)
        {
            return new UserApplicationDeviceBlockEntity
            {
                DeviceName = deviceName,
                DeviceId = deviceId,
                IpAddress = ipAddress,
                DeviceTypeId = deviceTypeId,
                CreateDate = DateTime.Now,
                IsActive = true,
            };
        }

        public void ChangeActivity()
        {
            this.IsActive = !this.IsActive;
        }
    }
}