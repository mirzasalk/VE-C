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

namespace pumpa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new Random();
        DispatcherTimer pristizanjeAutaTimer = new DispatcherTimer();
        DispatcherTimer crtanjeTimer = new DispatcherTimer();


        Stanica stanica;
        int brAuta = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            pristizanjeAutaTimer.Tick += DodavanjeAutaURed;
            pristizanjeAutaTimer.Interval = TimeSpan.FromMilliseconds(rand.Next(500, 1000));
            pristizanjeAutaTimer.Start();

            crtanjeTimer.Tick += crtanje;
            crtanjeTimer.Interval = TimeSpan.FromMilliseconds(rand.Next(40));
            crtanjeTimer.Start();



            stanica = new Stanica();


        }

        private void crtanje(object sender, EventArgs e)
        {
            List<Pumpa> pumpe = new List<Pumpa>();
            pumpe = stanica.getPumpmeStanice();
            int i = 0;
            foreach (Pumpa p in pumpe)
            {
                i++;



                foreach (Rectangle r in MyCanvas.Children.OfType<Rectangle>())
                {

                    if (r.Name == "pumpa" + i)
                    {

                        Automobil auto;
                        auto = p.getAutoPumpe();
                        Console.WriteLine("usli");
                        if (auto != null)
                        {
                            Console.WriteLine("pumpa" + i);
                            r.Width = (float)auto.getTrenutniKolicina() * 12;
                        }

                    }
                }

                myStackPanel.Children.Clear();
                if (stanica.getRedCekanja().Count > 0)
                {
                    foreach (Automobil a in stanica.getRedCekanja())
                    {
                        TextBlock t = new TextBlock();
                        t.Text = a.getId().ToString();

                        myStackPanel.Children.Add(t);

                    }
                }
            }
        }

        private void DodavanjeAutaURed(object sender, EventArgs e)
        {
            brAuta++;
            Automobil a = new Automobil(brAuta);
            if(stanica.getRedCekanja().Count()<20)
            {
                stanica.pristizanjeAutaUredCekanja(a);
            }
        }
    }
}
