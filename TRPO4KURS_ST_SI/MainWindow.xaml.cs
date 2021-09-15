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
                    Console.WriteLine(usya.Roles.Role + " " + usya.Roles.ID);
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
            if(page is Pages.Pr1)
            {
                ButBack.Visibility = Visibility.Hidden;
            }
            else
            {
                ButBack.Visibility = Visibility.Visible;
            }
        }
    }
}
