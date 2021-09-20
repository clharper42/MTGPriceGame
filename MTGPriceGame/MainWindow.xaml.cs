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
using System.Windows.Threading;

namespace MTGPriceGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer t = new DispatcherTimer();
        DispatcherTimer tr = new DispatcherTimer();

        public MainWindow()
        {

            Program.Start();
            InitializeComponent();
            Set_Images();

            ColorFilter.ItemsSource = Program.colorfilters;
            ColorFilter.SelectedItem = Program.colorfilters[0];

            TypeFilter.ItemsSource = Program.typefilters;
            TypeFilter.SelectedItem = Program.typefilters[0];

            //Set the timer interval to the length of the animation.
            t.Interval = new TimeSpan(0, 0, 3);
            t.Tick += (EventHandler)delegate (object snd, EventArgs ea)
            {
                // The animation will be over now, collapse the label.
                lbl.Visibility = Visibility.Collapsed;
                // Get rid of the timer.
                ((DispatcherTimer)snd).Stop();
            };

            tr.Interval = new TimeSpan(0, 0, 3);
            tr.Tick += (EventHandler)delegate (object snd, EventArgs ea)
            {
                // The animation will be over now, collapse the label.
                lblr.Visibility = Visibility.Collapsed;
                // Get rid of the timer.
                ((DispatcherTimer)snd).Stop();
            };

        }

        private void Set_Images()
        {
            Card cardone = Program.cards[0];
            Card cardtwo = Program.cards[1];

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
            if(Program.cards.Count != 0 )
            {
                Card cardone = Program.cards[0];
                double cardoneprice = Convert.ToDouble(cardone.prices.usd);

                Card cardtwo = Program.cards[1];
                double cardtwoprices = Convert.ToDouble(cardtwo.prices.usd);

                if (cardoneprice > cardtwoprices)
                {
                    //TotalText.Text = "$" + (Math.Round(Convert.ToDouble(TotalText.Text.Substring(1)) + cardoneprice, 2)).ToString();
                    TotalText.Text = "$" + string.Format("{0:f2}", Math.Round(Convert.ToDouble(TotalText.Text.Substring(1)) + cardoneprice, 2));

                    //lbl.Content = "$" + cardoneprice.ToString();
                    lbl.Content = "$" + string.Format("{0:f2}", cardoneprice);

                    lbl.Visibility = Visibility.Visible;
                    t.Start();
                }
                else if (cardoneprice < cardtwoprices)
                {
                    //TotalText.Text = "$" + (Math.Round(Convert.ToDouble(TotalText.Text.Substring(1)) - cardtwoprices, 2)).ToString();
                    TotalText.Text = "$" + string.Format("{0:f2}", Math.Round(Convert.ToDouble(TotalText.Text.Substring(1)) - cardtwoprices, 2));

                    //lblr.Content = "$" + cardtwoprices.ToString();
                    lblr.Content = "$" + string.Format("{0:f2}", cardtwoprices);

                    lblr.Visibility = Visibility.Visible;
                    tr.Start();

                }
                else
                {
                    lbl.Content = "$0.00";

                    lbl.Visibility = Visibility.Visible;
                    t.Start();
                }
            }

            bool suc = Program.Get_Cards();
            if(!suc)
            {
                CardImg1.Source = null;
                CardImg1F1.Source = null;
                CardImg1F2.Source = null;

                CardImg2.Source = null;
                CardImg2F1.Source = null;
                CardImg2F2.Source = null;
            }
            else
            {
                Set_Images();
            }

        }

        private void Button_Click_Left(object sender, RoutedEventArgs e)
        {
            if(Program.cards.Count != 0)
            {
                Card cardone = Program.cards[0];
                double cardoneprice = Convert.ToDouble(cardone.prices.usd);

                Card cardtwo = Program.cards[1];
                double cardtwoprices = Convert.ToDouble(cardtwo.prices.usd);

                if (cardtwoprices > cardoneprice)
                {
                    //TotalText.Text = "$" + (Math.Round(Convert.ToDouble(TotalText.Text.Substring(1)) + cardtwoprices, 2)).ToString();
                    TotalText.Text = "$" + string.Format("{0:f2}", Math.Round(Convert.ToDouble(TotalText.Text.Substring(1)) + cardtwoprices, 2));

                    //lbl.Content = "$" + cardtwoprices.ToString();
                    lbl.Content = "$" + string.Format("{0:f2}", cardtwoprices);

                    lbl.Visibility = Visibility.Visible;
                    t.Start();
                }
                else if(cardtwoprices < cardoneprice)
                {
                    //TotalText.Text = "$" + (Math.Round(Convert.ToDouble(TotalText.Text.Substring(1)) - cardoneprice, 2)).ToString();
                    TotalText.Text = "$" + string.Format("{0:f2}", Math.Round(Convert.ToDouble(TotalText.Text.Substring(1)) - cardoneprice, 2));

                    //lblr.Content = "$" + cardoneprice.ToString();
                    lblr.Content = "$" + string.Format("{0:f2}", cardoneprice);

                    lblr.Visibility = Visibility.Visible;
                    tr.Start();
                }
                else
                {
                    lbl.Content = "$0.00";

                    lbl.Visibility = Visibility.Visible;
                    t.Start();
                }
            }

            bool suc = Program.Get_Cards();
            if(!suc)
            {
                CardImg1.Source = null;
                CardImg1F1.Source = null;
                CardImg1F2.Source = null;

                CardImg2.Source = null;
                CardImg2F1.Source = null;
                CardImg2F2.Source = null;
            }
            else
            {
                Set_Images();
            }

        }

        private void W_CheckedEvent(object sender, RoutedEventArgs e)
        {
            Program.Color = Program.Color + "W";
        }

        private void W_UncheckedEvent(object sender, RoutedEventArgs e)
        {
            Program.Color = Program.Color.Replace("W", "");
        }
        private void U_CheckedEvent(object sender, RoutedEventArgs e)
        {
            Program.Color = Program.Color + "U";
        }

        private void U_UncheckedEvent(object sender, RoutedEventArgs e)
        {
            Program.Color = Program.Color.Replace("U", "");
        }

        private void B_CheckedEvent(object sender, RoutedEventArgs e)
        {
            Program.Color = Program.Color + "B";
        }

        private void B_UncheckedEvent(object sender, RoutedEventArgs e)
        {
            Program.Color = Program.Color.Replace("B", "");
        }
        private void R_CheckedEvent(object sender, RoutedEventArgs e)
        {
            Program.Color = Program.Color + "R";
        }

        private void R_UncheckedEvent(object sender, RoutedEventArgs e)
        {
            Program.Color = Program.Color.Replace("R", "");
        }
        private void G_CheckedEvent(object sender, RoutedEventArgs e)
        {
            Program.Color = Program.Color + "G";
        }

        private void G_UncheckedEvent(object sender, RoutedEventArgs e)
        {
            Program.Color = Program.Color.Replace("G", "");
        }

        private void C_CheckedEvent(object sender, RoutedEventArgs e)
        {
            Program.Color = Program.Color + "C";
        }

        private void C_UncheckedEvent(object sender, RoutedEventArgs e)
        {
            Program.Color = Program.Color.Replace("C", "");
        }

        private void ColorFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                string filter = (e.AddedItems[0] as string);
                if (filter.Equals(Program.colorfilters[0]))
                {
                    Program.ColorFilter = "+color%3D";
                }
                else if(filter.Equals(Program.colorfilters[1]))
                {
                    Program.ColorFilter = "+color>%3D";
                }
                else
                {
                    Program.ColorFilter = "+color<%3D";
                }
            }
 
        }

        private void TypeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                string filter = (e.AddedItems[0] as string);
                if (!filter.Equals(Program.typefilters[0]))
                {
                   if(filter.Equals(Program.typefilters[1]))
                   {
                       Program.Selectedtype = Program.Typefilter + Program.typefilters[2].ToLower() + Program.Selectedtypeleg;
                   }
                   else
                   {
                        Program.Selectedtype = Program.Typefilter + filter.ToLower();
                   }
                }
                else
                {
                    Program.Selectedtype = "";
                }
                
            }
        }
    }
}
