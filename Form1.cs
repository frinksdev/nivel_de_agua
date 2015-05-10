using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NivelDeAgua
{
    public partial class Form1 : Form
    {

        arduino ardu = new arduino();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ardu.Conectar((String)textBox1.Text);
                panel1.Enabled = true;
                label3.ForeColor = System.Drawing.Color.Green;
                label3.Text = "Conectado";

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar a dispositivo","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            ardu.Desconectar();
            label3.ForeColor = System.Drawing.Color.Red;
            label3.Text = "Desconectado";
            button5.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.Blue;
            label3.Text = "Leyendo...";
            ardu.p1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.Blue;
            label3.Text = "Captura detenida";
            ardu.detener();
            button5.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.setLista(ardu.getLectura());
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desarrollado por: Francisco Ortega Design & Development","Acerca de",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

    }
}
