using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aizen.Modules.Identity.Abstraction.Enum
{
    public enum ApplicationPlatform
    {
        Android,
        IOS,
        Web
    }

    public enum ApplicationPlatformVersionAction
    {
        Updated,
        Publish,
        Revoke
    }
    public enum ApplicationPlatformType{
        Web,
        Mobil
    }
}