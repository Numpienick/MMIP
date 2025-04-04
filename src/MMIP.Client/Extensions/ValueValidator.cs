﻿using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Localization;
using MMIP.Client.Resources;
using MMIP.Shared.Entities;

namespace MMIP.Client.Extensions
{
    internal class ValueValidator
    {
        private readonly ISnackbar _snackbar;
        private readonly IStringLocalizer<ApplicationResource> _localizer;

        public ValueValidator(ISnackbar snackbar, IStringLocalizer<ApplicationResource> localizer)
        {
            _snackbar = snackbar;
            _localizer = localizer;
        }

        internal List<ValidationResult> Validate(string value, string validationString, Type model)
        {
            var context = new ValidationContext(value, null, null);
            var results = new List<ValidationResult>();
            var attributes = model
                .GetProperty(validationString)
                .GetCustomAttributes(false)
                .OfType<ValidationAttribute>()
                .ToArray();

            bool isValid = Validator.TryValidateValue(value, context, results, attributes);
            if (!isValid)
            {
                _snackbar.Add(_localizer["SnackbarInvalid"], Severity.Error);
            }

            return results;
        }
    }
}
