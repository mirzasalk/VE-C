using System;
using System.Collections.Generic;
using System.Data;
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

namespace Altay
{
  
    public partial class MainWindow : Window
    {
        DispatcherTimer mainTimer = new DispatcherTimer();
        bool goLeft = false;
        bool goRight = false;
        bool goUp = false;
        bool goDown = false;
        bool goLeftAbrams = false;
        bool goRightAbrams = false;
        bool goUpAbrams = false;
        bool goDownAbrams = false;
        string FaceAltay = "left";
        string FaceAbrams = "right";
        List<Rectangle> removeList = new List<Rectangle>();
        public MainWindow()
        {
            InitializeComponent();
            mainTimer.Tick += mainEvent;
            mainTimer.Interval = TimeSpan.FromMilliseconds(40);
            mainTimer.Start();

            myCanvas.Focus();
            
        }

        private void mainEvent(object sender, EventArgs e)
        {
            Rect AltayRect = new Rect(Canvas.GetLeft(Altay),Canvas.GetTop(Altay),Altay.Width,Altay.Height);
            Rect m1AbramsRect = new Rect(Canvas.GetLeft(M1Abrams), Canvas.GetTop(M1Abrams), M1Abrams.Width, M1Abrams.Height);
            if (goLeft == true)
            {
                Canvas.SetLeft(Altay, Canvas.GetLeft(Altay) - 6);
            }
            if(goRight == true)
            {
                Canvas.SetLeft(Altay, Canvas.GetLeft(Altay) + 6);
            }
            if(goUp == true)
            {
                Canvas.SetTop(Altay, Canvas.GetTop(Altay) - 6);
            }
            if(goDown == true)
            {
                Canvas.SetTop(Altay, Canvas.GetTop(Altay) + 6);
            }



            if (goLeftAbrams == true)
            {
                Canvas.SetLeft(M1Abrams, Canvas.GetLeft(M1Abrams) - 6);
            }
            if (goRightAbrams == true)
            {
                Canvas.SetLeft(M1Abrams, Canvas.GetLeft(M1Abrams) + 6);
            }
            if (goUpAbrams == true)
            {
                Canvas.SetTop(M1Abrams, Canvas.GetTop(M1Abrams) - 6);
            }
            if (goDownAbrams == true)
            {
                Canvas.SetTop(M1Abrams, Canvas.GetTop(M1Abrams) + 6);
            }


            foreach (Rectangle item in myCanvas.Children.OfType<Rectangle>())
            {

              if(item.Tag !=null)
                { 
                if(item.Tag.ToString() == "buletleft")
                {
                    Rect buletRect = new Rect(Canvas.GetLeft(item), Canvas.GetTop(item), item.Width, item.Height);

                        if (buletRect.IntersectsWith(m1AbramsRect))
                        {
                            mainTimer.Stop();
                            MessageBox.Show("Altaj je pobedio");
                        }

                        if (buletRect.IntersectsWith(AltayRect))
                        {
                            mainTimer.Stop();
                            MessageBox.Show("Abrams je pobedio");
                        }
                       
                        if (Canvas.GetLeft(item)< - 10)
                    {
                        removeList.Add(item);
                    }
                    Canvas.SetLeft(item, Canvas.GetLeft(item) - 8);
                }
                if (item.Tag.ToString() == "buletright")
                {
                        Rect buletRect = new Rect(Canvas.GetLeft(item), Canvas.GetTop(item), item.Width, item.Height);
                        if (Canvas.GetLeft(item) > 800)
                    {
                        removeList.Add(item);
                    }
                    Canvas.SetLeft(item, Canvas.GetLeft(item) + 8);
                }
                if (item.Tag.ToString() == "buletup")
                {
                        Rect buletRect = new Rect(Canvas.GetLeft(item), Canvas.GetTop(item), item.Width, item.Height);
                        if (Canvas.GetTop(item) < -10)
                    {
                        removeList.Add(item);
                    }
                    Canvas.SetTop(item, Canvas.GetTop(item) - 8);
                }
                if (item.Tag.ToString() == "buletdown")
                {
                        Rect buletRect = new Rect(Canvas.GetLeft(item), Canvas.GetTop(item), item.Width, item.Height);
                    if (Canvas.GetTop(item) > 450)
                    {
                        removeList.Add(item);
                    }
                    Canvas.SetTop(item, Canvas.GetTop(item) + 8);
                }
                }

            }
            foreach (Rectangle item in removeList)
            {
                myCanvas.Children.Remove(item);
            }
            removeList.Clear();
            GC.Collect();
        }

        private void kretanjeTenkova(object sender, KeyEventArgs e)
        {

            if(e.Key == Key.Left)
            {
                goLeft = true;
                FaceAltay = "left";
            }
            if(e.Key == Key.Right)
            {
                goRight = true;
                FaceAltay = "right";
            }
            if(e.Key == Key.Up)
            {
                goUp = true;
                FaceAltay = "up";
            }
            if(e.Key == Key.Down)
            {
                goDown = true;
                FaceAltay = "down";
            }


            if (e.Key == Key.A)
            {
                goLeftAbrams = true;
                FaceAbrams = "left";
            }
            if (e.Key == Key.D)
            {
                goRightAbrams = true;
                FaceAbrams = "right";
            }
            if (e.Key == Key.W)
            {
                goUpAbrams = true;
                FaceAbrams = "up";
            }
            if (e.Key == Key.S)
            {
                goDownAbrams = true;
                FaceAbrams = "down";
            }

            if (e.Key == Key.Space)
            {
                int w = 10;
                int h = 5;

                if (FaceAbrams == "up" || FaceAbrams == "down")
                {
                    w = 5;
                    h = 10;
                }
                Rectangle bulet = new Rectangle
                {
                    Tag = "bulet" + FaceAbrams,
                    Width = w,
                    Height = h,
                    Fill = new SolidColorBrush(Colors.Yellow),
                };
                if (FaceAbrams == "left")
                {
                    Canvas.SetLeft(bulet, Canvas.GetLeft(M1Abrams) - bulet.Width - 1);
                    Canvas.SetTop(bulet, Canvas.GetTop(M1Abrams) + M1Abrams.Height / 2);
                }
                else if (FaceAbrams == "right")
                {
                    Canvas.SetLeft(bulet, Canvas.GetLeft(M1Abrams) + M1Abrams.Width + 1);
                    Canvas.SetTop(bulet, Canvas.GetTop(M1Abrams) + M1Abrams.Height / 2);
                }
                else if (FaceAbrams == "up")
                {
                    Canvas.SetTop(bulet, Canvas.GetTop(M1Abrams) - bulet.Height - 1);
                    Canvas.SetLeft(bulet, Canvas.GetLeft(M1Abrams) + M1Abrams.Width / 2);
                }
                else
                {
                    Canvas.SetTop(bulet, Canvas.GetTop(M1Abrams) + M1Abrams.Width + 1);
                    Canvas.SetLeft(bulet, Canvas.GetLeft(M1Abrams) + M1Abrams.Width / 2);
                };
                pomoc.Text = bulet.Tag.ToString();
                myCanvas.Children.Add(bulet);

            }

            if(e.Key == Key.Enter)
            {
                int w = 10;
                int h = 5;

                if (FaceAltay == "up" || FaceAltay == "down")
                {
                    w = 5;
                    h = 10;
                }
                Rectangle bulet = new Rectangle
                {
                    Tag = "bulet" + FaceAltay,
                    Width = w,
                    Height = h,
                    Fill = new SolidColorBrush(Colors.Yellow),
                };
                if (FaceAltay == "left")
                {
                    Canvas.SetLeft(bulet, Canvas.GetLeft(Altay) - bulet.Width - 1);
                    Canvas.SetTop(bulet, Canvas.GetTop(Altay) + Altay.Height / 2);
                }
                else if (FaceAltay == "right")
                {
                    Canvas.SetLeft(bulet, Canvas.GetLeft(Altay) + Altay.Width + 1);
                    Canvas.SetTop(bulet, Canvas.GetTop(Altay) + Altay.Height / 2);
                }
                else if (FaceAltay == "up")
                {
                    Canvas.SetTop(bulet, Canvas.GetTop(Altay) - bulet.Height - 1);
                    Canvas.SetLeft(bulet, Canvas.GetLeft(Altay) + Altay.Width / 2);
                }
                else
                {
                    Canvas.SetTop(bulet, Canvas.GetTop(Altay) + Altay.Width + 1);
                    Canvas.SetLeft(bulet, Canvas.GetLeft(Altay) + Altay.Width / 2);
                };
                pomoc.Text = bulet.Tag.ToString();
                myCanvas.Children.Add(bulet);

            }

        }

        private void zaustavljanjeTenkova(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = false;
               
            }
            if (e.Key == Key.Right)
            {
                goRight = false;
                
            }
            if (e.Key == Key.Up)
            {
                goUp = false;
                
            }
            if (e.Key == Key.Down)
            {
                goDown = false;
               
            }




            if (e.Key == Key.A)
            {
                goLeftAbrams = false;
            }
            if (e.Key == Key.D)
            {
                goRightAbrams = false;
            }
            if (e.Key == Key.W)
            {
                goUpAbrams = false;
            }
            if (e.Key == Key.S)
            {
                goDownAbrams = false;
            }


           
        }
    }
}
