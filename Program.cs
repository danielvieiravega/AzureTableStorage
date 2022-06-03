using Azure;
using Azure.Data.Tables;
using System.Text.Json;

var connectionString = @"DefaultEndpointsProtocol=https;AccountName=tablestoragevega01;AccountKey=rOKCoWVrYeHpXRDQfVCYz0Wa8XOoA2+ycwCCJsQHEEjP6ICXRQ3GqJb3hiOv4pxFDHXuCmLjdKD7+AStBwDpsA==;EndpointSuffix=core.windows.net";
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