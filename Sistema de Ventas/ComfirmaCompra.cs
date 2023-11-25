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
    public partial class ComfirmaCompra : Form
    {
        public decimal Total { get; private set; }
        private int cantidadSeleccionada;

        public bool Confirmado { get; private set; }
        
        private int cantidad;
        private Producto producto;
        public bool CompraConfirmada { get; private set; }
        public ComfirmaCompra(Producto producto, int cantidadSeleccionada)
        {
            InitializeComponent();
            this.producto = producto;
            this.cantidadSeleccionada = cantidadSeleccionada;
            Total = producto.Precio * cantidadSeleccionada;
        }

       

        private void ComfirmaCompra_Load(object sender, EventArgs e)
        {
            decimal total = producto.Precio * cantidadSeleccionada;
            label5.Text = producto.Nombre;
            label6.Text = producto.Precio.ToString("C2");
            label7.Text = total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal total = producto.Precio * cantidadSeleccionada;
            

            CompraConfirmada = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Confirmado = false;
            Close();
        }
    }
}
