using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Consultas
{
    internal class AccionesComunes
    {
        public static void Mensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void LlenarCombo(String consulta, ComboBox combo, string id, string campo)
        {
            DataTable dt;
            dt = Conexion.EjecutaSeleccion(consulta);

            DataRow r = dt.NewRow();
            r[0] = 0;
            r[1] = "Todos Los Datos";
            dt.Rows.InsertAt(r, 0);

            if (dt== null)
            {
                return;
            }
            combo.Items.Clear();
            combo.DataSource = dt;
            combo.ValueMember = id;
            combo.DisplayMember= campo;
        }
        public static void LlenarData (string consulta, DataGridView data)
        {
            DataTable dt;
            dt = Conexion.EjecutaSeleccion(consulta);
            if (dt == null)
            {
                return;
            }
            data.DataSource = dt;
        }
        public static void LlenarList(string consulta, ListView lista)
        {
            DataTable dt;
            dt = Conexion.EjecutaSeleccion(consulta);
            int columna = dt.Columns.Count;
            if (dt == null)
            {
                return;
            }
            lista.View = View.Details;
            foreach (DataColumn itemColumn in dt.Columns)
            {
                lista.Columns.Add(Convert.ToString(itemColumn));
            }
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem itemlist = new ListViewItem(Convert.ToString(row[0]));
                for (int i = 1; i < columna; i++)
                {
                    itemlist.SubItems.Add(Convert.ToString(row[i]));
                }
                lista.Items.Add(itemlist);
            }
        }
    }
    }

