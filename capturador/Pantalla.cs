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
    class Pantalla 
    {
        public double ancho, alto;
        private BitmapSource img;

        public Pantalla()
        {
            ancho = 0;
            alto = 0;
        }

        public List<double> resolucion()
        {
            alto = SystemParameters.PrimaryScreenHeight;
            ancho = SystemParameters.PrimaryScreenWidth;

            return new List<double> { alto, ancho };
        }

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

        public void guarda()
        {
            Bitmap bMap;

            try
            {
                using (var fileStream = new FileStream(@"C:\Users\MiniNo\Documents\pruebas\prueba2.jpg", FileMode.Create))
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(img));
                    encoder.Save(fileStream);
                }

            }
            catch (Exception ex)
            { }
        }


        
    }
}
