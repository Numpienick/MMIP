using System.Diagnostics;
using Npgsql;

namespace MMIP.Test.Infrastructure
{
    internal static class DatabaseContainerController
    {
        private const int MaxRetryCount = 10;
        private const int RetryDelay = 200;

        public static void InitializeDockerContainer()
        {
            DisposeDockerContainer();
            using var process = new Process();
            process.StartInfo.WorkingDirectory = GetProjectDirectory();
            process.StartInfo.FileName = "docker";
            process.StartInfo.Arguments = "compose up -d";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();

            process.WaitForExit();
        }

        public static void DisposeDockerContainer()
        {
            using var process = new Process();
            process.StartInfo.WorkingDirectory = GetProjectDirectory();
            process.StartInfo.FileName = "docker";
            process.StartInfo.Arguments = "compose down -v";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();

            process.WaitForExit();
        }

        private static string GetProjectDirectory()
        {
            var workingDirectory = Directory.GetCurrentDirectory();
            var projectRoot = GetProjectRoot(workingDirectory);

            return Path.Combine(projectRoot, "MMIP.Test.Infrastructure");
        }

        private static string GetProjectRoot(string workingDirectory)
        {
            while (true)
            {
                var projectRoot = Directory.GetParent(workingDirectory);
                if (projectRoot is { Name: "src" })
                    return projectRoot.FullName;
                workingDirectory =
                    projectRoot?.FullName
                    ?? throw new DirectoryNotFoundException("Project root directory not found");
            }
        }

        public static bool CanConnectToContainer(string connectionString, int retryCount = 0)
        {
            var connection = new NpgsqlConnection(connectionString);
            bool failed = false;
            try
            {
                connection.Open();
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e);
                failed = true;
            }

            bool canConnect = !failed && connection.State == System.Data.ConnectionState.Open;
            if (canConnect || retryCount >= MaxRetryCount)
            {
                connection.Close();
                return canConnect;
            }

            Task.Delay(RetryDelay).Wait();
            return CanConnectToContainer(connectionString, ++retryCount);
        }
    }
}
