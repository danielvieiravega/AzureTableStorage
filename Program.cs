using Azure;
using Azure.Data.Tables;
using System.Text.Json;

var connectionString = @"DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1";
var tableName = "progresstable";

try
{
    var tableClient = new TableClient(connectionString, tableName);

    var progress1 = new Progress("meublob_" + DateTime.Now.ToString())
    {
        FinishDate = DateTime.UtcNow.AddMinutes(10)
    };

    await tableClient.AddEntityAsync(progress1);

    var createdEntity = await tableClient.GetEntityAsync<Progress>(progress1.PartitionKey, progress1.RowKey);

    Console.WriteLine(JsonSerializer.Serialize(createdEntity, new JsonSerializerOptions { WriteIndented = true }));

    Console.ReadLine();
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
    throw;
}

public enum Status
{
    Processing = 0,
    Failed = 1,
    Finished = 2
}

public class Progress : ITableEntity
{
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }
    public string BlobPath { get; set; }
    public int ItemsCount { get; set; }
    public int FailedItems { get; set; }
    public Status Status { get; set; }
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    public Progress()
    {

    }

    public Progress(string blobPath)
    {
        RowKey = Guid.NewGuid().ToString();
        PartitionKey = nameof(Progress);
        StartDate = DateTime.UtcNow;

        BlobPath = blobPath;
    }
}