using System.ComponentModel.DataAnnotations;

namespace CustomerCRUD.Models.CustomValidators
{
    public class EmailDomainValidator : ValidationAttribute
    {
        public string AllowedDomain { get; set; }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            string[] strings = value.ToString().Split('@');
            //ver3
            if (strings.Length>1 && strings[1].ToUpper() == AllowedDomain.ToUpper())
            {
                return null;
            }

            return new ValidationResult(ErrorMessage,
            /*ver2
             if (strings[1].ToUpper() == AllowedDomain.ToUpper())
            {
                return null;
            }

            return new ValidationResult($"Domain must be {AllowedDomain}",*/
            /*//ver1
            if (strings[1].ToUpper() == "DNS.COM")
            {
                return null;
            }

            return new ValidationResult($"Domain must be DNS.COM",*/
            new[] { validationContext.MemberName });
        }
    }
}