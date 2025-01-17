﻿using FluentValidation;
using AuthSystem.WebApi.Providers.ModelValidator;
using AuthSystem.WebApi.Providers.Validation;
using System.Text.Json.Serialization;

namespace AuthSystem.WebApi.Models.Identity
{
    public class SendChangeAccountCodeForm
    {
        [JsonIgnore]
        public ContactType NewUsernameType
        {
            get => !string.IsNullOrWhiteSpace(NewUsername) ? ValidationHelper.DetermineContactType(NewUsername) : default;
        }

        public string NewUsername { get; set; } = null!;
    }

    public class ChangeAccountForm
    {
        [JsonIgnore]
        public ContactType NewUsernameType
        {
            get => !string.IsNullOrWhiteSpace(NewUsername) ? ValidationHelper.DetermineContactType(NewUsername) : default;
        }

        public string NewUsername { get; set; } = null!;

        public string Code { get; set; } = null!;
    }

    public class SendChangeAccountCodeFormValidator : AbstractValidator<SendChangeAccountCodeForm>
    {
        public SendChangeAccountCodeFormValidator()
        {
            RuleFor(_ => _.NewUsername).NotEmpty().WithName("New email or phone number").DependentRules(() =>
            {
                When(_ => _.NewUsernameType == ContactType.Email, () =>
                {
                    RuleFor(_ => _.NewUsername).Email().WithName("New email");
                });

                When(_ => _.NewUsernameType == ContactType.PhoneNumber, () =>
                {
                    RuleFor(_ => _.NewUsername).PhoneNumber().WithName("New phone number");
                });
            });
        }
    }

    public class ChangeAccountFormValidator : AbstractValidator<ChangeAccountForm>
    {
        public ChangeAccountFormValidator()
        {
            RuleFor(_ => _.NewUsername).NotEmpty().WithName("New email or phone number").DependentRules(() =>
            {
                When(_ => _.NewUsernameType == ContactType.Email, () =>
                {
                    RuleFor(_ => _.NewUsername).Email().WithName("New email");
                });

                When(_ => _.NewUsernameType == ContactType.PhoneNumber, () =>
                {
                    RuleFor(_ => _.NewUsername).PhoneNumber().WithName("New phone number");
                });
            });

            RuleFor(_ => _.Code).NotEmpty();
        }
    }
}
