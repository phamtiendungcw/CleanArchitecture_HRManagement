namespace HR.Management.Application.Contracts.Logging
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);

        void LogWaring(string message, params object[] args);
    }
}