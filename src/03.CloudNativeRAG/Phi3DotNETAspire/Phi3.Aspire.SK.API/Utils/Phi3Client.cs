using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

using Phi3.Aspire.SK.API.Domains;


namespace Phi3.Aspire.SK.API.Utils
{
    public class Phi3Client(HttpClient httpClient)
    {
        

        public async Task<string> GetChatCompetions(string question)
        {
            

            // var jsonObj = JsonSerializer.Serialize(prompt);

            using StringContent jsonContent = new StringContent("{\"inputs\": \"" + question + "\"}", Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await httpClient.PostAsync(
                "/v1/chat/completions/models/phi3-mini",
                jsonContent);

            // response.EnsureSuccessStatusCode().WriteRequestToConsole();

            var responseContent = await response.Content.ReadAsStringAsync();

             var result = JsonSerializer.Deserialize<IList<GenText>>(responseContent)!;

            return result[0].generated_text;

            

            // string url = "https+http://phi3service/v1/chat/completions/models/phi3-mini";

            // var client = new HttpClient();

            // var httpRequest = new HttpRequestMessage(HttpMethod.Post, url){
            //     Content = new StringContent("{\"inputs\": \"" + question + "\"}", System.Text.Encoding.UTF8, "application/json")
            // };

            // var response = await client.SendAsync(httpRequest);

            // if (response.IsSuccessStatusCode)
            // {
            //     var responseContent = await response.Content.ReadAsStringAsync();
            //     var result = JsonSerializer.Deserialize<IList<GenText>>(responseContent)!;
            //     return result[0].generated_text;
            // }
            // else
            // {
            //     return "";
            // }
        }
    }
}