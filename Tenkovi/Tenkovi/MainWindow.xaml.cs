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
using static System.Net.Mime.MediaTypeNames;

namespace Tenkovi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool tenkDole = false;
        bool tenkGore = false;
        bool tenkLevo = false;
        bool tenkDesno = false;
        bool tenkDole2 = false;
        bool tenkGore2 = false;
        bool tenkLevo2 = false;
        bool tenkDesno2 = false;
        bool stvaraj1 = false;
        bool stvaraj2 = false;
        DispatcherTimer mainTimer = new DispatcherTimer();
        DispatcherTimer unosTekstaTimer = new DispatcherTimer();
        string smerMetka1 = "desno";
        string smerMetka2 = "levo";
        List<Rectangle> metciZaBrisanje = new List<Rectangle>();
        List<Rectangle> metci = new List<Rectangle>();
        public MainWindow()
        {
            InitializeComponent();
            mainTimer.Tick += mainEvent;
            mainTimer.Interval = TimeSpan.FromMilliseconds(40);

            unosTekstaTimer.Tick += proveraUnosa;
            unosTekstaTimer.Interval = TimeSpan.FromMilliseconds(40);
            unosTekstaTimer.Start();

            myCanvas.Focus();
            
        }

        private void proveraUnosa(object sender, EventArgs e)
        {
            if (visina.Text != "0" && sirina.Text != "0")
            {
                string tekstsirine = sirina.Text.Replace('.', ',');
                string tekstvisine = visina.Text.Replace('.', ',');

                if (double.TryParse(tekstsirine, out double SirinaPrepreke) && double.TryParse(tekstvisine, out double VisinaPrepreke))
                {
                   
                    PrimerPrepreke.Width = SirinaPrepreke;
                    PrimerPrepreke.Height = VisinaPrepreke;
                    Canvas.SetLeft(PrimerPrepreke, Canvas.GetLeft(panelZaUnos) + (panelZaUnos.Width / 2) - (PrimerPrepreke.Width / 2));
                    validText.Text = "Unos je validan";
                }
                else
                {
                    validText.Text = "Unos nije validan";
                }
            }
        }

        private void mainEvent(object sender, EventArgs e)
        {

            
           
            foreach (var item in myCanvas.Children.OfType<Rectangle>())
            {
                if(item.Tag == "metaklevo" || item.Tag =="metakdesno"|| item.Tag == "metakgore" || item.Tag == "metakdole")
                {
                    metci.Add(item);
                }
                
            }
            foreach (Rectangle p in metci)
            {
              
                if(p.Tag == "metaklevo")
                {
                    Canvas.SetLeft(p, Canvas.GetLeft(p) - 4);
                    if (Canvas.GetLeft(p) < 0)
                    {
                        myCanvas.Children.Remove(p);
                    }
                }else  if (p.Tag == "metakdesno")
                {
                    Canvas.SetLeft(p, Canvas.GetLeft(p) + 4);
                    if (Canvas.GetLeft(p) > 1000)
                    {
                        metciZaBrisanje.Add(p);
                      
                    }
                }
                else if(p.Tag == "metakgore")
                {
                    Canvas.SetTop(p, Canvas.GetTop(p) - 4);
                    if (Canvas.GetTop(p) <0)
                    {
                      
                        metciZaBrisanje.Add(p);
                    }
                }
                else if(p.Tag == "metakdole")
                {
                    Canvas.SetTop(p, Canvas.GetTop(p) + 4);
                    if (Canvas.GetTop(p) > 450)
                    {
                      
                        metciZaBrisanje.Add(p);
                    }
                }

                foreach (Rectangle rec in metciZaBrisanje)
                {
                    myCanvas.Children.Remove(rec);
                    metci.Remove(rec);
                }


                Rect tenk1Rect = new Rect(Canvas.GetLeft(Tenk1), Canvas.GetTop(Tenk1), 60, 60);
                Rect tenk2Rect = new Rect(Canvas.GetLeft(Tenk2), Canvas.GetTop(Tenk2), 60, 60);
                if(tenk2Rect.IntersectsWith(tenk1Rect))
                {
                    tenkDesno = false;
                    tenkDole = false;
                    tenkLevo = false;
                    tenkGore = false;
                    tenkDesno2 = false;
                    tenkDole2 = false;
                    tenkLevo2 = false;
                    tenkGore2 = false;
                }
                var platformID = (string)p.Tag;
                if (platformID == "prepreka")
                {
                    Rect r = new Rect(Canvas.GetLeft(p), Canvas.GetTop(p), p.Width, p.Height);
                    if (tenk1Rect.IntersectsWith(r))
                    {
                        if(tenkDesno)
                        {
                            Canvas.SetLeft(Tenk1, Canvas.GetLeft(p) - Tenk1.Width-1);
                        }else if(tenkLevo)
                        {
                            Canvas.SetLeft(Tenk1, Canvas.GetLeft(p) + p.Width+1);
                        }else if(tenkDole)
                        {
                            Canvas.SetTop(Tenk1, Canvas.GetTop(p) - Tenk1.Height-1);
                        }
                        else
                        {
                            Canvas.SetTop(Tenk1, Canvas.GetTop(p) + p.Height +1);
                        }

                        tenkDesno = false;
                        tenkDole = false;
                        tenkLevo = false;
                        tenkGore = false;
                       
                        
                    }
                    if (tenk2Rect.IntersectsWith(r))
                    {
                        if (tenkDesno2)
                        {
                            Canvas.SetLeft(Tenk2, Canvas.GetLeft(p) - Tenk2.Width - 1);
                        }
                        else if (tenkLevo2)
                        {
                            Canvas.SetLeft(Tenk2, Canvas.GetLeft(p) + p.Width + 1);
                        }
                        else if (tenkDole)
                        {
                            Canvas.SetTop(Tenk2, Canvas.GetTop(p) - Tenk2.Height - 1);
                        }
                        else
                        {
                            Canvas.SetTop(Tenk2, Canvas.GetTop(p) + p.Height + 1);
                        }

                        tenkDesno2 = false;
                        tenkDole2 = false;
                        tenkLevo2 = false;
                        tenkGore2 = false;
                    }
                }
            }


            if (tenkDesno == true && Canvas.GetLeft(Tenk1)+Tenk1.Width < 800)
            {
                Canvas.SetLeft(Tenk1, Canvas.GetLeft(Tenk1) + 3);
            }
            if (tenkLevo == true && Canvas.GetLeft(Tenk1) > 0)
            {
                Canvas.SetLeft(Tenk1, Canvas.GetLeft(Tenk1) - 3);
            }
            if (tenkGore == true && Canvas.GetTop(Tenk1) > 0)
            {
                Canvas.SetTop(Tenk1, Canvas.GetTop(Tenk1) - 3);
            }
            if (tenkDole == true && Canvas.GetTop(Tenk1) + Tenk1.Height < 450)
            {
                Canvas.SetTop(Tenk1, Canvas.GetTop(Tenk1) + 3);
            }

          


            if (tenkDesno2 == true && Canvas.GetLeft(Tenk2) + Tenk2.Width < 800)
            {
                Canvas.SetLeft(Tenk2, Canvas.GetLeft(Tenk2) + 3);
            }
            if (tenkLevo2 == true && Canvas.GetLeft(Tenk2) > 0)
            {
                Canvas.SetLeft(Tenk2, Canvas.GetLeft(Tenk2) - 3);
            }
            if (tenkGore2 == true && Canvas.GetTop(Tenk2) > 0)
            {
                Canvas.SetTop(Tenk2, Canvas.GetTop(Tenk2) - 3);
            }
            if (tenkDole2 == true && Canvas.GetTop(Tenk2) + Tenk2.Height < 450)
            {
                Canvas.SetTop(Tenk2, Canvas.GetTop(Tenk2) + 3);
            }
           

        }

        private void pokretanjeTenkova(object sender, KeyEventArgs e)
        {
           
            if (e.Key == Key.Down)
            {
                tenkDole = true;
                smerMetka1 = "dole";
            }
            if(e.Key == Key.Up)
            {
                tenkGore = true;
                smerMetka1 = "gore";
            }
            if(e.Key == Key.Left)
            {
                tenkLevo = true;
                smerMetka1 = "levo";
            }
            if(e.Key == Key.Right)
            {
                tenkDesno = true;
                smerMetka1 = "desno";
            }

            if (e.Key == Key.S)
            {
                tenkDole2 = true;
                smerMetka2 = "dole";
            }
            if (e.Key == Key.W)
            {
                smerMetka2 = "gore";
                tenkGore2 = true;
            }
            if (e.Key == Key.A)
            {
                smerMetka2 = "levo";
                tenkLevo2 = true;
            }
            if (e.Key == Key.D)
            {
                tenkDesno2 = true;
                smerMetka2 = "desno";
            }
            if(e.Key == Key.O)
            {
                mainTimer.Start();
                unosTekstaTimer.Stop();
                validText.Visibility = Visibility.Hidden;
                sirina.Visibility = Visibility.Hidden;
                visina.Visibility = Visibility.Hidden;
                PrimerPrepreke.Visibility = Visibility.Hidden;
            }
            if(e.Key == Key.P)
            {

                unosTekstaTimer.Start();
                mainTimer.Stop();
                sirina.Visibility = Visibility.Visible;
                visina.Visibility = Visibility.Visible;
                PrimerPrepreke.Visibility = Visibility.Visible;

            }

            if(e.Key == Key.Enter)
            {

                Rectangle r;

                if (smerMetka1 == "levo")
                {
                    r = new Rectangle
                    {
                        Tag = "metaklevo",
                        Width = 8,
                        Height = 4,
                        Fill = new SolidColorBrush(Colors.Yellow),
                    };
                    Canvas.SetLeft(r, Canvas.GetLeft(Tenk1) - r.Width - 1);
                    Canvas.SetTop(r, Canvas.GetTop(Tenk1) + Tenk1.Height / 2);
                    myCanvas.Children.Add(r);
                }
                else if (smerMetka1 == "gore")
                {
                    r = new Rectangle
                    {
                        Tag = "metakgore",
                        Width = 4,
                        Height = 8,
                        Fill = new SolidColorBrush(Colors.Yellow),
                    };
                    Canvas.SetLeft(r, Canvas.GetLeft(Tenk1) + Tenk1.Width / 2);
                    Canvas.SetTop(r, Canvas.GetTop(Tenk1) - r.Width - 1);
                    myCanvas.Children.Add(r);
                }
                else if (smerMetka1 == "desno")
                {
                    r = new Rectangle
                    {
                        Tag = "metakdesno",
                        Width = 8,
                        Height = 4,
                        Fill = new SolidColorBrush(Colors.Yellow),
                    };
                    Canvas.SetLeft(r, Canvas.GetLeft(Tenk1) + Tenk1.Width + 1);
                    Canvas.SetTop(r, Canvas.GetTop(Tenk1) + Tenk1.Height / 2);
                    myCanvas.Children.Add(r);
                }
                else if (smerMetka1 == "dole")
                {
                    r = new Rectangle
                    {
                        Tag = "metakdole",
                        Width = 4,
                        Height = 8,
                        Fill = new SolidColorBrush(Colors.Yellow),
                    };
                    Canvas.SetLeft(r, Canvas.GetLeft(Tenk1) + Tenk1.Width / 2);
                    Canvas.SetTop(r, Canvas.GetTop(Tenk1) + Tenk1.Height + 1);
                    myCanvas.Children.Add(r);
                }



            }

            if (e.Key == Key.Space)
            {
               
                    Rectangle r;

                    if (smerMetka2 == "levo")
                    {
                        r = new Rectangle
                        {
                            Tag = "metaklevo",
                            Width = 8,
                            Height = 4,
                            Fill = new SolidColorBrush(Colors.Yellow),
                        };
                        Canvas.SetLeft(r, Canvas.GetLeft(Tenk2) - r.Width - 1);
                        Canvas.SetTop(r, Canvas.GetTop(Tenk2) + Tenk2.Height / 2);
                        myCanvas.Children.Add(r);
                    }
                    else if (smerMetka2 == "gore")
                    {
                        r = new Rectangle
                        {
                            Tag = "metakgore",
                            Width = 4,
                            Height = 8,
                            Fill = new SolidColorBrush(Colors.Yellow),
                        };
                        Canvas.SetLeft(r, Canvas.GetLeft(Tenk2) + Tenk2.Width / 2);
                        Canvas.SetTop(r, Canvas.GetTop(Tenk2) - r.Width - 1);
                        myCanvas.Children.Add(r);
                    }
                    else if (smerMetka2 == "desno")
                    {
                        r = new Rectangle
                        {
                            Tag = "metakdesno",
                            Width = 8,
                            Height = 4,
                            Fill = new SolidColorBrush(Colors.Yellow),
                        };
                        Canvas.SetLeft(r, Canvas.GetLeft(Tenk2) + Tenk2.Width + 1);
                        Canvas.SetTop(r, Canvas.GetTop(Tenk2) + Tenk2.Height / 2);
                        myCanvas.Children.Add(r);
                    }
                    else if (smerMetka2 == "dole")
                    {
                        r = new Rectangle
                        {
                            Tag = "metakdole",
                            Width = 4,
                            Height = 8,
                            Fill = new SolidColorBrush(Colors.Yellow),
                        };
                        Canvas.SetLeft(r, Canvas.GetLeft(Tenk2) + Tenk2.Width / 2);
                        Canvas.SetTop(r, Canvas.GetTop(Tenk2) + Tenk2.Height + 1);
                        myCanvas.Children.Add(r);
                    }
                




            }
        }

        private void stopiranjeTenkova(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                tenkDole = false;
            }
            if (e.Key == Key.Up)
            {
                tenkGore = false;
            }
            if (e.Key == Key.Left)
            {
                tenkLevo = false;
            }
            if (e.Key == Key.Right)
            {
                tenkDesno = false;
            }

            if (e.Key == Key.S)
            {
                tenkDole2 = false;
            }
            if (e.Key == Key.W)
            {
                tenkGore2 = false;
            }
            if (e.Key == Key.A)
            {
                tenkLevo2 = false;
            }
            if (e.Key == Key.D)
            {
                tenkDesno2 = false;
            }
            if(e.Key == Key.Enter)
            {
                stvaraj1 = false;
            }
            if (e.Key == Key.Space)
            {
                stvaraj2 = false;
            }
        }

        private void dodavanjePrepreka(object sender, MouseButtonEventArgs e)
        {
             Point p = e.GetPosition(this);
                double x = p.X;
                double y = p.Y;

                if(e.OriginalSource is Rectangle)
                {
                    Rectangle s = (Rectangle)e.OriginalSource;
                    if (s.Tag == "prepreka")
                    {
                        myCanvas.Children.Remove(s);
                    }
                    else if (s.Name == "panelZaUnos" ||s.Name == "PrimerPrepreke"||s.Name == "Nemoj" || Canvas.GetLeft(panelZaUnos) - PrimerPrepreke.Width < x)
                   {
                        validText.Text = "Prepreka ne moze biti dodata na mestu koje zelite";
                    }
                    else
                    {
                        Rectangle r = new Rectangle
                        {
                            Tag = "prepreka",
                            Width = PrimerPrepreke.Width,
                            Height = PrimerPrepreke.Height,
                            Fill = new SolidColorBrush(Colors.Gray),
                        };
                        Canvas.SetLeft(r, x);
                        Canvas.SetTop(r, y);
                        myCanvas.Children.Add(r);
                    }


                }
               
           
        }
    }
}
