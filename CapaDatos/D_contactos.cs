using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;
using System.Data;


namespace CapaDatos
{
    public class D_contactos
    {

       SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_contactos> ListarContactos(string buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCONTACTO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            leerFilas = cmd.ExecuteReader();
            List<E_contactos> Listar = new List<E_contactos>();
            while (leerFilas.Read())
            {
                Listar.Add(new E_contactos
                {
                    ID = leerFilas.GetInt32(0),
                    Nombres = leerFilas.GetString(1),
                    Apellidos = leerFilas.GetString(2),
                    Cedula = leerFilas.GetString(3),
                    Correo = leerFilas.GetString(4),
                    Telefono1 = leerFilas.GetString(5),
                    Telefono2 = leerFilas.GetString(6),
                    Direccion = leerFilas.GetString(7)

                });


            }
            conexion.Close();
            leerFilas.Close();
            return Listar;

        }



        public void insertarContacto(E_contactos contactos)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARCONTACTO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRES", contactos.Nombres);
            cmd.Parameters.AddWithValue("@APELLIDOS", contactos.Apellidos);
            cmd.Parameters.AddWithValue("@CEDULA", contactos.Cedula);
            cmd.Parameters.AddWithValue("@CORREO", contactos.Correo);
            cmd.Parameters.AddWithValue("@TELEFONO1", contactos.Telefono1);
            cmd.Parameters.AddWithValue("@TELEFONO2", contactos.Telefono2);
            cmd.Parameters.AddWithValue("@DIRECCION", contactos.Direccion);


            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public void EditarContacto(E_contactos contactos)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARCONTACTO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", contactos.ID);
            cmd.Parameters.AddWithValue("@NOMBRES", contactos.Nombres);
            cmd.Parameters.AddWithValue("@APELLIDOS", contactos.Apellidos);
            cmd.Parameters.AddWithValue("@CEDULA", contactos.Cedula);
            cmd.Parameters.AddWithValue("@CORREO", contactos.Correo);
            cmd.Parameters.AddWithValue("@TELEFONO1", contactos.Telefono1);
            cmd.Parameters.AddWithValue("@TELEFONO2", contactos.Telefono2);
            cmd.Parameters.AddWithValue("@DIRECCION", contactos.Direccion);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarContactos(E_contactos contactos)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCONTACTO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", contactos.ID);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}

