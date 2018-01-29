using Xamarin.Forms;
using System.Threading.Tasks;
using XF.Atividade06.View;
using XF.Atividade06.ViewModel;

namespace XF.Atividade06
{
    public partial class App : Application
    {
        #region ViewModels
        public static UsuarioViewModel UsuarioVM { get; set; }
        #endregion

        public App()
        {
            InitializeComponent();
            InitializeApplication();

            MainPage = new NavigationPage(new XF_Atividade06Page() { BindingContext = UsuarioVM});
        }

        private void InitializeApplication()
        {
            if (UsuarioVM == null) UsuarioVM = new UsuarioViewModel();
        }

        public async static Task NavigateToProfile(string message)
        {
            await App.Current.MainPage.Navigation.PushAsync(new ProfileView(message));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
