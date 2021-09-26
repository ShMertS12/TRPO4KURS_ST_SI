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

namespace TRPO4KURS_ST_SI.Pages
{
    /// <summary>
    /// Логика взаимодействия для Regis.xaml
    /// </summary>
    public partial class Regis : Page
    {
        public Regis()
        {
            InitializeComponent();
            CBX.SelectedIndex = 0;
        }

        private void CancelBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Pr1());
        }

        /*private bool CheckLett(string S)
        {
            int i = 0;
            while (i != S.Length)
            {
                i++;
            }


            return true;
        }*/

        private void RegBut_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBLOGIN.Text) || string.IsNullOrEmpty(TBPASS.Password) || string.IsNullOrEmpty(TBPASSCORR.Password) || string.IsNullOrEmpty(TBFIO.Text))
            {
                MessageBox.Show("Введите недостоющие данные.");
            }
            if(TBPASS.Password.Length >= 6)
            {
                int numcount=0;
            for (int i = 0; i < TBPASS.Password.Length; i++)
            {
                switch (TBPASS.Password)
                {
                    case "0":
                        numcount++;
                        break;
                    case "1":
                        numcount++;
                        break;
                    case "2":
                        numcount++;
                        break;
                    case "3":
                        numcount++;
                        break;
                    case "4":
                        numcount++;
                        break;
                    case "5":
                        numcount++;
                        break;
                    case "6":
                        numcount++;
                        break;
                    case "7":
                        numcount++;
                        break;
                    case "8":
                        numcount++;
                        break;
                    case "9":
                        numcount++;
                        break;

                    default: break;

                }
            }
            }

            

        }
    }
}
