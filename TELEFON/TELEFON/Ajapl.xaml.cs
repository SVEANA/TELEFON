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
    public partial class Ajapl : ContentPage
    {
        Label imja;
        TimePicker vrem;
        Image kar;
        Grid grid2x1;
        string[] kom = new string[] { "ОТЛИЧНО!" , "ВПЕРЕД!" , "УРА!" };
        
        public Ajapl()
        {
             grid2x1 = new Grid
             {
                 VerticalOptions = LayoutOptions.FillAndExpand,
                 BackgroundColor = Color.DarkBlue,
                 RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                 ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                }
             };
            vrem = new TimePicker { };
            vrem.PropertyChanged += Vrem_PropertyChanged;
            imja = new Label
            {
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 30
            };
            kar = new Image
            {
                Source = "gl.jpg"
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.NumberOfTapsRequired = 1;
            kar.GestureRecognizers.Add(tap);

            StackLayout verx2 = new StackLayout
            {
                Children = { vrem, imja },
            };
            grid2x1.Children.Add(verx2, 0, 0);
            grid2x1.Children.Add(kar, 0, 1);
            Content = grid2x1;


        }

        private async void Tap_Tapped(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Поддержать", "Да", "Нет", "OK");
            if (answer == true)
            {
                
            }
            else
            {

            }
        }

        private void Vrem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var time = vrem.Time.Hours;
            if (time >= 0 && time < 2)
            {
                imja.Text = "Ночь, спать!";
                kar.Source = ".jpg";
            }
            else if (time == 2)
            {
                imja.Text = "ночь!";
                kar.Source = "noh.jpg";
                
            }
            else if (time >= 4 && time < 6)
            {
                imja.Text = "утро!";
                kar.Source = "im.jpg";
            }
            else if (time >= 6 && time < 7)
            {
                imja.Text = "Доброе утро!";
                kar.Source = "ontik.jpg";
            }
            else if (time >= 7 && time < 10)
            {
                imja.Text = "Завтрак, прогулка, задания!";
                kar.Source = "i.jpeg";
            }
            else if (time >= 10 && time < 12)
            {
                imja.Text = " Дела домашние!";
                kar.Source = "ddi.jpg";
            }
            else if (time >= 12 && time < 14)
            {
                imja.Text = "Полдень!";
                kar.Source = "pol.jpg";
            }
            else if (time >= 14 && time < 16)
            {
                imja.Text = "Обед, сад!";
                kar.Source = "obl.jpg";
            }
            else if (time >= 16 && time < 17)
            {
                imja.Text = "Почти вечер!";
                kar.Source = "otd.jpg";
            }
            else if (time >= 18 && time < 21)
            {
                imja.Text = "Вечер, хочется отдохнуть!";
                kar.Source = "veh.jpg";
            }
            else if (time >= 21 && time < 23)
            {
                imja.Text = "Спать пора!";
                kar.Source = "sp.jpg";
            }
            else if (time == 23)
            {
                imja.Text = "Спокойной ночи!";
                kar.Source = "spnoh.jpg";
            }
        }
    }
    
}