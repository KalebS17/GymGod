using Firebase.Database;
using Firebase.Database.Query;
using Gym.Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.App.Data.Services
{
    public class dsFireBase_Usuario
    {
        private string fireBase_URL = "https://demoprogra5-default-rtdb.firebaseio.com/";

        //metodo para obtener la lista de usuarios
        public List <cUsuario> GetUsuarios()
        {
            List<cUsuario> mlista = new List<cUsuario>();
            FirebaseClient firebaseDB = new FirebaseClient(fireBase_URL); //conexion a la base de datos en FireBase

            try
            {
                firebaseDB.Child("Usuarios") //nombre de la coleccion (tabla) en la base de datos
                  .AsObservable<cUsuario>()
                  .Subscribe(dato =>
                  {
                      if (dato.Object != null)
                      {
                          mlista.Add(dato.Object);
                      }
                  });
                return mlista;
            }
            catch (Exception ex)
            {
                return new List<cUsuario>();
            }

        }


        //metodo para agregar un usuario
        public bool addUsuario(cUsuario Usuario)
        {
            
            try
            {
                FirebaseClient firebaseDB = new FirebaseClient(fireBase_URL); //conexion a la base de datos en FireBase
                firebaseDB.Child("Usuarios").PostAsync(Usuario);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
