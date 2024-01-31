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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void ucitavanje(object sender, RoutedEventArgs e)
        {
            int p1 = 3;
            int p2 = 3;
            int p3 = 3;
                if (Plivac1.Text == "Plivac1" || Plivac2.Text == "Plivac2" || Plivac3.Text == "Plivac3" || ledjno1.IsChecked == false && prsno1.IsChecked == false && slobodniStil1.IsChecked == false || ledjno2.IsChecked == false && prsno2.IsChecked == false && slobodniStil2.IsChecked == false || ledjno3.IsChecked == false && prsno3.IsChecked == false && slobodniStil3.IsChecked == false)
                {
                    MessageBox.Show("unesite potrebne podatke");
                }
                else
                {

                if (ledjno1.IsChecked ==true)
                {
                    p1 = 8;
                }else if(prsno1.IsChecked ==true)
                        {
                    p1 = 6;
                }
                else
                {
                    p1 = 10;
                }



                if (ledjno2.IsChecked == true)
                {
                    p2 = 8;
                }
                else if (prsno2.IsChecked == true)
                {
                    p2 = 6;
                }
                else
                {
                    p2 = 10;
                }



                if (ledjno3.IsChecked == true)
                {
                    p3 = 8;
                }
                else if (prsno3.IsChecked == true)
                {
                    p3 = 6;
                }
                else
                {
                    p3 = 10;
                }

                
                Events.funkcijaMenjanja(p1,p2,p3);
            }
            
        }
    }
}
