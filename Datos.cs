using System;

namespace Examen_Secure_User_Database
{
    class Datos
    {

        public string nombre;
        public string claveNum;
        public int id;


        public override string ToString()
        {
            return nombre + " - " + id + " - " + claveNum;
        }

        public string GetNombre()
        {
            return nombre;
        }
        public string GetClaveNum()
        {
            return claveNum;
        }

        public int GetId()
        {
            return id;
        }


    }
}