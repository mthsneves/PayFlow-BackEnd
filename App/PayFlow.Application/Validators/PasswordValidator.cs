namespace PayFlow.Application.Validators;

public class PasswordValidator
{

    public static (bool IsValid, List<string> Errors) Validate(string password)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(password))
        {
            errors.Add("A senha não pode ser vazia.");
            return (false, errors);
        }
        
        if(password.Length < 8)
            errors.Add("A senha deve conter no mínimo 8 caracteres.");
        
        if(!password.Any(char.IsUpper))
            errors.Add("A senha deve conter ao menos uma letra maiúscula.");
        
        if(!password.Any(char.IsLower))
            errors.Add("A senha deve conter ao menos uma letra minúscula.");
        
        if(!password.Any(char.IsDigit))
            errors.Add("A senha deve conter ao menos um número.");
        
        if(!password.Any(c => !char.IsLetterOrDigit(c)))
            errors.Add("A senha deve conter ao menos um caractere especial.");
        
        return (errors.Count == 0, errors);
    }
}