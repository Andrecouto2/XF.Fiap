using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Atividade06.View;
using XF.Atividade06.ViewModel;

namespace XF.Atividade06
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XF_Atividade06Page : ContentPage
    {
        public XF_Atividade06Page()
        {
            InitializeComponent();

            BindingContext = new UsuarioViewModel();
        }

        protected override void OnAppearing()
        {
            txtUsuario.Text = pwdSenha.Text = string.Empty;
            base.OnAppearing();
        }    

        private async void btnLogar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginView() { BindingContext = App.UsuarioVM });
        }
    }
}
