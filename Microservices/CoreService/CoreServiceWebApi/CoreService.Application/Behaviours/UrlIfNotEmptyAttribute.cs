using System.ComponentModel.DataAnnotations;

public class UrlIfNotEmptyAttribute : ValidationAttribute
{
    private readonly string _customErrorMessage;

    public UrlIfNotEmptyAttribute(string errorMessage = null)
    {
        _customErrorMessage = errorMessage;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var strValue = value as string;

        if (string.IsNullOrWhiteSpace(strValue))
            return ValidationResult.Success;

        if (Uri.TryCreate(strValue, UriKind.Absolute, out var uriResult) &&
            (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(_customErrorMessage ?? $"'{validationContext.MemberName}' is not a valid URL.");
    }
}