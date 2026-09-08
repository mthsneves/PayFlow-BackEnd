using System.Net.Mail;

namespace PayFlow.Application.Validators
{
    public static class EmailValidator
    {
        public static (bool IsValid, List<string> Errors) Validate(string email)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(email))
            {
                errors.Add("O e-mail não pode ser vazio.");
                return (false, errors);
            }

            if (email.Length > 254)
                errors.Add("O e-mail excede o tamanho máximo permitido.");

            try
            {
                var address = new MailAddress(email);
                if (address.Address != email.Trim())
                    errors.Add("Formato de e-mail inválido.");
            }
            catch (FormatException)
            {
                errors.Add("Formato de e-mail inválido.");
            }

            return (errors.Count == 0, errors);
        }
    }
}