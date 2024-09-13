using AdSetIntegrador.Exceptions.ExceptionsBase;

public class ErrorOnValidationException : AdSetIntegradorException
{
    public List<string> Errors { get; set; }

    public ErrorOnValidationException(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}