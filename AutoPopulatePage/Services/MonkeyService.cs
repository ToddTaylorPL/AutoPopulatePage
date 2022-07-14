
using AutoPopulatePage.Models;

namespace AutoPopulatePage.Services;
public class MonkeyService
{
    HttpClient httpClient;
    public MonkeyService()
    {
        this.httpClient = new HttpClient();
    }

    List<Monkey> monkeyList;
    
    public async Task<List<Monkey>> GetMonkeysGH()
    {
        if (monkeyList?.Count > 0)
            return monkeyList;

        string url = "https://www.montemagno.com/monkeys.json";

        var response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        }

            return monkeyList;
    }

    public async Task<List<Monkey>> GetMonkeysDN(string monkeyName)
    {
        //string url;
        string url = "https://apitrackmate.azurewebsites.net/Monkeys?MonkeyName=" + monkeyName;
        
        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        }

        return monkeyList;
    }


}
