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
    public partial class EdArticulos : Form
    {
        public EdArticulos()
        {
            InitializeComponent();
        }

        private void EdArticulos_Load(object sender, EventArgs e)
        {
            Listar_articulo();
            FillCategoryComboBox();
        }
      
        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox4.Text;
            string codigo = textBox3.Text;
            string descripcion = textBox7.Text;
            int cantidad = Convert.ToInt32(textBox5.Text);
            int idCategoria = (int)comboBox1.SelectedValue;
            decimal precio = Convert.ToDecimal(textBox6.Text);

            bool insertado = art.InsertarArticulo(nombre, idCategoria, precio, cantidad , codigo, descripcion);

            if (insertado)
            {
                MessageBox.Show("Artículo insertado correctamente.");
                Listar_articulo();
            }
            else
            {
                MessageBox.Show("Error al insertar el artículo.");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idarticulo = Convert.ToInt32(textBox1.Text);
            string nombre = textBox4.Text;
            string codigo = textBox3.Text;
            string descripcion = textBox7.Text;
            int cantidad = Convert.ToInt32(textBox5.Text);
            int idCategoria = (int)comboBox1.SelectedValue;
            decimal precio = Convert.ToDecimal(textBox6.Text);

            bool Actualizado = art.ActualizarArticulo(idarticulo,nombre, idCategoria, precio, cantidad, codigo, descripcion);

            if (Actualizado)
            {
                MessageBox.Show("Artículo Actualizado correctamente.");
                Listar_articulo();
            }
            else
            {
                MessageBox.Show("Error al Actualizar el artículo.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idarticulo = Convert.ToInt32(textBox1.Text);

            art.EliminarArticulo(idarticulo);

            MessageBox.Show("Artículo Eliminado correctamente.");
            Listar_articulo();

        }

        ConeccionesDB art = new ConeccionesDB();
        ConeccionesDB conexionDB = new ConeccionesDB();
        private void FillCategoryComboBox()
        {
            DataTable categories = conexionDB.GetCategories();
            comboBox1.DataSource = categories;
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "idcategoria";
        }
        void Listar_articulo()
        {
            DataTable dt = art.listado_articulo();
            dataGridView1.DataSource = dt;

        }
    }
}
