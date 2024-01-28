using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ispitniZadatak1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer padanjeKapiTimer = new DispatcherTimer();
        DispatcherTimer sirenjeTalasaTime = new DispatcherTimer();
        DispatcherTimer stvaranjeKapiTimer = new DispatcherTimer();
        DispatcherTimer kretanjeOblakaTimer = new DispatcherTimer();
        DispatcherTimer iscrtavanjeTimer = new DispatcherTimer();
        List<Kap> kapi = new List<Kap>();
        List<Kap> removerFromKapi = new List<Kap>();
        List<Ellipse> talasiCanvas = new List<Ellipse>();
        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;
        int brTalasa = 0;
        Random rand = new Random();
        Bara bara = new Bara();

        public MainWindow()
        {
            InitializeComponent();

            stvaranjeKapiTimer.Tick += stvaranjeKapi;
            stvaranjeKapiTimer.Interval = TimeSpan.FromMilliseconds(rand.Next(500, 2000));
            stvaranjeKapiTimer.Start();

            kretanjeOblakaTimer.Tick += kretanje;
            kretanjeOblakaTimer.Interval = TimeSpan.FromMilliseconds(50);
            kretanjeOblakaTimer.Start();

            padanjeKapiTimer.Tick += padanjeKapi;
            padanjeKapiTimer.Interval = TimeSpan.FromMilliseconds(500);
            padanjeKapiTimer.Start();

            iscrtavanjeTimer.Tick += iscrtavanje;
            iscrtavanjeTimer.Interval = TimeSpan.FromMilliseconds(40);
            iscrtavanjeTimer.Start();

            Povrs.Focus();
        }

        private void iscrtavanje(object sender, EventArgs e)
        {
            Events.funkcijaSirenja();
            List<Ellipse> tals = new List<Ellipse>();
            tals = bara.iscrtavanje();
            foreach (Ellipse item in talasiCanvas)
            {
                Povrs.Children.Remove(item);
            }
            foreach (Ellipse item in tals)
            {
                Povrs.Children.Add(item);
                talasiCanvas.Add(item);
            }
        }

        private void padanjeKapi(object sender, EventArgs e)
        {
            removerFromKapi.Clear();
           
            foreach (var k in kapi)
            {
                if(k.metri > 0)
                {
                    k.metri -= 10;
                }
                else
                {
                    bara.DodajTalas(k.x, k.y, k.q);
                    removerFromKapi.Add(k);
                }
            }
        }

        private void kretanje(object sender, EventArgs e)
        {
            if (up && Canvas.GetTop(oblak) > 0)
            {
                 Canvas.SetTop(oblak, Canvas.GetTop(oblak) - 10);
            }
            if (down && Canvas.GetTop(oblak) < 350)
            {
                Canvas.SetTop(oblak, Canvas.GetTop(oblak) + 10);
            }
            if (left && Canvas.GetLeft(oblak) > 0)
            {
                Canvas.SetLeft(oblak, Canvas.GetLeft(oblak) - 10);
            }
            if (right && Canvas.GetLeft(oblak) < 500)
            {
              Canvas.SetLeft(oblak, Canvas.GetLeft(oblak) + 10);
            }


            foreach (var r in removerFromKapi)
            {
                kapi.Remove(r);
            }

            helperText.Text = bara.Talasi.Count().ToString();
        }

        private void stvaranjeKapi(object sender, EventArgs e)
        {
            Kap k = new Kap(rand.Next((int)Canvas.GetLeft(oblak),(int)Canvas.GetLeft(oblak)+(int)oblak.Width),rand.Next((int)Canvas.GetTop(oblak), (int)Canvas.GetTop(oblak)+(int)oblak.Height),rand.Next(2,8));
            kapi.Add(k);
  
        }

        private void kretanjeOblaka(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left)
            {
                if (Canvas.GetLeft(oblak) > 0)
                {
                    left = true;
                   // Canvas.SetLeft(oblak, Canvas.GetLeft(oblak) - 10);
                }
                
            }
            if (e.Key == Key.Right)
            {
                if (Canvas.GetLeft(oblak) < 500 )
                {
                    right = true;
                   // Canvas.SetLeft(oblak, Canvas.GetLeft(oblak) + 10);
                }

            }
            if (e.Key == Key.Up)
            {
                if (Canvas.GetTop(oblak) > 0)
                {
                    up = true;
                   
                }

            }
            if (e.Key == Key.Down)
            {
                if (Canvas.GetTop(oblak) < 350)
                {
                    down = true;
                    //Canvas.SetTop(oblak, Canvas.GetTop(oblak) + 10);
                }

            }
        }

        private void kretanjeOblaka2(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
               
                    left = false;
                    // Canvas.SetLeft(oblak, Canvas.GetLeft(oblak) - 10);
                

            }
            if (e.Key == Key.Right)
            {
               
                    right = false;
                    // Canvas.SetLeft(oblak, Canvas.GetLeft(oblak) + 10);
                

            }
            if (e.Key == Key.Up)
            {
                
                    up = false;
                    // Canvas.SetTop(oblak, Canvas.GetTop(oblak) - 10);
                

            }
            if (e.Key == Key.Down)
            {
                
                    down = false;
                    //Canvas.SetTop(oblak, Canvas.GetTop(oblak) + 10);
                
            }
        }
    }
}
