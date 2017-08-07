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

        private void btnGrabar1_Click(object sender, RoutedEventArgs e)
        {
            string timeStamp =
                DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()
                + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            //string filename, int FrameRate, FourCC Encoder, int Quality)
            aux = new Recorder(new RecorderParams(
                                                    @"C:\Users\MiniNo\Documents\pruebas\G4u_" + timeStamp + ".avi",
                                                    Convert.ToInt32(tbFPS.Text),
                                                    SharpAvi.KnownFourCCs.Codecs.MotionJpeg,
                                                    //SharpAvi.KnownFourCCs.Codecs.MicrosoftMpeg4V2,
                                                    Convert.ToInt32(tbCalidad.Text)));
            //var rec
            //@"C:\Users\MiniNo\Documents\pruebas\prueba2.jpg"
            //"out.avi"
        }

        Recorder aux = null;

        private void btnParar_Click(object sender, RoutedEventArgs e)
        {


            // Finish Writing
            if (aux != null)
                aux.Dispose();

        }
    }
}
