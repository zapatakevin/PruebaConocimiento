using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;
using Z.Expressions;
using System.Linq;

namespace Negocio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceUsuario" en el código y en el archivo de configuración a la vez.
    public class ServiceUsuario : IServiceUsuario
    {
        Conexion objconect = new Conexion();

        public List<Persona> GetUsuarios()
        {
            List<Persona> UsuarioList = new List<Persona>();
            DataTable resourceTable = new DataTable();
            SqlDataReader resultReader = null;
            SqlCommand command = new SqlCommand("Sp_GetUsuario", objconect.AbrirBaseDatos());
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                objconect.AbrirBaseDatos();
                resultReader = command.ExecuteReader();
                resourceTable.Load(resultReader);
                resultReader.Close();
                objconect.CerrarBaseDatos();
                UsuarioList = (from DataRow dr in resourceTable.Rows
                               select new Persona()
                               {
                                   Id = Convert.ToInt32(dr["ID"]),
                                   Nombre = dr["Nombre"].ToString(),
                                   FechaNacimiento = Convert.ToDateTime(dr["Fecha"]),
                                   Sexo = Convert.ToChar(dr["Sexo"]),
                               }).ToList();
            }
            catch (Exception)
            {
    
                    resultReader.Close();
                    objconect.CerrarBaseDatos();
                
                
            }
            return UsuarioList;
        }

        public string InsertUsuario(string Nombre , DateTime Fecha, char Sexo)
        {
            string Status;
            SqlCommand cmd = new SqlCommand("SP_InsertUsuario", objconect.AbrirBaseDatos());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            cmd.Parameters.AddWithValue("@Fecha", Fecha);
            cmd.Parameters.AddWithValue("@Sexo", Sexo);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Status = Nombre + " " + Fecha + " registered successfully";
            }
            else
            {
                Status = Nombre + " " + Fecha + " could not be registered";
            }
            objconect.CerrarBaseDatos();
            return Status;
           
        }
        public DataSet ReadUsuario(int id)
        {
            SqlCommand cmd = new SqlCommand("Sp_ReadUsuario", objconect.AbrirBaseDatos());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            objconect.AbrirBaseDatos();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            objconect.CerrarBaseDatos();
            return ds;
        }
        public string UpdateUsuario(int id,string Nombre, DateTime Fecha, char Sexo)
        {
            string Status;
            SqlCommand cmd = new SqlCommand("Sp_UpdateUsuario", objconect.AbrirBaseDatos());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            cmd.Parameters.AddWithValue("@Fecha", Fecha);
            cmd.Parameters.AddWithValue("@Sexo", Sexo);
            objconect.AbrirBaseDatos();
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Status = "Record updated successfully";
            }
            else
            {
                Status = "Record could not be updated";
            }
            objconect.CerrarBaseDatos();
            return Status;
        }
        public bool DeleteUsuario(int id)
        {
            SqlCommand cmd = new SqlCommand("Sp_DeleteUsuario", objconect.AbrirBaseDatos());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            objconect.AbrirBaseDatos();
            cmd.ExecuteNonQuery();
            objconect.CerrarBaseDatos();
            return true;
        }
    }
}
