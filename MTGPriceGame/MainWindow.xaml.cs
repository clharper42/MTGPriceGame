using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MTGPriceGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Program.Start();
            InitializeComponent();
            Set_Images();
        }

        private void Set_Images()
        {
            Card cardone = Program.cards[0];
            Card cardtwo = Program.cards[1];

            string test = cardone.image_uris.normal;

            CardImg1.Source = null;
            CardImg1F1.Source = null;
            CardImg1F2.Source = null;

            CardImg2.Source = null;
            CardImg2F1.Source = null;
            CardImg2F2.Source = null;


            if (cardone.card_faces != null && cardone.card_faces[0].image_uris != null)
            {
                CardImg1F1.Source = new BitmapImage(new Uri(cardone.card_faces[0].image_uris.normal));

                CardImg1F2.Source = new BitmapImage(new Uri(cardone.card_faces[1].image_uris.normal)); ;
            }
            else
            {
                CardImg1.Source = new BitmapImage(new Uri(cardone.image_uris.normal));
            }

            if (cardtwo.card_faces != null && cardtwo.card_faces[0].image_uris != null)
            {
     
                CardImg2F1.Source = new BitmapImage(new Uri(cardtwo.card_faces[0].image_uris.normal));

                CardImg2F2.Source = new BitmapImage(new Uri(cardtwo.card_faces[1].image_uris.normal));
            }
            else
            {
                CardImg2.Source = new BitmapImage(new Uri(cardtwo.image_uris.normal));
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Drag Display Around
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Close_ButtonClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_Right(object sender, RoutedEventArgs e)
        {
            Card cardone = Program.cards[0];
            double cardoneprice = Convert.ToDouble(cardone.prices.usd);

            Card cardtwo = Program.cards[1];
            double cardtwoprices = Convert.ToDouble(cardtwo.prices.usd);

            if(cardoneprice > cardtwoprices)
            {
                TotalText.Text = "$" + (Math.Round(Convert.ToDouble(TotalText.Text.Substring(1)) + cardoneprice, 2)).ToString();
            }
            else
            {
                TotalText.Text = "$" + (Math.Round(Convert.ToDouble(TotalText.Text.Substring(1)) - cardtwoprices, 2)).ToString();
            }

            Program.Get_Cards();
            Set_Images();

        }

        private void Button_Click_Left(object sender, RoutedEventArgs e)
        {
            Card cardone = Program.cards[0];
            double cardoneprice = Convert.ToDouble(cardone.prices.usd);

            Card cardtwo = Program.cards[1];
            double cardtwoprices = Convert.ToDouble(cardtwo.prices.usd);

            if (cardtwoprices > cardoneprice)
            {
                TotalText.Text = "$" + (Math.Round(Convert.ToDouble(TotalText.Text.Substring(1)) + cardtwoprices, 2)).ToString();
            }
            else
            {
                TotalText.Text = "$" + (Math.Round(Convert.ToDouble(TotalText.Text.Substring(1)) - cardoneprice, 2)).ToString();
            }

            Program.Get_Cards();
            Set_Images();

        }
    }
}
