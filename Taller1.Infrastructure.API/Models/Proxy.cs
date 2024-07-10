using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Taller1.Infrastructure.API.Models
{
    public class RequestData
    {
        [Required][JsonProperty("num1", Order = 1)] public int? Num1 { get; set; }
        [Required][JsonProperty("num2", Order = 2)] public int? Num2 { get; set; }
    }

    public class ResponseData
    {
        [JsonProperty("message", Order = 1)] public string? Message { get; set; }
    }
}
