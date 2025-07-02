namespace Aizen.Core.Api.Middleware;

public enum AizenErrorCode
{
   CurrentDeviceHasBeenLockup= 1
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