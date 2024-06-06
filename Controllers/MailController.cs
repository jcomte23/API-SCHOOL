using System.Text.Json;
using api_school.Models.ApiMail;



namespace api_school.Controllers
{
    public class MailController
    {


        // static async Task ProcessRepositoriesAsync(HttpClient client)
        // {

        // }
        public async void SendEmail()
        {


            string url = "https://api.mailersend.com/v1/email";
            string jwt = "mlsn.a2c2838ce205143a7dfcd3253d97e4eefc7fe20489c1ae4edfcbb220a284de47";

            var emailMessage = new Email
            {
                From = new From { Email = "jcomte23@trial-3z0vklozo2747qrx.mlsender.net" },
                To = new[] {
                        new To { Email = "javiercombita2014@gmail.com" }
                    },
                Subject = "Test",
                Text = "Test",
                Html = "Test"
            };







            // var jsonBody = JsonSerializer.Serialize(emailMessage);


            // HttpClient client = new HttpClient();



            // client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            // client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");

            // StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            // HttpResponseMessage response = await client.PostAsync(url, content);

            // if (response.IsSuccessStatusCode)
            // {
            //     string responseBody = await response.Content.ReadAsStringAsync();

            // }
            // else
            // {
            //     Console.WriteLine(response.StatusCode);

            // }




        }
    }
}