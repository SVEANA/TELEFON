using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TELEFON
{
    public partial class MainPage : ContentPage
    {
        private Button list;
        public MainPage()
        {
            
            //InitializeComponent();
            StackLayout st = new StackLayout();
            Button b = new Button()
            {
                Text = "начало",
                BackgroundColor = Color.Green
            };

            Button list = new Button()
            {
                Text = "ТЕЛЕФОНЫ",
                BackgroundColor = Color.SandyBrown
            };
            Button ajabtn = new Button()
            {
                Text = "План",
                BackgroundColor = Color.LightPink
            };
            Button ev = new Button()
            {
                Text = "Европа",
                BackgroundColor = Color.Chocolate

            };

            ajabtn.Clicked += Ajabtn_Clicked;
            list.Clicked += List_Clicked1;
            ev.Clicked += Ev_Clicked;

            st.Children.Add(list);
            st.Children.Add(ajabtn);
            st.Children.Add(ev);
            st.BackgroundColor = Color.Cornsilk;


            Content = st;
            b.Clicked += B_Clicked;


        }

        private async void Ev_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Euro_Page());
        }

        private async void B_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EN());
        }

        private async void Ajabtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Ajapl());

        }

        private async void List_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new List_Page());
        }

        
    }
}
