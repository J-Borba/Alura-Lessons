namespace Curso_03_UsuariosAPI.Validation;

public class ValidationResult
{
    public List<string> ErrorMessages { get; }
    public bool IsValid => ErrorMessages.Count == 0;

    public ValidationResult()
    {
        ErrorMessages = [];
    }

    public void AddError(string errorMessage)
    {
        if (string.IsNullOrEmpty(errorMessage))
        {
            throw new ApplicationException("Error message cannot be null.");
        }
        else
        {
            ErrorMessages.Add(errorMessage);
        }
    }

    public void AddErrors(IEnumerable<string> errorMessages)
    {
        if (errorMessages.Any())
        {
            if (errorMessages.Any(string.IsNullOrEmpty))
            {
                throw new ApplicationException("All error messages must have a value.");
            }
            ErrorMessages.AddRange(errorMessages);
        }
    }
}