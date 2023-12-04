namespace Environment
{
    public static class EnvironmentConstants
    {
        public static readonly string ApiUrl =
            System.Environment.GetEnvironmentVariable("API_URL") ?? "https://localhost:5238";

        public static readonly string DatabaseConnectionString =
            System.Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING")
            ?? "Host=localhost;Port=5432;Database=postgres;Username=mmip;Password=mmip123";

        public const Env Staging = Env.Staging;
        public const Env Development = Env.Development;
        public const Env Production = Env.Production;

        public enum Env
        {
            Development,
            Staging,
            Production
        }

        public static Env Environment
        {
            get
            {
                var environment = System.Environment.GetEnvironmentVariable(
                    "ASPNETCORE_ENVIRONMENT"
                );
                return environment switch
                {
                    "Development" => Env.Development,
                    "Staging" => Env.Staging,
                    "Production" => Env.Production,
                    _ => Env.Production
                };
            }
        }
    }
}
