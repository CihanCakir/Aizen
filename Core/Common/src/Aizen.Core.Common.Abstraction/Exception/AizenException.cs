using NLocalizator;

namespace Aizen.Core.Common.Abstraction.Exception;

public class AizenException : System.Exception, ILocalizationBook
{
    public int ErrorCode { get; set; }
    public bool IsRollback { get; set; } = true;

    public AizenException(int errorCode)
    {
        ErrorCode = errorCode;
    }

    public AizenException(string message) : base(message)
    {
        ErrorCode = 9999;
    }
}