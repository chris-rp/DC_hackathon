namespace HackathonConsole;
internal class Configuration
{
    public string Server { get; set; }
    public int Port { get; set; } = 1433;
    public string DestinationServer { get; set; }
    public int DestinationPort { get; set; } = 1433;
    public string Database { get; set; }
    public string DestinationDatabase { get; set; }
    public Credential? SqlCredential { get; set; }
    public Credential? DestinationSqlCredential { get; set; }
    public bool TrustServerCertificate { get; set; } = true;

    public string GetSourceConnectionString()
    {
        string credentialString = SqlCredential is null ? "" : $"User={SqlCredential.User};Password={SqlCredential.Password}";
        return $"""Server={Server},{Port};Database={Database};Integrated Security=True;TrustServerCertificate={TrustServerCertificate};{credentialString}""";
    }
    public string GetDestinationConnectionString()
    {
        string credentialString = DestinationSqlCredential is null ? "" : $"User={DestinationSqlCredential.User};Password={DestinationSqlCredential.Password}";
        return $"""Server={DestinationServer},{DestinationPort};Database={DestinationDatabase};TrustServerCertificate={TrustServerCertificate};{credentialString}""";
    }
}