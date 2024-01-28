using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ispitniZadatak1
{
    
    public class Bara
    {
        public List<Talas> Talasi;
        public List<Talas> TalasiForRemove;
        int BrojTalasa;
        DispatcherTimer iscrtavanjeTimer = new DispatcherTimer();
        Random rand = new Random();

        public Bara()
        {
            BrojTalasa = 0;
            Talasi = new List<Talas>();
            TalasiForRemove = new List<Talas>();
            Events.EventSirenja += sirenjeTalasa;
        }

        public List<Ellipse> iscrtavanje()
        {
            List<Ellipse> tals = new List<Ellipse>();
            foreach (var t in Talasi)
            {
               Ellipse newRec = new Ellipse
                {
                    Tag = "Talas",
                    Width = t.width,
                    Height = t.width,
                    Fill = new SolidColorBrush(Color.FromRgb((byte)rand.Next(1,255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255))),
                    Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                    StrokeThickness = 2
                };
                Canvas.SetLeft(newRec, t.x);
                Canvas.SetTop(newRec, t.y);
                tals.Add(newRec);
            }
            return tals;
        }
        public void DodajTalas(double x, double y, float q)
        {
            Talas t = new Talas(x, y, q);
            Talasi.Add(t);
        }
        private void sirenjeTalasa()
        {
            foreach (var item in Talasi)
            {
                if(item.width < item.deltaR * 400)
                {
                    item.width += item.deltaR;
                }
                else
                {
                    TalasiForRemove.Add(item);
                } 
            }
            foreach (var item in TalasiForRemove)
            {
                Talasi.Remove(item);
            }
        }
    }
}
