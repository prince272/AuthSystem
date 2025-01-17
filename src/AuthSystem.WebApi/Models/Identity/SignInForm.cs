using AutoMapper;
using FluentValidation;
using AuthSystem.WebApi.Data.Entities.Identity;
using AuthSystem.WebApi.Providers.ModelValidator;
using AuthSystem.WebApi.Providers.Validation;
using System.Text.Json.Serialization;

namespace AuthSystem.WebApi.Models.Identity
{
    public class SignInForm
    {
        public string Username { get; set; } = null!;

        [JsonIgnore]
        public ContactType UsernameType
        {
            get => !string.IsNullOrWhiteSpace(Username) ? ValidationHelper.DetermineContactType(Username) : default;
        }
        public string Password { get; set; } = null!;
    }

    public class SignInFormValidator : AbstractValidator<SignInForm>
    {
        public SignInFormValidator()
        {
            RuleFor(_ => _.Username).NotEmpty().WithName("Email or phone number").DependentRules(() =>
            {
                When(_ => _.UsernameType == ContactType.Email, () =>
                {
                    RuleFor(_ => _.Username).Email().WithName("Email");
                });

                When(_ => _.UsernameType == ContactType.PhoneNumber, () =>
                {
                    RuleFor(_ => _.Username).PhoneNumber().WithName("Phone number");
                });
            });
            RuleFor(_ => _.Password).NotEmpty().MaximumLength(256);
        }
    }

    public class SignInFormProfile : Profile
    {
        public SignInFormProfile()
        {
            CreateMap<SignInForm, User>()
                .ForMember(_ => _.UserName, _ => _.Ignore())
                .ForMember(_ => _.Email, _ => _.Ignore())
                .ForMember(_ => _.PhoneNumber, _ => _.Ignore());
        }
    }
}
