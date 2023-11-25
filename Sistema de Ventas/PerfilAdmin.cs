﻿using MySql.Data.MySqlClient;
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
    public partial class PerfilAdmin : Form
    {
        private int userId;
        private ConeccionesDB conexionesDB;
        public PerfilAdmin(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            conexionesDB = new ConeccionesDB();
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void PerfilAdmin_Load(object sender, EventArgs e)
        {
            string query = "SELECT nombre, telefono, email, Balance FROM usuario WHERE idusuario = @idusuario";

            using (MySqlConnection connection = new MySqlConnection(conexionesDB.connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idusuario", userId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nombre = reader["nombre"].ToString();
                            string telefono = reader["telefono"].ToString();
                            string email = reader["email"].ToString();
                            string balance = reader["Balance"].ToString();

                            label6.Text = nombre;
                            label8.Text = telefono;
                            label9.Text = email;
                            label10.Text = balance;


                        }
                        else
                        {

                        }
                    }
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            EdUsuarios us = new EdUsuarios();

            us.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EdArticulos ar = new EdArticulos();

            ar.Show();

            this.Hide();
        }
    }
}
