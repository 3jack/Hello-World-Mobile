using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class AuthResponse
    {
        public string access_token;
        public string token_type;
        public string username;
        public string role;
    }
    // "{\"username\":\"sysadmin\",\"roles\":[\"ROLE_ADMIN\"],\"token_type\":\"Bearer\",\"access_token\":\"eyJhbGciOiJIUzI1NiJ9.eyJwcmluY2lwYWwiOiJINHNJQUFBQUFBQUFBSlZTUDBcL2JRQlJcL0RrRWdrRnFvQkJJRExLUmI1VWp0MWt4QUFZRk1RRTJ6VUlucVlqXC9jZ1wvT2RlM2VHWkVHWllHQUE4VWRDN1ZmZ203UkxQMERWRGwyWnVcL0xPQVp4MlFiM0pmdmZ6NzlcL3o5UTBNR2cydllzMjRNSDRxc3BoTDM2U2F5OWhnbUdsdU8zNW1VRWRvYzhSeURtelNCSHJISzRFWFFJbEhGcDRGTzJ5UFZRV1RjWFc5dFlPaHJiVTF2RlE2dm1QYzFpekJmYVYzXC9RZnVVR244UzZDZzlqNlhZR2dUeGxrWXFremF1cEtMN1pScmpEWmhySmdGS3R4MW80bVFibEJhem9UcGh3NmhaQzJCVVFDakxMTWZGYWx5TkJhZTlzeG1sb3RxQTIwdGdPR1VHVVB1XC9rblNzTTY2dTNjMkpTWDRCQWRRYnFjZUhlcnV1WVA2anNkZlVFSlFhcTZrcVRSbG9pSyt6WjA0OFhlbno3NmZmT2syU3dEVXlZdkh2eW5tVVwvUFFcL2JyMVp5WXYyZ3N0VFBaWkwyQzFka3B1eGd2bWR4cWQ4bytyamZQTG02UDNBNlRzRUV2XC92NFwvSzNGMXpuUVdWcEV3enFcL3AyUkxUN1pmZE01UE9Qazk5dm9lTTNlSklLcEQ5S1dvd2VKQXBpaWx2V1N0ejNiV0hrN1hxdytHSHV6ZHBLM2IwT200NWhVY0lsQ1RcL0pjN3VGK1lHaWRSM1wvUHYxMk12dVRTRlpoY0krSkRLbjJzUUpVejVJVzZzUHJ5K25SaTFcL0hlWWllY09YMUxScHFqeG9VQXdBQSIsInN1YiI6InN5c2FkbWluIiwicm9sZXMiOlsiUk9MRV9BRE1JTiJdLCJleHAiOjE1NDM0ODU3MzQsImlhdCI6MTU0MzQ2NDEzNH0.7z9OvWWB8Wux6adD89LkqbVzU6vV2e9PxOKtvLCktKE\",\"expires_in\":21600,\"refresh_token\":\"eyJhbGciOiJIUzI1NiJ9.eyJwcmluY2lwYWwiOiJINHNJQUFBQUFBQUFBSlZTUDBcL2JRQlJcL0RrRWdrRnFvQkJJRExLUmI1VWp0MWt4QUFZRk1RRTJ6VUlucVlqXC9jZ1wvT2RlM2VHWkVHWllHQUE4VWRDN1ZmZ203UkxQMERWRGwyWnVcL0xPQVp4MlFiM0pmdmZ6NzlcL3o5UTBNR2cydllzMjRNSDRxc3BoTDM2U2F5OWhnbUdsdU8zNW1VRWRvYzhSeURtelNCSHJISzRFWFFJbEhGcDRGTzJ5UFZRV1RjWFc5dFlPaHJiVTF2RlE2dm1QYzFpekJmYVYzXC9RZnVVR244UzZDZzlqNlhZR2dUeGxrWXFremF1cEtMN1pScmpEWmhySmdGS3R4MW80bVFibEJhem9UcGh3NmhaQzJCVVFDakxMTWZGYWx5TkJhZTlzeG1sb3RxQTIwdGdPR1VHVVB1XC9rblNzTTY2dTNjMkpTWDRCQWRRYnFjZUhlcnV1WVA2anNkZlVFSlFhcTZrcVRSbG9pSyt6WjA0OFhlbno3NmZmT2syU3dEVXlZdkh2eW5tVVwvUFFcL2JyMVp5WXYyZ3N0VFBaWkwyQzFka3B1eGd2bWR4cWQ4bytyamZQTG02UDNBNlRzRUV2XC92NFwvSzNGMXpuUVdWcEV3enFcL3AyUkxUN1pmZE01UE9Qazk5dm9lTTNlSklLcEQ5S1dvd2VKQXBpaWx2V1N0ejNiV0hrN1hxdytHSHV6ZHBLM2IwT200NWhVY0lsQ1RcL0pjN3VGK1lHaWRSM1wvUHYxMk12dVRTRlpoY0krSkRLbjJzUUpVejVJVzZzUHJ5K25SaTFcL0hlWWllY09YMUxScHFqeG9VQXdBQSIsInN1YiI6InN5c2FkbWluIiwicm9sZXMiOlsiUk9MRV9BRE1JTiJdLCJpYXQiOjE1NDM0NjQxMzR9.PsIh49ORFs1vXHnS91M-1tsjpkyJP2p6wYreLtuzZus\"}"

    public partial class Login : ContentPage
    {

        private const string Url = "https://jsonplaceholder.typicode.com/posts";
        private string SERVER_URL = "http://192.168.1.112:8080";

        private HttpClient _client = new HttpClient();
        string sContentType = "application/json"; // or application/xml




        public Login()
        {
            InitializeComponent();
        }


        async public Task LoginServer()
        {
            string responseBodyAsText = "";
            string sUrl = SERVER_URL + "/MCF_backend/api/login";

            if (String.IsNullOrEmpty(entry_login.Text) || String.IsNullOrEmpty(entry_password.Text))
            {
                lbl_notification.Text = "Username or Password is not valid";
            }

            JObject oJsonObject = new JObject();
            oJsonObject.Add("username", entry_login.Text);
            oJsonObject.Add("password", entry_password.Text);

            try
            {
                HttpClient oHttpClient = new HttpClient();
                /*
                HttpResponseMessage response = await oHttpClient.PostAsync(sUrl, new StringContent(oJsonObject.ToString(), Encoding.UTF8, sContentType));

                System.Diagnostics.Debug.WriteLine(response.IsSuccessStatusCode);





              

                responseBodyAsText = await response.Content.ReadAsStringAsync();



                AuthResponse oAuth = JsonConvert.DeserializeObject<AuthResponse>(responseBodyAsText);


                UserSettings.username = oAuth.username;
                UserSettings.token_type = oAuth.token_type;
                UserSettings.access_token = oAuth.access_token;
                UserSettings.role = oAuth.role;

                responseBodyAsText = await response.Content.ReadAsStringAsync();

                System.Diagnostics.Debug.WriteLine(oAuth.access_token);
                System.Diagnostics.Debug.WriteLine(oAuth.username);
                */               

            }
            catch(HttpRequestException ae)
            {
                await DisplayAlert("HttpRequestException", ae.Message, "cancel");
            }
            catch (Exception ee)
            {
                UserSettings.username = "";
                UserSettings.token_type = "";
                UserSettings.access_token = "";
                UserSettings.role = "";

                System.Diagnostics.Debug.WriteLine(ee.Message);
                // await DisplayAlert("Exception", ee.Message, "cancel");
            }


            return;
        }


        async void Handle_Clicked_Login(object sender, System.EventArgs e)
        {
      
                        
                        
            try
            {
                await LoginServer();
            }
            catch(Exception ea)
            {
                await DisplayAlert("Exception", ea.Message, "cancel");
            }


            /*
            if (String.IsNullOrEmpty(test))
            {
                await DisplayAlert("title", " COULD NOT LOGIN: Button was pressed and continue to the next Page", "cancel");
            }
            else
            {
                await DisplayAlert("title", " Login complete: Button was pressed and continue to the next Page", "cancel");
            }
            */

            await Navigation.PushAsync(new MainPage());
        }



        async void Handle_Completed(object sender, System.EventArgs e)
        {
            await LoginServer();

            /*
            if (String.IsNullOrEmpty())
            {
                await DisplayAlert("title", " COULD NOT LOGIN: Return Key was pressed and continue to the next Page", "cancel");
            }
            else
            {
                await DisplayAlert("title", " Login complete: Return Key was pressed and continue to the next Page", "cancel");
            }
            */
            await Navigation.PushAsync(new MainPage());

        }

    }
}
