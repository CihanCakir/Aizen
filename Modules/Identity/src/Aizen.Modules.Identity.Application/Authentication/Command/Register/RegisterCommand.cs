using Aizen.Core.CQRS.Message;
using Aizen.Modules.Identity.Abstraction.Dto.Authentication;

namespace Aizen.Modules.Identity.Application.Authentication.Command
{
    public class RegisterCommand: AizenCommand<AizenLoginDto>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CountryCode { get; set; }
        public string? ReferenceCode { get; set; }
        public string? ReferenceMember { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public RegisterCommand(
                                        string? name,
                                        string? surname,
                                        string? username,
                                        string? email,
                                        string? phoneNumber,
                                        string? countryCode,
                                        string? referenceCode,
                                        string? referenceMember,
                                        string? gender,
                                        DateTime? birthDate)
                                            {
                                                Name = name;
                                                Surname = surname;
                                                Username = username;
                                                Email = email;
                                                PhoneNumber = phoneNumber;
                                                CountryCode = countryCode;
                                                ReferenceCode  = referenceCode;
                                                ReferenceMember = referenceMember;
                                                Gender = gender;
                                                BirthDate = birthDate;
                                            }
    }
}