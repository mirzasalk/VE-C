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


namespace plivaci
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new UserControl1();
            Events.EventMenjanja += menjajFrame;
            Events.EventMenjanja2 += menjajFrame2;
        }

        private void menjajFrame(int p1,int p2,int p3)
        {
            MainFrame.Content = new UserControl2();
            Events.funkcijaPostavljanjeStilova(p1, p2, p3);

        }
        private void menjajFrame2()
        {
            MainFrame.Content = new UserControl1();

        }
    }
}
