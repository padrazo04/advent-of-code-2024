using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdventOfCode2024;

public static class Program
{
    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            PrintHelp();
            return;
        }

        int challengeDay = int.Parse(args[0]);

        if (challengeDay < 1 || challengeDay > 25)
        {
            PrintHelp();
            return;
        }

        string inputData = GetInputData(challengeDay).Result;

        switch (challengeDay)
        {
            case 1:
                Day1.Run(inputData);
                break;
            default:
                Console.WriteLine($"Challenge day {challengeDay} hasn't been implemented yet!");
                break;
        }

    }

    private static void PrintHelp()
    {
        Console.WriteLine("Error. This program receives exactly one number from 1 to 25 as argument. Usage: <dotnet run -- day>");
        Console.WriteLine("Usage example:\n- dotnet run -- 1\n- dotnet run -- 24");
    }


    private static async Task<string> GetInputData(int challengeDay)
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
