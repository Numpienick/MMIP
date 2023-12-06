namespace MMIP.Environment
{
    public static class EnvironmentConstants
    {
        public static readonly string ApiUrl =
            System.Environment.GetEnvironmentVariable("API_URL") ?? "https://localhost:5238";

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
