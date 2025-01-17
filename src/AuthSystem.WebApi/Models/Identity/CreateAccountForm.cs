﻿using AutoMapper;
using FluentValidation;
using AuthSystem.WebApi.Data.Entities.Identity;
using AuthSystem.WebApi.Providers.ModelValidator;
using AuthSystem.WebApi.Providers.Validation;
using System.Text.Json.Serialization;

namespace AuthSystem.WebApi.Models.Identity
{
    public class CreateAccountForm
    {
        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string Username { get; set; } = null!;

        [JsonIgnore]
        public ContactType UsernameType
        {
            get => !string.IsNullOrWhiteSpace(Username) ? ValidationHelper.DetermineContactType(Username) : default;
        }

        public string Password { get; set; } = null!;
    }

    public class CreateAccountFormValidator : AbstractValidator<CreateAccountForm>
    {
        public CreateAccountFormValidator()
        {
            RuleFor(_ => _.FirstName).NotEmpty().MaximumLength(256);
            RuleFor(_ => _.LastName).MaximumLength(256);
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
            RuleFor(_ => _.Password).NotEmpty().Password();
        }
    }

    public class CreateAccountFormProfile : Profile
    {
        public CreateAccountFormProfile()
        {
            CreateMap<CreateAccountForm, User>()
                .ForMember(_ => _.UserName, _ => _.Ignore())
                .ForMember(_ => _.Email, _ => _.Ignore())
                .ForMember(_ => _.PhoneNumber, _ => _.Ignore());
        }
    }
}
