using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TELEFON
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EN : ContentPage
    {
        Editor ed;
        Label lb;
        public EN()
        {
            ed = new Editor
            {
                Placeholder = "текст",
                BackgroundColor = Color.White,
                TextColor = Color.Red
            };
            ed.TextChanged += Ed_TextChanged;
            lb = new Label
            {
                Text = "текст",
                TextColor = Color.Black
            };
            Button taga = new Button
            {
                Text = "обратно",
                BackgroundColor = Color.Salmon,
                TextColor = Color.Black
            };
            taga.Clicked += Taga_Clicked;
            StackLayout st = new StackLayout
            {
                Children = { ed, lb, taga }
            };
            st.BackgroundColor = Color.PeachPuff;
            Content = st;
        }
        int i = 0;
        int k = 0;

        private void Ed_TextChanged(object sender, TextChangedEventArgs e)
        {
            ed.TextChanged -= Ed_TextChanged;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';

            if (key == 'N')
            {
                i++;

            }
            else
            {
                k++;
            }
            lb.Text = "N: " + i + "\nLetters: " + k;
            ed.TextChanged += Ed_TextChanged;
        }




        private async void Taga_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }


    }




  
}