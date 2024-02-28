using System.Text.Json.Serialization;

public class Status
{
    [JsonPropertyName("verified")]
    public bool Verified { get; set; }
    [JsonPropertyName("sentCount")]
    public int SentCount { get; set; }
}

public class CatFact
{
    [JsonPropertyName("status")]
    public Status Status { get; set; }

    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("user")]
    public string User { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("__v")]
    public long V { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTimeOffset UpdatedAt { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }

    [JsonPropertyName("used")]
    public bool Used { get; set; }
}