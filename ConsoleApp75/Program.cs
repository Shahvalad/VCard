using ConsoleApp75.Models;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;

List<VCard> vcards = new();
string filePath = "C:\\Users\\Шахвалад\\source\\repos\\ConsoleApp75\\ConsoleApp75\\vcards.json";

using (HttpClient client = new HttpClient())
{
    string url = "https://randomuser.me/api?results=50&authuser=0";
    var result = await client.GetAsync(url);

    if (result.IsSuccessStatusCode)
    {
        string json = await result.Content.ReadAsStringAsync();

        JObject data = JObject.Parse(json);
        JArray resultsArray = (JArray)data["results"];
        foreach (var resultItem in resultsArray)
        {
            vcards.Add(new VCard
            {
                Id = resultItem["id"]["value"].ToString(),
                Firstname = resultItem["name"]["first"].ToString(),
                Surname = resultItem["name"]["last"].ToString(),
                Email = resultItem["email"].ToString(),
                Phone = resultItem["phone"].ToString(),
                Country = resultItem["location"]["country"].ToString(),
                City = resultItem["location"]["city"].ToString()
            });
        }
    }
    else
    {
        Console.WriteLine($"Error: {result.StatusCode}");
    }
}

foreach (var vcard in vcards)
{
    var vcardString = vcard.ToVCard();
    WriteToJson<string>(vcardString, filePath);
}

void WriteToJson<T>(T data, string filePath)
{
    string json = JsonSerializer.Serialize(data);
    File.AppendAllText(filePath, json + Environment.NewLine);
}
