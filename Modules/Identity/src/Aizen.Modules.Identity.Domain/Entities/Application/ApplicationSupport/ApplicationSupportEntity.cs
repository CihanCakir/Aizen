using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.Data.Mongo.Document;

namespace Aizen.Modules.Identity.Domain.Entities;

public class ApplicationSupportEntity : AizenDefinitionDocumentBase
{
    public string? TopicName { get; set; }
    public string? DefaultMessage { get; set; }
    public bool HasDefaultMessage { get; set; }
    public bool HasDefaultMessageFromResource { get; set; }


    public long ApplicationId { get; set; }
}