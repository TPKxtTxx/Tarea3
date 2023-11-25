using MySql.Data.MySqlClient;
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
    public partial class VGeneral : Form
    {
        
       
        private int userId;

        ConeccionesDB conexionDB = new ConeccionesDB();
        public VGeneral(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        

        private void VGeneral_Load(object sender, EventArgs e)
        {
            Listar_articulo();
            FillCategoryComboBox();

        }


        private void button1_Click(object sender, EventArgs e)
        {
           VInicioSec Inic = new VInicioSec();


            Inic.Show();


            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int userRole = conexionDB.GetUserRole(userId);

            if (userRole == 1)
            {
              
                PerfilUs perfil = new PerfilUs(userId);
                perfil.Show();
            }
            else if (userRole == 3)
            {

                PerfilAdmin perfilAdmin = new PerfilAdmin(userId);
                perfilAdmin.Show();
            }
            conexionDB.CloseConnection();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int productoId))
            {
                Producto producto = conexionDB.GetProductById(productoId);

                if (producto != null)
                {
                    int cantidadSeleccionada = (int)numericUpDown1.Value;
                    ComfirmaCompra confirmarCompra = new ComfirmaCompra(producto, cantidadSeleccionada);
                    confirmarCompra.ShowDialog();

                    if (confirmarCompra.CompraConfirmada)
                    {
                        bool stockUpdated = conexionDB.UpdateStock(productoId, cantidadSeleccionada);
                        bool balanceUpdated = conexionDB.UpdateUserBalance(userId, confirmarCompra.Total);

                        if (stockUpdated && balanceUpdated)
                        {
                            Listar_articulo();

                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar el stock o el balance.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Producto no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID de producto válido.");
            }
        }





        ConeccionesDB art = new ConeccionesDB();
        void Listar_articulo()
        {
            DataTable dt = art.listado_articulo();
            dataGridView1.DataSource = dt;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Listar_articulo();
        }
        private void FillCategoryComboBox()
        {
            DataTable categories = conexionDB.GetCategories(); 
            comboBox1.DataSource = categories;
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "idcategoria";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                int categoryId = Convert.ToInt32(comboBox1.SelectedValue);
                UpdateDataGridView(categoryId);
            }
        }
        private void UpdateDataGridView(int categoryId)
        {
            DataTable dt = art.GetArticlesByCategory(categoryId); 
            dataGridView1.DataSource = dt;
        }
    }
}

