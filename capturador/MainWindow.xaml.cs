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

namespace capturador
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            // Llamar a clase screen
            Pantalla pt = new Pantalla();
            List<double> resolucion = pt.resolucion().ToList();
            texto.Content = resolucion[0] + " x " + resolucion[1];

            imagen.Source = pt.foto();

            pt.guarda();

        }
    }
}
