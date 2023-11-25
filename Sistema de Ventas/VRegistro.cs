using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Sistema_de_Ventas
{
    public partial class VRegistro : Form
    {
        public VRegistro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConeccionesDB regis = new ConeccionesDB();

            string Nombre = textBox1.Text;
            string password = textBox5.Text;
            string Cedula = textBox6.Text;
            string Telefono = textBox3.Text;
            string Email = textBox3.Text;
            string Direccion = textBox2.Text;

            ConeccionesDB db = new ConeccionesDB();
            db.OpenConnection();

            bool registrado = db.RegisterUser(Nombre, Cedula, password, Telefono, Email, Direccion);

            db.CloseConnection();

            if (registrado)
            {
                MessageBox.Show("El usuario se registró exitosamente.");
                VInicioSec Inic = new VInicioSec();


                Inic.Show();


                this.Hide();
            }
            else
            {
                MessageBox.Show("Error al registrar el usuario .");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VInicioSec Inic = new VInicioSec();


            Inic.Show();


            this.Hide();
        }
    }
}
