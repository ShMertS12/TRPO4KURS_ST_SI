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
            Console.WriteLine($"{CBX.SelectedValue.ToString()} типа {CBX.SelectedValue.ToString().GetType()} (SelectedValue.ToString)");
            Console.WriteLine(CBX.SelectedValue.ToString().Contains("Пользователь"));
            Console.WriteLine(CBX.SelectedItem.ToString().Contains("Пользователь"));
            Console.WriteLine(CBX.SelectedItem.ToString() == "System.Windows.Controls.ComboBoxItem: Пользователь");
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

            if (!(string.IsNullOrEmpty(TBLOGIN.Text) || string.IsNullOrEmpty(TBPASS.Password)
                || string.IsNullOrEmpty(TBPASSCORR.Password) || string.IsNullOrEmpty(TBFIO.Text)))
            {
                if (TBPASS.Password.Length >= 6)
                {
                    int numcount = 0;
                    for (int i = 0; i < TBPASS.Password.Length; i++)
                    {
                        switch (TBPASS.Password[i])
                        {
                            case '0':
                                numcount++;
                                break;
                            case '1':
                                numcount++;
                                break;
                            case '2':
                                numcount++;
                                break;
                            case '3':
                                numcount++;
                                break;
                            case '4':
                                numcount++;
                                break;
                            case '5':
                                numcount++;
                                break;
                            case '6':
                                numcount++;
                                break;
                            case '7':
                                numcount++;
                                break;
                            case '8':
                                numcount++;
                                break;
                            case '9':
                                numcount++;
                                break;

                            default:
                                break;

                        }
                    }
                    if (numcount == 0)
                        MessageBox.Show("Нужно ввести хотя бы одну цифру");

                    else
                    {
                        int lettercount = 0;
                        for (int i = 0; i < TBPASS.Password.Length; i++)
                        {

                            if (char.IsLetter(TBPASS.Password[i]))
                            {
                                lettercount++;

                            }
                        }
                        if (lettercount < 3)
                            MessageBox.Show("Пароль должен содержать минимум 3 буквы");

                        else if (TBPASS.Password != TBPASSCORR.Password)
                            MessageBox.Show("Пароли не совпадают");

                        else
                        {
                            SAVSAA_Material_storageEntities1 db = new SAVSAA_Material_storageEntities1();

                            Users userobject = new Users
                            {
                                FIO = TBFIO.Text,
                                Login = TBLOGIN.Text,
                                Password = TBPASS.Password,
                            };
                            /*
                            //CBX.SelectedValue.ToString();
                            switch (CBX.SelectedIndex)
                            {
                                case 1:
                                    userobject.RoleID = 1;
                                    db.Users.Add(userobject);
                                    db.SaveChanges();
                                    MessageBox.Show("Пользователь зарегистрирован!");
                                    NavigationService.GoBack();
                                    break;
                                case 0:
                                    userobject.RoleID = 2;
                                    db.Users.Add(userobject);
                                    db.SaveChanges();
                                    MessageBox.Show("Пользователь зарегистрирован!");
                                    NavigationService.GoBack();
                                    break;

                                default: break;
                            }
                            */

                            switch (CBX.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""))
                            {
                                case "Администратор":
                                    userobject.RoleID = 1;
                                    db.Users.Add(userobject);
                                    db.SaveChanges();
                                    MessageBox.Show("Пользователь зарегистрирован!");
                                    NavigationService.Navigate(new Pr1());
                                    break;
                                case "Пользователь":
                                    userobject.RoleID = 2;
                                    db.Users.Add(userobject);
                                    db.SaveChanges();
                                    MessageBox.Show("Пользователь зарегистрирован!");
                                    NavigationService.Navigate(new Pr1());
                                    break;

                                default: break;
                            }
                            //List<Users> allUsers = Core.BD.Users.ToList();
                            //allUsers[0].Role;



                        }
                    }
                }
                else
                    MessageBox.Show("Пароль должен быть не менее 6 символов");
            }
            else MessageBox.Show("Введите недостоющие данные.");

        }


    }
}