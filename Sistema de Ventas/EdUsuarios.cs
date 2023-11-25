using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Ventas
{
    public partial class EdUsuarios : Form
    {
        public EdUsuarios()
        {
            InitializeComponent();
            listado_Usuarios();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        ConeccionesDB art = new ConeccionesDB();

        void listado_Usuarios()
        {
            DataTable dt = art.listado_Usuarios();
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iduser = Convert.ToInt32(textBox1.Text);
            int rol = Convert.ToInt32(textBox2.Text);
            string Nombre = textBox3.Text;
            string  Telefono= textBox5.Text;
            int Balance = Convert.ToInt32(textBox6.Text);
            string Direccion = textBox4.Text;

            art.ActualizarUsuario( iduser, Nombre,   rol,  Telefono,  Balance,  Direccion);


            listado_Usuarios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int iduser = Convert.ToInt32(textBox1.Text);
            art.EliminarUsuario(iduser);

            MessageBox.Show("Usuario eliminado Correctamente");

            listado_Usuarios();
        }

        private void EdUsuarios_Load(object sender, EventArgs e)
        {

        }
       
        private void button3_Click(object sender, EventArgs e)
        {
          

            this.Hide();
        }
    }
}
