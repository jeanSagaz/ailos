using Questao2.Modelo;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year).Result;

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year).Result;

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static async Task<int> getTotalScoredGoals(string team, int year)
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        var response = await client.GetAsync($"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var footballMatches = JsonSerializer.Deserialize<FootballMatches>(result);

            return footballMatches?.Data != null ? footballMatches.Data.Sum(x => Convert.ToInt32(x.Team1goals)) : 0;
        }

        return 0;
    }

}