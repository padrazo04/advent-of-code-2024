using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdventOfCode2024;

public static class InputData
{
    public static async Task<string> Get(int challengeDay)
    {
        HttpClient httpClient = new HttpClient();

        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://adventofcode.com/2024/day/{challengeDay}/input")
        };

        request.Headers.Add("Cookie", "session=YOUR_SESSION_COOKIE");
        HttpResponseMessage response = httpClient.Send(request);
        return await response.Content.ReadAsStringAsync();
    }
}
