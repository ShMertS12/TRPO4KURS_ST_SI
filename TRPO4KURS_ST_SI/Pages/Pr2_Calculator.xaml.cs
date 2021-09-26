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
    /// Логика взаимодействия для Pr2_Calculator.xaml
    /// </summary>
    public partial class Pr2_Calculator : Page
    {
        string operation = "";
        string leftop = "";
        string rightop = "";

        public Pr2_Calculator()
        {
            InitializeComponent();
        }

        public void BUTCLICKS (object sender, RoutedEventArgs e)
        {
            string s = Convert.ToString(((Button)sender).Content);
            TEBL.Text += s;
            int num;
            bool result = Int32.TryParse(s, out num);

            if (TEBL.Text.Length == 30)
            {
                TEBL.FontSize = 20;
            }

            /*if (TEBL.FontSize == 20)
            {
                for (int i = 0; i < 5; i++)
                {
                    TEBL.FontSize += 5;
                    i = 0;
                }
            }*/

            if (result == true)
            {
                if (operation == "")
                {
                    leftop += s;
                }
                else
                {
                    rightop += s;
                }
            }
            else
            {
                if (s == "=")
                {
                    Update_Rightop();
                    TEBL.Text += rightop;
                    operation = "";
                }
                else if (s == "Стереть все")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    TEBL.Text = "";
                }
                else
                {
                    if(rightop != "")
                    {
                        Update_Rightop();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }

        public void Update_Rightop()
        {
            int num1 = Int32.Parse(leftop);
            int num2 = Int32.Parse(rightop);

            switch (operation)
            {
                case "+":
                    rightop=(num1 + num2).ToString();
                    break;
                case "-":
                    rightop=(num1 - num2).ToString();
                    break;
                case "*":
                    rightop=(num1 * num2).ToString();
                    break;
                case "/":
                    rightop=(num1 / num2).ToString();
                    break;
               
            }

           
        }

     

        private void CLBT_Click(object sender, RoutedEventArgs e)
        {
            TEBL.Text = "";
            TEBL.FontSize = 25;
        }

        private void EnterBut_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
