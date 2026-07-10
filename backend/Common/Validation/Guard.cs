using Backend.Common.Exceptions;

namespace Backend.Common.Validation;

public static class Guard
{
    public static void PositiveId(int id, string resourceName)
    {
        if (id <= 0)
        {
            throw new BusinessValidationException($"El identificador de {resourceName} debe ser mayor que cero.");
        }
    }
}
