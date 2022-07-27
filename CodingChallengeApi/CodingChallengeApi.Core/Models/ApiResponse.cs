using System.Net;

namespace CodingChallengeApi.Core.Models;
public class ApiResponse
{
    public object Data { get; set; }
    public HttpStatusCode Status { get; set; }
    public string Message { get; set; }
}
