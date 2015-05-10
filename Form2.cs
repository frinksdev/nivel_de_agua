using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NivelDeAgua
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public List<double> lista;

        public void setLista(List<double> lst)
        {
            this.lista = lst;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                double[] datos = lista.ToArray();

                Series serie = this.chart1.Series.Add("Litros de Agua");
                this.chart1.Titles.Add("Lectura de agua");

                for (int i = 0; i < datos.Length; i++)
                {
                    serie.Points.Add(datos[i]);
                    serie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                button1.Enabled = false;
        }
    }
}
