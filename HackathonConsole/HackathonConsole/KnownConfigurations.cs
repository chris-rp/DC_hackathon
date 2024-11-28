namespace HackathonConsole;
internal static class KnownConfigurations
{
    public static Configuration GetConfiguration(string configurationName)
    {
        return configurationName switch
        {
            "localhost" => new Configuration()
            {
                Server = "localhost",
                Port = 1433,
                DestinationServer = "localhost",
                DestinationPort = 1401,
                Database = "Playground",
                DestinationDatabase = "Hackathon",
                DestinationSqlCredential = new Credential()
                {
                    User = "sa",
                    Password = "P4ssword"
                }
            },
            "asgard.test" => new Configuration()
            {
                Server = "asgard.test.mssql.dac.local",
                DestinationServer = "localhost",
                DestinationPort = 1401,
                Database = "DSI_Applications",
                DestinationDatabase = "Hackathon",
                DestinationSqlCredential = new Credential()
                {
                    User = "sa",
                    Password = "P4ssword"
                }
            },
            _ => throw new ArgumentException($"Unknown configuration name: {configurationName}")
        };
    }
}