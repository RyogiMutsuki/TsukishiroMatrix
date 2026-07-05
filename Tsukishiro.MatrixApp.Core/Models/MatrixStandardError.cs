using System.Text.Json.Serialization;

namespace Tsukishiro.MatrixApp.Core.Models;

public record MatrixStandardError
{
    [JsonPropertyName("errcode")] 
    public string? ErrorCode { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }
}