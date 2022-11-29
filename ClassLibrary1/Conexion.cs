using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {

        SqlConnection Con;

        public Conexion()
        {
            Con = new SqlConnection("server=LAPTOP-FVNF2VL9 ; database=PruebaTecnica ; integrated security = true");

        }

        public SqlConnection AbrirBaseDatos()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();
            return Con;

        }
        public SqlConnection CerrarBaseDatos()
        {
            if (Con.State == ConnectionState.Open)
                Con.Close();
            return Con;
        }


    }





}
