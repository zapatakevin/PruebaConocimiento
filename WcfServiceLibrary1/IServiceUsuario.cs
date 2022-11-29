using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Datos;

namespace Negocio
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.

    [ServiceContract]
    public interface IServiceUsuario
    {
      
        [OperationContract]
        string InsertUsuario(string Nombre, DateTime FechaNacimiento, char Sexo);

        [OperationContract]
        List<Persona> GetUsuarios();

        [OperationContract]
        DataSet ReadUsuario(int id);

        [OperationContract]
        string UpdateUsuario(int id, string Nombre, DateTime Fecha, char Sexo);

        [OperationContract]
        bool DeleteUsuario(int id);
    }
   
}
