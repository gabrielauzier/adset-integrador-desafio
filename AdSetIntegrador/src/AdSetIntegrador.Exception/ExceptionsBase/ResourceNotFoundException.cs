using AdSetIntegrador.Exceptions.ExceptionsBase;

public class ResourceNotFoundException : AdSetIntegradorException {
    public string Error { get; set; }

    public ResourceNotFoundException(string errorMessage)
    {
        Error = errorMessage;
    }
}
