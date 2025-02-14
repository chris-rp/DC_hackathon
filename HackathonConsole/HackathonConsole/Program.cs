using HackathonConsole;
using Microsoft.Data.SqlClient;

// See https://docs.dbatools.io/Copy-DbaDbTableData.html
// For inspiration on different features the C# code could have

var config = KnownConfigurations.GetConfiguration("asgard.test");

// Read sql SSIS_test1.sql from file in this directory
string sql = File.ReadAllText("SSIS_test1.sql");

var copyService = new Service(config);

try
{
	// E.g. start job in database
	copyService.CopyTable(null, "[hack].[BusinessControlling_ConsolidatedRealised]", new SqlCommand(sql));
	// E.g. finish job in database
}
catch (Exception)
{
    // In case of error send alert to Fury, send message to teams, slack, etc.
}