namespace ProductManagement.Domain.Exceptions
{
    internal class ProductManagementException : Exception
    {
        public ProductManagementException()
        { }

        public ProductManagementException(string message)
            : base(message)
        { }

        public ProductManagementException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
