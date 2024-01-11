using Newtonsoft.Json;
using System.Text;

namespace OBilet.Common.ApiHelpers
{
    public class ApiProcess
    {
        public static async Task<ResponseModel> PostMetod<ReguestModel, ResponseModel>(string URL, ReguestModel requestModel, string? token = null) where ReguestModel : class where ResponseModel : class
        {
            ResponseModel reservationList;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    if (!string.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);

                    StringContent content = new StringContent(JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json");

                    string json = JsonConvert.SerializeObject(requestModel, Formatting.Indented);

                    var responsenew = await httpClient.PostAsync(URL, content);
                    string apiResponse = await responsenew.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<ResponseModel>(apiResponse);
                }
                catch (Exception ex)
                {
                    reservationList = null;
                    string error = ex.StackTrace;
                }
            }
            return reservationList;
        }
        public static async Task<ResponseModel> GetMetod<ResponseModel>(string URL, string? token = null) where ResponseModel : class
        {
            ResponseModel reservationList;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    if (!string.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);

                    using (var responsenew = Task.Run(async () => await httpClient.GetAsync(URL)).Result)
                    {
                        string apiResponse = await responsenew.Content.ReadAsStringAsync();
                        reservationList = JsonConvert.DeserializeObject<ResponseModel>(apiResponse);
                    }
                }
                catch (Exception ex)
                {
                    reservationList = null;
                    string error = ex.StackTrace;
                }
            }
            return reservationList;
        }
        public static async Task<ResponseModel> DeleteMetod<ResponseModel>(string URL, int requestModel, string? token) where ResponseModel : class
        {
            ResponseModel reservationList;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    if (!string.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
                    using (var responsenew = Task.Run(async () => await httpClient.DeleteAsync($"{URL}?id={requestModel}")).Result)
                    {
                        string apiResponse = await responsenew.Content.ReadAsStringAsync();
                        reservationList = JsonConvert.DeserializeObject<ResponseModel>(apiResponse);
                    }
                }
                catch (Exception ex)
                {
                    reservationList = null;
                    string error = ex.StackTrace;
                }
            }
            return reservationList;
        }
        public static async Task<ResponseModel> PutMetod<RequestModel, ResponseModel>(string URL, RequestModel requestModel, string? token = null) where RequestModel : class where ResponseModel : class
        {
            ResponseModel responseModel;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    if (!string.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);

                    StringContent content = new StringContent(JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync(URL, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            responseModel = JsonConvert.DeserializeObject<ResponseModel>(apiResponse);
                        }
                        else
                        {
                            // Handle the error here, for example:
                            responseModel = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    responseModel = null;
                    string error = ex.StackTrace;
                }
            }
            return responseModel;
        }
    }
}
