using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace capturador
{
    /*
     * Clase para realizar captura de pantalla y guardarla 
     * sMedina 'santiagovalentin88@gmail.com'
     * V. inicial: 04/08/2017
     * 
     * Última edición: 07/08/2017
     */

    class Pantalla 
    {
        // Resolución de pantalla
        public double ancho, alto;

        // Captura de pantalla
        private BitmapSource img = null;


        // Constructor
        public Pantalla()
        {
            ancho = 0;
            alto = 0;
        }


        // Obtener la resolución de la pantalla primaria
        public List<double> resolucion()
        {
            alto = SystemParameters.PrimaryScreenHeight;
            ancho = SystemParameters.PrimaryScreenWidth;

            return new List<double> { alto, ancho };
        }


        // Realizar la captura y devolver un bitmapsource
        public BitmapSource foto()
        {
            // realiza una captura

            using (var screenBmp = new Bitmap((int)SystemParameters.PrimaryScreenWidth, (int)SystemParameters.PrimaryScreenHeight,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                using (var bmpGraphics = Graphics.FromImage(screenBmp))
                {
                    bmpGraphics.CopyFromScreen(0, 0, 0, 0, screenBmp.Size);
                    img = Imaging.CreateBitmapSourceFromHBitmap(
                                                               screenBmp.GetHbitmap(),
                                                               IntPtr.Zero,
                                                               Int32Rect.Empty,
                                                               BitmapSizeOptions.FromEmptyOptions()
                                                               );


                    return img;
                }
            }
        }


        // Convertir la captura en JPEG y guardarla
        public bool guarda()
        {
            Bitmap bMap;

            try
            {
                // Comprobamos que se realizase una captura
                if (img != null)
                {
                    using (var fileStream = new FileStream(@"C:\Users\MiniNo\Documents\pruebas\prueba2.jpg", FileMode.Create))
                    {
                        BitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(img));
                        encoder.Save(fileStream);

                        return true;
                    }
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        
    }
}
