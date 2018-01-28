using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XF.Atividade06.View
{
    public partial class ProfileView : ContentPage
    {
        public ProfileView(string message)
        {
            InitializeComponent();
            this.lblMessage.Text = message;
        }
    }
}
