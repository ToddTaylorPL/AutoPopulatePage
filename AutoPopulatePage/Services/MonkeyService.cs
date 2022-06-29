
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
    public async Task<List<Monkey>> GetMonkeys(string name)
    {
        if (monkeyList?.Count > 0)
            return monkeyList;

        // Online
        var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
        if (response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        }

        // Since the above Web Service does not accept paramters this is to simulate passing / filtering on a parameter.
       // if (name is null)
            return monkeyList;
        //else
        //return monkeyList.FindAll(x => x.Name == name);
    }
    public async Task<List<Monkey>> GetMonkeys2(string monkeyName)
    {
        string url;

        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
        {
            url = "http://10.0.2.2:45456/Monkey?MonkeyName=" + monkeyName;
        }
        else
        {
            url = "https://192.168.1.66:45456/Monkey?MonkeyName=" + monkeyName;
        }

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        }

        return monkeyList;
    }


}
