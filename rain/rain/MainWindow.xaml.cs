using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace rain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Talas> TalasiBare= new List<Talas>();
        List<Talas> TalasiBareZaUklanjanje = new List<Talas>();
        List<Ellipse> ciscenjePovsiNiz = new List<Ellipse>();
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timerKapi = new DispatcherTimer();
        bool goleft = false;
        bool goright = false;
        bool goup = false;
        bool godown = false;
        Random rand = new Random();
        
        public MainWindow()
        {
            
            InitializeComponent();
            Povrs.Focus();
            timer.Tick += mainEvent;
            timer.Interval = TimeSpan.FromMilliseconds(40);
            timer.Start();
            Events.EventPadaKapi += formiranjeTalasa;

            timerKapi.Tick += stvaranjeKapi;
            timerKapi.Interval = TimeSpan.FromMilliseconds(rand.Next(500, 2000));
            timerKapi.Start();


        }

        private void stvaranjeKapi(object sender, EventArgs e)
        {
            new Kap((int)Canvas.GetLeft(oblak),rand.Next((int)Canvas.GetTop(oblak),(int)Canvas.GetTop(oblak)+(int)oblak.Height),rand.Next(2,8));
        }

        private void formiranjeTalasa(Kap k)
        {
            Talas t = new Talas(k.x,k.y,k.q);
            TalasiBare.Add(t);

        }

        private void mainEvent(object sender, EventArgs e)
        {
            if(TalasiBare.Count()>0)
            {
                foreach (var item in TalasiBare)
                {
                    

                    if(item.width > item.deltaR * 500)
                    {
                        TalasiBareZaUklanjanje.Add(item);
                    }
                    else
                    {
                        Events.funkcijaSirenja(item);
                        
                    }
                }
                foreach (var item in TalasiBareZaUklanjanje)
                {
                    TalasiBare.Remove(item);
                }
                foreach (var item in Povrs.Children.OfType<Ellipse>())
                {
                    ciscenjePovsiNiz.Add(item);
                }
                foreach (var item in ciscenjePovsiNiz)
                {
                    Povrs.Children.Remove(item);
                }
                foreach (Talas t in TalasiBare)
                {
                    Color boja = Color.FromRgb((byte)t.boja, (byte)t.boja, (byte)t.boja);
                    Ellipse el = new Ellipse
                    {
                        Width = t.width,
                        Height = t.width,
                        Stroke = new SolidColorBrush(boja),
                    };
                    Canvas.SetLeft(el, t.x);
                    Canvas.SetTop(el, t.y);
                    Povrs.Children.Add(el);
                }
               
            }
            if(goleft == true && Canvas.GetLeft(oblak)>0)
            {
                Canvas.SetLeft(oblak, Canvas.GetLeft(oblak)-6);
            }
            if (goright == true && Canvas.GetLeft(oblak) + oblak.Width < 800)
            {
                Canvas.SetLeft(oblak, Canvas.GetLeft(oblak) + 6);
            }
            if (goup == true && Canvas.GetTop(oblak) > 0)
            {
                Canvas.SetTop(oblak, Canvas.GetTop(oblak) - 6);
            }
            if (godown == true && Canvas.GetTop(oblak) +oblak.Height > 0)
            {
                Canvas.SetLeft(oblak, Canvas.GetTop(oblak) + 6);
            }
        }

        private void kretanje(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left)
            {
                goleft = true;
            }
            if (e.Key == Key.Right)
            {
                goright = true;
            }
            if (e.Key == Key.Up)
            {
                goup = true;
            }
            if (e.Key == Key.Down)
            {
                godown = true;
            }

        }

        private void stopiranje(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goleft = false;
            }
            if (e.Key == Key.Right)
            {
                goright = false;
            }
            if (e.Key == Key.Up)
            {
                goup = false;
            }
            if (e.Key == Key.Down)
            {
                godown = false;
            }
        }
    }
}
