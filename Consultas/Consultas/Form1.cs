using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Registros = 0;
            Conexion.EjecutaConsulta(textBox1.Text);
            AccionesComunes.Mensaje("" + Registros);
            AccionesComunes.LlenarCombo(textBox1.Text, comboBox1, "id_Cliente", "Nombre_Cliente");
            AccionesComunes.LlenarData(textBox1.Text, dataGridView1);
            AccionesComunes.LlenarList(textBox1.Text, listView1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedValue.ToString();
        }
    }
}
