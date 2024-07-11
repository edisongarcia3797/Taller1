using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Taller1.Infrastructure.API.Models
{
    public class RequestTwoNumbersInteger
    {
        [Required][JsonProperty("num1", Order = 1)] public int? Num1 { get; set; }
        [Required][JsonProperty("num2", Order = 2)] public int? Num2 { get; set; }
    }

    public class RequestTwoNumbersComplex : RequestTwoNumbersInteger
    {
        [Required][JsonProperty("imaginary1", Order = 1)] public int? Imaginary1 { get; set; }
        [Required][JsonProperty("imaginary2", Order = 2)] public int? Imaginary2 { get; set; }
    }

    public class ResponseData
    {
        [JsonProperty("message", Order = 1)] public string? Message { get; set; }
    }
}
