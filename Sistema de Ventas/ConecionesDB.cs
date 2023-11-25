using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Ventas
{
    internal class ConeccionesDB
    {
        public MySqlConnection connection;
        public string connectionString;

        public ConeccionesDB()
        {

            connectionString = "server=localhost;port=3306;database=svd;user=root;password=";
            connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    Console.WriteLine("Conexión abierta exitosamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                    Console.WriteLine("Conexión cerrada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }


        public bool AuthenticateUser(string Nombre, string Password, out int userId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM usuario WHERE nombre = @Username AND password = @Password";
                string queryGetId = "SELECT idusuario FROM usuario WHERE nombre = @Username AND password = @Password";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", Nombre);
                    command.Parameters.AddWithValue("@Password", Password);

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {

                        using (MySqlCommand commandId = new MySqlCommand(queryGetId, connection))
                        {
                            commandId.Parameters.AddWithValue("@Username", Nombre);
                            commandId.Parameters.AddWithValue("@Password", Password);

                            userId = Convert.ToInt32(commandId.ExecuteScalar());
                        }

                        return true;
                    }
                    else
                    {
                        userId = -1;
                        return false;
                    }
                }
            }
        }

        public bool RegisterUser(string Nombre, string Cedula, string Password, string Telefono, string Email, string Direccion)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO usuario (idusuario, idrol, nombre, tipo_documento, num_documento, direccion, telefono, email, password, estado) VALUES (NULL, 1, @Nombre, Cedula, @Num_documento, @Direccion, @Telefono, @Email, @Password, 1)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Num_documento", Cedula);
                    command.Parameters.AddWithValue("@Direccion", Direccion);
                    command.Parameters.AddWithValue("@Telefono", Telefono);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al registrar el usuario: " + ex.Message);
                        return false;
                    }
                }
            }
        }



        public DataTable listado_articulo()
        {
            MySqlCommand cmd = new MySqlCommand("sp_listar_articulos", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int GetUserRole(int userId)
        {
            string query = "SELECT idrol FROM usuario WHERE idusuario = @UserId";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                int roleId = Convert.ToInt32(command.ExecuteScalar());
                return roleId;

            }
        }

        public DataTable GetCategories()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT idcategoria, nombre FROM categoria";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dt = new DataTable();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                    return dt;
                }
            }
        }

        public DataTable GetArticlesByCategory(int categoryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT idarticulo AS ID ,codigo as Codigo,nombre AS Nombre,precio_venta As Precio ,stock as Cantidad,descripcion as Descripción FROM articulo WHERE idcategoria = @CategoryId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    connection.Open();
                    DataTable dt = new DataTable();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                    return dt;
                }
            }
        }
        public Producto GetProductById(int productoId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT nombre, precio_venta, stock FROM articulo WHERE idarticulo = @ProductoId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductoId", productoId);

                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nombre = reader["nombre"].ToString();
                            decimal precio = Convert.ToDecimal(reader["precio_venta"]);
                            int stock = Convert.ToInt32(reader["stock"]);

                            return new Producto { Id = productoId, Nombre = nombre, Precio = precio, Stock = stock };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public bool UpdateStock(int productoId, int cantidad)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "UPDATE articulo SET stock = stock - @Cantidad WHERE idarticulo = @ProductoId";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Cantidad", cantidad);
                        command.Parameters.AddWithValue("@ProductoId", productoId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el stock: " + ex.Message);
                return false;
            }
        }

        public bool UpdateUserBalance(int userId, decimal total)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "UPDATE usuario SET Balance = Balance + @Total WHERE idusuario = @UserId";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Total", total);
                        command.Parameters.AddWithValue("@UserId", userId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Balance actualizado para el usuario {userId}. Nuevo balance: {total}");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"No se actualizaron registros para el usuario {userId}.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el balance: " + ex.Message);
                return false;
            }
        }
        public DataTable listado_Usuarios()
        {
            MySqlCommand cmd = new MySqlCommand("ObtenerUsuarios", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool ActualizarUsuario(int iduser, string Nombre, int rol, string Telefono, int Balance, string Direccion)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE usuario SET idrol = @rol, nombre = @Nombre, direccion = @Direccion, telefono = @Telefono, Balance = @Balance WHERE idusuario = @iduser ";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    if (!string.IsNullOrEmpty(Nombre))
                        command.Parameters.AddWithValue("@Nombre", Nombre);

                    command.Parameters.AddWithValue("@iduser", iduser);

                    if (!string.IsNullOrEmpty(Direccion))
                        command.Parameters.AddWithValue("@Direccion", Direccion);

                    if (!string.IsNullOrEmpty(Telefono))
                        command.Parameters.AddWithValue("@Telefono", Telefono);


                    if (Balance != 0)
                        command.Parameters.AddWithValue("@Balance", Balance);

                    if (rol != 0)
                        command.Parameters.AddWithValue("@rol", rol);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al Actualizar el usuario: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public bool EliminarUsuario(int iduser)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "DELETE FROM `usuario` WHERE idusuario = @Iduser";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Iduser", iduser);


                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al Eliminar el Usuario: " + ex.Message);
                return false;


            }

        }
        public bool InsertarArticulo(string nombre, int idCategoria, decimal precio, int Cantidad, string Codigo, string Descripcion)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO articulo (nombre, idcategoria,  precio_venta, codigo,stock,descripcion) VALUES (@Nombre, @IdCategoria, @Precio, @Codigo, @stock, @Decripcion)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@stock", Cantidad);
                    command.Parameters.AddWithValue("@Codigo", Codigo);
                    command.Parameters.AddWithValue("@Decripcion", Descripcion);
                    command.Parameters.AddWithValue("@IdCategoria", idCategoria);
                    command.Parameters.AddWithValue("@Precio", precio);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar el artículo: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public bool ActualizarArticulo(int idarticulo, string nombre, int idCategoria, decimal precio, int Cantidad, string Codigo, string Descripcion)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE articulo SET  nombre = @Nombre, codigo = @Codigo, idCategoria = @idCategoria, precio_venta= @precio, Descripcion = @Descripcion, stock = @Cantidad WHERE idarticulo = @idarticulo ";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {


                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@idarticulo", idarticulo);
                    command.Parameters.AddWithValue("@idCategoria", idCategoria);
                    command.Parameters.AddWithValue("@precio", precio);
                    command.Parameters.AddWithValue("@Cantidad", Cantidad);
                    command.Parameters.AddWithValue("@Codigo", Codigo);
                    command.Parameters.AddWithValue("@Descripcion", Descripcion);





                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al Actualizar el usuario: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public bool EliminarArticulo(int idarticulo)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "DELETE FROM `articulo` WHERE idarticulo = @idarticulo";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idarticulo", idarticulo);


                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al Eliminar el Articulo: " + ex.Message);
                return false;


            }
        }
    }

}