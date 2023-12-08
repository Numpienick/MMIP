using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Localization;
using MMIP.Client.Resources;

namespace MMIP.Client.Extensions
{
    public class CustomValidation
    {
        [Inject]
        private ISnackbar _snackbar { get; set; }

        [Inject]
        private IStringLocalizer<ApplicationResource> _localizer { get; set; }

        internal List<ValidationResult>? Validate(string value, string validationString, Type model)
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
                //_snackbar.Add(_localizer["SnackbarInvalid"], Severity.Error);
            }

            return results;
        }
    }
}
