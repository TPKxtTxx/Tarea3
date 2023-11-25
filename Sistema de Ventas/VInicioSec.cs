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
    public partial class VInicioSec : Form
    {
        public VInicioSec()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConeccionesDB Auto = new ConeccionesDB();

            string Nombre = textBox1.Text;
            string Password = textBox2.Text;

            if (Auto.AuthenticateUser(Nombre, Password, out int userId))
            {
                MessageBox.Show("Inicio de sesión exitoso.");

                VGeneral Gnera = new VGeneral(userId);


                Gnera.Show();


                this.Hide();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
            }
        

  
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            VRegistro regis = new VRegistro();


            regis.Show();


            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }
    }
}
