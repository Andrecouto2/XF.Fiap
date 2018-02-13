using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Atividade06.ViewModel;

namespace XF.Atividade06.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AtividadeView : ContentPage
    {
        public AtividadeView()
        {
            BindingContext = AtividadeViewModel.Instancia;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lstAtividades.IsRefreshing = !lstAtividades.IsRefreshing;
            await AtividadeViewModel.Instancia.Carregar();
            lstAtividades.IsRefreshing = !lstAtividades.IsRefreshing;
        }
    }
}
