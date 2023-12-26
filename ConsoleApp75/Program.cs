using ConsoleApp75.Models;
using Newtonsoft.Json.Linq;

List<VCard> vcards = new();
string fileName = "vcards.json";
string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

using (HttpClient client = new HttpClient())
{
    string url = "https://randomuser.me/api?results=50&authuser=0";
    var result = await client.GetAsync(url);
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

foreach (var vcard in vcards)
{
    var vcardString = vcard.ToVCard();
    File.AppendAllText(filePath, vcardString);
}


