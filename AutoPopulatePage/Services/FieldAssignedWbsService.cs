
namespace AutoPopulatePage.Services
{
    public class FieldAssignedWbsService
    {
        HttpClient httpClient;
        public FieldAssignedWbsService()
        {
            httpClient = new HttpClient();
        }

        List<FieldAssignedWbs> fieldAssignedWbsList = new();

        public async Task<List<FieldAssignedWbs>> GetFieldAssignedWbsList(int userId)
        {
            string url;
            
            if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                url = "http://10.0.2.2:45456/FieldAssignedWbs?UserId=" + userId;
            }
            else
            {
                url = "https://192.168.1.66:45456/FieldAssignedWbs?UserId=" + userId;
            }

            var response = await httpClient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                fieldAssignedWbsList = await response.Content.ReadFromJsonAsync<List<FieldAssignedWbs>>();
            }

            return fieldAssignedWbsList;
        }

    }
}
