using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Negocio
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceUsers1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceUsers1
    {
        [OperationContract]
        void DoWork();
    }
}
