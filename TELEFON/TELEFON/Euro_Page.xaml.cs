using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TELEFON
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Euro_Page : ContentPage
    {
        public ObservableCollection<Eur>europas { get; set; }
        Label lbl_list;
        ListView listeu;
        Button eddeu;
        Button deleu;
        public Euro_Page()
        {
            europas  = new ObservableCollection<Eur> 
            {
                new Eur {Nimetus="Estonia", Pealinn="Tallinn", Elanikud=1410007, Pilt="tal.jpg"},
                new Eur {Nimetus="Ausria", Pealinn="Vienna", Elanikud=1879883, Pilt="ven.jpg"},
                new Eur {Nimetus="Greese", Pealinn="Athens", Elanikud=3167786, Pilt="af.jpg"},
            };
            lbl_list = new Label
            {
                Text = "Европа",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))

            };
            listeu = new ListView
            {

                HasUnevenRows = true,
                ItemsSource = europas,
                ItemTemplate = new DataTemplate(() =>
                {

                    ImageCell imageCell = new ImageCell { TextColor = Color.Moccasin, DetailColor = Color.White };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Pealinn", StringFormat = "Pealinn on: {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;
                })
            };
            eddeu = new Button
            {
                Text = "Добавь страну",
                VerticalOptions = LayoutOptions.Center,
            };
            eddeu.Clicked += Eddeu_Clicked;
            deleu = new Button
            {
                Text = "Удали страну",
                VerticalOptions = LayoutOptions.Center,
            };
            deleu.Clicked += Deleu_Clicked;
            listeu.ItemTapped += Listeu_ItemTapped;
            this.Content = new StackLayout { Children = { lbl_list, listeu, eddeu, deleu } };
            this.BackgroundColor = Color.DimGray;
        }

        private async void Listeu_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Eur selectedeu = e.Item as Eur;
            if (selectedeu != null)
            {
                await DisplayAlert("Страны Европы: ", $"{selectedeu.Nimetus}: {selectedeu.Pealinn} " + "\nЖители: " + $"{selectedeu.Elanikud}", "OK");
            }
        }

        private void Deleu_Clicked(object sender, EventArgs e)
        {
            Eur euriik = listeu.SelectedItem as Eur;
            if (euriik != null)
            {
                europas.Remove(euriik);

            }
        }

        private async void Eddeu_Clicked(object sender, EventArgs e)
        {
            string nimetuseu = await DisplayPromptAsync("Добавь страну", "Название страны: ", initialValue: "", keyboard: Keyboard.Chat);
            string pealinneu = await DisplayPromptAsync("Добавь столицу", $"{nimetuseu}" + "столица: ", initialValue: "", keyboard: Keyboard.Chat);
            string elanikudeu = await DisplayPromptAsync("Население ", "Сколько жителей? " + $"{nimetuseu}" + ": ", initialValue: "1", keyboard: Keyboard.Numeric);
            int elanikuperedelen = Convert.ToInt32(elanikudeu);
            europas.Add(new Eur { Nimetus = nimetuseu, Pealinn = pealinneu, Elanikud = elanikuperedelen });
        }
    }
    }