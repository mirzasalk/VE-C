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

namespace plivaci
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        int plivacBrzina1;
        int plivacBrzina2 ;
        int plivacBrzina3;
        DispatcherTimer mainTimer = new DispatcherTimer(); 
        public UserControl2()
        {
            InitializeComponent();
            mainTimer.Tick += mainEvent;
            mainTimer.Interval = TimeSpan.FromMilliseconds(40);
            mainTimer.Start();
            Events.EventPostavljanjeStilova += postavljanjeStilova;

            plivacBrzina1 = 0;
            plivacBrzina2 = 0;
            plivacBrzina3 = 0;
        }

        private void postavljanjeStilova(int p1, int p2, int p3)
        {
            tekstPomoc.Text =" p1:" + p1.ToString() + " p2:" + p2.ToString() + " p3:" + p3.ToString();
       
            plivacBrzina1 = p1;
            plivacBrzina2 = p2;
            plivacBrzina3 = p3;
        }

       

    private void mainEvent(object sender, EventArgs e)
        {
            foreach (var item in con2Canvas.Children.OfType<Ellipse>())
            {
                if (Canvas.GetLeft(item) + item.Width >= 750)
                {
                  
                    MessageBox.Show("Pobedio je " + item.Name.ToString());
                    plivacBrzina1 = 0;
                    plivacBrzina2 = 0;
                    plivacBrzina3 = 0;
                    Canvas.SetLeft(item, 65);
                    Events.funkcijaMenjanja2();
                }
                if (item.Name == "plivac1")
                {
                    Canvas.SetLeft(item, Canvas.GetLeft(item) + plivacBrzina1);
                } else if (item.Name == "plivac2")
                {
                    Canvas.SetLeft(item, Canvas.GetLeft(item) + plivacBrzina2);
                }if (item.Name == "plivac3")
                {
                    Canvas.SetLeft(item, Canvas.GetLeft(item) + plivacBrzina3);
                }

            }
        }

         
    }
}
