using HackathonConsole;
using Microsoft.Data.SqlClient;

// See https://docs.dbatools.io/Copy-DbaDbTableData.html
// For inspiration on different features the C# code could have

Case1();

void Case1()
{
    var config = KnownConfigurations.GetConfiguration("asgard.test");

    // Read sql SSIS_test1.sql from file in this directory
    string sql = File.ReadAllText("SSIS_test1.sql");

    var copyService = new CopyService(config);
    copyService.CopyTable(null, "[hack].[BusinessControlling_ConsolidatedRealised]", new SqlCommand(sql));
}