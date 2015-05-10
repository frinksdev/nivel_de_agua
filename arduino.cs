using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NivelDeAgua
{
    class arduino
    {
        static SerialPort ardu;

        public static Boolean ciclo = true;

        public static List<double> lectura=new List<double>();

        public Thread p1 = new Thread(new ThreadStart(lecturas));

        public void Conectar(String disp)
        {
            ardu = new SerialPort(disp, 9600);
            ardu.Open();
        }

        public static void lecturas()
        {
            while (ciclo!=false)
            {
                lectura.Add(Convert.ToDouble(leerDatos()));
            }
        }

        private static String leerDatos()
        {
            String dato =ardu.ReadLine();
            return dato;
        }

        public List<double> getLectura()
        {
            return lectura;
        }

        public void Desconectar()
        {
            ardu.Close();
        }

        public void detener()
        {
            ciclo = false;
        }
    }
}
