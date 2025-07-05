namespace Aizen.Core.Api.Middleware;

public enum AizenErrorCode
{
    ApplicationNotFound = 100,
    AgeLimitExceeded = 101,
    AdultContentRestricted = 102,
    CountryNotAllowed = 103,
    PhoneAlreadyRegistered = 104,
    PhoneUsedInOtherApplication = 105,   
}

public class ErrorDescriptionModel
{
    public string Language { get; set; }
    public string Description { get; set; }
}

public class ErrorViewModel
{
    public int ErrorCode { get; set; }
    public List<ErrorDescriptionModel> Errors { get; set; }
}