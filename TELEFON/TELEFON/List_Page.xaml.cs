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

    public partial class List_Page : ContentPage
    {

        // public List<Telefon> telefons { get; set; }
        public ObservableCollection<Telefon> telefons { get; set; }
        public ObservableCollection<Ruhm<string, Telefon>> telefonideruhmades { get; set; }
        Label lbl;
        ListView list;
        Button ad, del;
        public List_Page()
        {
            ad = new Button { Text = "Добавь телефон" };
            del= new Button { Text = "Удали телефон" };
            lbl = new Label
            {
                Text = "ТЕЛЕФОНЫ",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            // InitializeComponent();
            //Telefonid = string[] { "Samsung 10","iPhone13","HuaweiP10", "LG G6" };
            telefons = new ObservableCollection<Telefon>
            {
             new Telefon {Nimetus = "Samsung 10", Tootja = "Samsung", Hind = 300, Pilt="sam.jpg"},
             new Telefon {Nimetus = "Xiome 1", Tootja = "Xiome", Hind = 700, Pilt="le.jpg"},
             new Telefon {Nimetus = "iPhone i5", Tootja = "iPhone", Hind = 500, Pilt="ll.jpg"},
             new Telefon {Nimetus = "Samsung h", Tootja = "Samsung", Hind = 700, Pilt="ssam.jpg" },

            };
            var telefonid = new List<Telefon>
            {
             new Telefon {Nimetus = "Samsung 10", Tootja = "Samsung", Hind = 300, Pilt="sam.jpg" },
             new Telefon {Nimetus = "Xiome 1", Tootja = "Xiome", Hind = 700, Pilt="le.jpg" },
             new Telefon {Nimetus = "iPhone i5", Tootja = "iPhone", Hind = 500, Pilt="ll.jpg"},
             new Telefon {Nimetus = "Samsung h", Tootja = "Samsung", Hind = 700, Pilt="ssam.jpg" },
            };

            //{
            //new Telefon {Nimetus="Samsung Galaxy", Tootja="Samsung", Hind=134, Pilt="G"},
            //new Telefon {Nimetus="Xiaomi M", Tootja="Xiaomi", Hind=33 , Pilt="Xi.png"},
            //new Telefon {Nimetus="iPhone 1", Tootja="Apple", Hind=119 , Pilt="i.png" },
            //new Telefon {Nimetus="iPhone 2", Tootja="Apple", Hind=179 , Pilt="iP.png" }


            //};
            //var ruhmad = telefonid.GroupBy(p => p.Tootja).Select(g => new Ruhm<string, Telefon>(g.Key, g));
            //telefonideruhmades = new ObservableCollection<Ruhm<string, Telefon>>(ruhmad);
            
            list = new ListView
            {
                SeparatorColor = Color.Black,
                Header = "Коллекция",
                Footer = DateTime.Now.ToString("T"),

                HasUnevenRows = true,
                ItemsSource = telefons,
                ItemTemplate = new DataTemplate(() =>
                  {
                      /*Label nime = new Label { FontSize = 20 };
                      nime.SetBinding(Label.TextProperty, "Nimetus");

                      Label tootja = new Label();
                      tootja.SetBinding(Label.TextProperty, "Tootja");

                      Label hind = new Label();
                      hind.SetBinding(Label.TextProperty, "Hind");

                      return new ViewCell
                      {
                          View = new StackLayout
                          {
                              Padding = new Thickness(0, 5),
                              Orientation = StackOrientation.Vertical,
                              Children = { nime, tootja, hind }
                          }
                      };*/
                      ImageCell imageCell = new ImageCell { TextColor = Color.Brown, DetailColor = Color.Purple };
                      imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                      Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Отличный {0}" };

                      imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                      imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                      return imageCell;
                  })




            };
            ad = new Button
            {
                Text = "Добавь телефон",
                //HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            ad.Clicked += Ad_Clicked;
            del = new Button
            {
                Text = "Удали телефон",
                //HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            del.Clicked += Del_Clicked;
            list.ItemTapped += List_ItemTapped1;
            //List.ItemSelected += List_ItemSelected;
            this.Content = new StackLayout
            {
                Children = { lbl, list, ad, del }
            };


        }

        private void Del_Clicked(object sender, EventArgs e)
        {
            Telefon phone = list.SelectedItem as Telefon;
            if (phone != null)
            {
                telefons.Remove(phone);
                //list.SelectedItem = null;
            }
        }

        private void Ad_Clicked(object sender, EventArgs e)
        {
            telefons.Add(new Telefon { Nimetus = "Telefon", Tootja = "Tootja", Hind = 1 });
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                lbl.Text = e.SelectedItem.ToString();
        }

        private async void List_ItemTapped1(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone != null)
                await DisplayAlert("Выбранная модель", $"{selectedPhone.Tootja} - {selectedPhone.Nimetus}", "OK");
        }

       
    }
}