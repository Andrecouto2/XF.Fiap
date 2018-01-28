using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.App;
using Xamarin.Auth;
using Newtonsoft.Json.Linq;
using XF.Atividade06.Droid;
using XF.Atividade06.View;
using XF.Atividade06;

[assembly: ExportRenderer(typeof(LoginView), typeof(FBLoginPageRenderer))]

namespace XF.Atividade06.Droid
{
    public class FBLoginPageRenderer : PageRenderer
    {
        public FBLoginPageRenderer(){

            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: "404133236711014",
                scope: "",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

            auth.Completed += async (sender, e) => {
                if (e.IsAuthenticated)
                {
                    var accessToken = e.Account.Properties["access_token"].ToString();
                    var expiresIn = Convert.ToDouble(e.Account.Properties["expires_in"]);
                    var expiryDate = DateTime.Now + TimeSpan.FromSeconds(expiresIn);

                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, e.Account);
                    var response = await request.GetResponseAsync();
                    var obj = JObject.Parse(response.GetResponseText());

                    var id = obj["id"].ToString().Replace("\"", "");
                    var name = obj["name"].ToString().Replace("\"", "");

                    await App.NavigateToProfile(string.Format("Olá {0}, seja bem-vindo", name));
                }
                else
                {
                    await App.NavigateToProfile("O usuário cancelou o login");
                }
            };
            activity.StartActivity(auth.GetUI(activity));
        }
    }
}
