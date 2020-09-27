using System;
using System.Collections.Generic;
using System.Linq;

namespace Examen_Secure_User_Database
{
    class Program
    {
        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];

            arr[i] = arr[j];

            arr[j] = temp;
        }

        static void BubbleSort(int[] numbers)
        {

            for (int i = numbers.Length - 1; i > 0; i--)
            {

                for (int j = 0; j < i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        Swap(numbers, j, j + 1);
                    }
                }
            }
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.WriteLine(arr[i]);
            }
        }

        static void Main(string[] args)
        {

            bool verificarID = true;
            bool verificarClaveNum = false;


            int digitos = 0;
            int cantidasUsuarios = 1;

            int[] idArreglo;
            string claveNumArreglo = null;

            //string[] cadenaArreglo;
            //System.Console.WriteLine("Cantidad de usuarios: ");  //Cantidad de usarios a ingresar
            //cantidasUsuarios = Convert.ToInt32(Console.ReadLine());

            Datos[] arrayUsuario = new Datos[cantidasUsuarios];

            idArreglo = new int[cantidasUsuarios]; //Arreglo de Id

            for (int i = 0; i < arrayUsuario.Length; i++)
            {

                Datos objUsuario = new Datos(); //Objeto

                System.Console.WriteLine("Registro de usuario:");
                System.Console.WriteLine("");

                Console.WriteLine("Ingrese Nombre: ");
                objUsuario.nombre = Console.ReadLine();

                System.Console.WriteLine("Ingrese su número identificador: ");
                objUsuario.id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese su clave numérica: ");
                objUsuario.claveNum = Console.ReadLine();

                arrayUsuario[i] = objUsuario; //llenar arreglo de objetos
                idArreglo[i] = objUsuario.id;   //llenar arreglo con id
                claveNumArreglo = objUsuario.claveNum;

                digitos = (int)Math.Floor(Math.Log10(objUsuario.id) + 1); //Contar la cantidad de digitos de id

            }

            //Numeros separados por (,)

            string[] numClaveSplit = claveNumArreglo.Split(','); //separar por ,

            int[] nums = new int[numClaveSplit.Length];  //convertir a int

            for (int k = 0; k < numClaveSplit.Length; k++)
            {
                nums[k] = int.Parse(numClaveSplit[k]);
            }

            //Numeros Repetidos

            BubbleSort(nums);


            //Numeros repetidos de manera Adyacente

            for (int l = 1; l < nums.Length; l++)
            {
                int x = nums[l];

                int y = l - 1;

                if (y >= 0 && nums[y] == x)
                {
                    verificarClaveNum = true;
                }

                else if (y >= 0 && nums[y] != x)
                {
                    verificarClaveNum = false;
                }

            }

            //Verificar ID
            //inicien en 0
            //Verificar longitud de array

            char pad = '0';
            string cadena;

            foreach (int number in idArreglo)
            {
                cadena = Convert.ToString(number);
                string str = cadena.PadLeft(digitos * 2, pad);
                int tamañoStr = str.Length;  //Tamaño contando los 0 a la izq
                int tamañoCeros = tamañoStr / 2;

                if (tamañoStr >= 5 && tamañoStr % 2 == 0)
                {
                    string result = str.Substring(0, (tamañoStr / 2)); //guardar los 0
                    int cero = 0;


                    for (int i = 0; i < str.Length; i++)
                    {
                        switch (str[i])
                        {
                            case '0':
                                cero += 1;
                                break;
                        }

                        if (cero == tamañoCeros)
                        {
                            verificarID = true;
                            System.Console.WriteLine("1");
                        }

                        else if (cero != tamañoCeros)
                        {
                            verificarID = false;
                            System.Console.WriteLine("2");


                        }

                    }
                }
                else if (tamañoStr < 5 || tamañoStr % 2 != 0)
                {
                    verificarID = false;

                }
            }


            if (verificarID == true && verificarClaveNum == false)
            {
                for (int j = 0; j < arrayUsuario.Length; j++)
                {
                    System.Console.WriteLine(arrayUsuario[j].nombre + " - " + arrayUsuario[j].id + " - " + arrayUsuario[j].claveNum + " - Aceptado");
                }
            }

            else
            {
                for (int j = 0; j < arrayUsuario.Length; j++)
                {
                    System.Console.WriteLine(arrayUsuario[j].nombre + " - " + arrayUsuario[j].id + " - " + arrayUsuario[j].claveNum + " - Rechazado");
                }
            }


        }
    }
}
