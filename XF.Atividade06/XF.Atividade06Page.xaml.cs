using System;
using Xamarin.Forms;
using XF.Atividade06.View;

namespace XF.Atividade06
{
    public partial class XF_Atividade06Page : ContentPage
    {
        public XF_Atividade06Page()
        {
            InitializeComponent();
        }

        private async void btnLogar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginView());
        }
    }
}
