using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TRPO4KURS_ST_SI.Pages;

namespace TRPO4KURS_ST_SI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            using (var db = new SAVSAA_Material_storageEntities1())
            {
                var users = db.Users.AsNoTracking().ToList();
                foreach (var usya in users)
                {
                    Console.WriteLine(usya.Role.Title + " " + usya.Role.ID);
                }
                
            }
            using (var db = new SAVSAA_Material_storageEntities1())
            {
                var users = db.Users.AsNoTracking().Where(u => u.Login.StartsWith("B")).ToList();
                
            }
        }

       

        private void ButBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page)) return;
            this.Title = $"Lesson - {page.Title}";
            if(page is Pages.Pr1 || page is Pages.Regis)
            {
                ButBack.Visibility = Visibility.Collapsed ;
                ButCal.Visibility = Visibility.Collapsed;
            }
            else
            {
                ButBack.Visibility = Visibility.Visible;
                ButCal.Visibility = Visibility.Visible;
            }
        }

        private void ButCal_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pr2_Calculator());
        }

       


        private void ButEx_Click(object sender, RoutedEventArgs e)
        {
            /*string path = "export.txt";*/
            

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            StreamWriter sw = new StreamWriter(sfd.FileName);

            using (var db = new SAVSAA_Material_storageEntities1())
            {
                string IDline = string.Join(", ", db.Users.Select(x => x.ID));
                string FIOline = string.Join(", ", db.Users.Select(x => x.FIO));
                string LOGline = string.Join(", ", db.Users.Select(x => x.Login));
                string PASSline = string.Join(", ", db.Users.Select(x => x.Password));
                string RoleIDline = string.Join(", ", db.Users.Select(x => x.RoleID));
                sw.WriteLine("ID: " + IDline);
                sw.WriteLine("Fio: " + FIOline);
                sw.WriteLine("Login: " + LOGline);
                sw.WriteLine("Password: " + PASSline);
                sw.WriteLine("Role: " + RoleIDline);
                sw.Close();
                Process.Start("notepad.exe", sfd.FileName);
            }  
        }

        private void ButIm_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                while (!sr.EndOfStream)
                {
                    string[] lines = new string[5];
                    for (int i=0; i < 5; i++)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');
                        line = "";
                        if(data.Length >= 2)
                        {
                            for(int j=0; j < data.Length; j++)
                            {
                                line += data[j] + ", ";
                            }
                            lines[i] = line ;
                        }
                        
                    }
                    MessageBox.Show("Данные в файле: \nID: " + lines[0] + 
                        "\nФИО: " + lines[1] +  "\nЛогин: " + lines[2] +  "\nПароль: " +
                        lines[3] +  "\nРоль: " + lines[4]);
                }
            }
            else
                MessageBox.Show("Файл не выбран");
        }
    }
}
