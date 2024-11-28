using Microsoft.Data.SqlClient;

namespace HackathonConsole;
internal class CopyService(Configuration configuration)
{
    private readonly Configuration configuration = configuration;

    public void CopyTable(string sourceTable, string destinationTable, SqlCommand? sqlCommand = null)
    {
        Console.WriteLine($"Copying data from ");

        using var sourceConnection = new SqlConnection(configuration.GetSourceConnectionString());
        using var destinationConnection = new SqlConnection(configuration.GetDestinationConnectionString());

        if (sqlCommand is null)
        {
            sqlCommand = new SqlCommand($"SELECT * FROM {sourceTable}", sourceConnection);
        }
        else
        {
            sqlCommand.Connection = sourceConnection;
        }
        sqlCommand.CommandTimeout = 0;
        
        sourceConnection.Open();
        destinationConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        
        using SqlBulkCopy bulkCopy = new(destinationConnection);
        var batchSize = 50000;
        bulkCopy.DestinationTableName = destinationTable;
        bulkCopy.NotifyAfter = batchSize;
        bulkCopy.SqlRowsCopied += (sender, e) => Console.WriteLine($"Copied {e.RowsCopied} rows.");
        bulkCopy.BatchSize = batchSize;
        bulkCopy.BulkCopyTimeout = 600;

        try
        {
            bulkCopy.WriteToServer(reader);
            Console.WriteLine($"Done writing rows to {destinationTable}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            reader.Close();
        }
    }
}
