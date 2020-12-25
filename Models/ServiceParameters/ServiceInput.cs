using FluentValidation;
using System.Text.Json.Serialization;

namespace Models.ServiceParameters
{
    public class ServiceInput
    {
        //[JsonIgnore]
        //public int CurrentUserId { get; set; }
    }

    public class ServiceInputValidator : AbstractValidator<ServiceInput>
    {
        public ServiceInputValidator() { }
    }
}
