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
using System.ComponentModel;
using System.Net.Http;
using Microsoft.Build.Tasks;


namespace PruebaTecnicaWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly object message;

        public MainWindow()
        {
            InitializeComponent();

        }

       

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient users = new HttpClient())
            {
                var respuesta = await users.GetAsync("https://api.github.com/users");
                respuesta.EnsureSuccessStatusCode();
               
                if (respuesta.IsSuccessStatusCode)
                {
                      await respuesta.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine("Error "+ respuesta.StatusCode);
                }
            }
        }
    }
}
