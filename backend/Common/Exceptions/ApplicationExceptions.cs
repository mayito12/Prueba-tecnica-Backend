namespace Backend.Common.Exceptions;

public sealed class NotFoundException(string message) : Exception(message);

public sealed class BusinessValidationException(string message) : Exception(message);

public sealed class ConflictException(string message) : Exception(message);

public sealed class RepositoryException(string message, Exception innerException)
    : Exception(message, innerException);

public sealed class ServiceException(string message, Exception innerException)
    : Exception(message, innerException);
