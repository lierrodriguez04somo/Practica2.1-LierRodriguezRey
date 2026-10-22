using System;
using System.IO;

public class Program
{
    public static string fichero = "";

    public static void Main()
    {
        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("1. Crear un nuevo fichero");
            Console.WriteLine("2. Añadir registros");
            Console.WriteLine("3. Eliminar todos los registros");
            Console.WriteLine("4. Eliminar el fichero");
            Console.WriteLine("5. Visualizar los registros");
            Console.WriteLine("6. Cerrar la aplicación");
            Console.WriteLine();
            Console.Write("Elige una opción: ");

            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CrearFichero();
                        break;

                    case 2:
                        AñadirRegistro();
                        break;

                    case 3:
                        EliminarRegistros();
                        break;

                    case 4:
                        EliminarFichero();
                        break;

                    case 5:
                        VisualizarRegistros();
                        break;

                    case 6:
                        Console.WriteLine("Aplicación cerrada.");
                        break;

                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                opcion = 0;
            }

            if (opcion != 6)
            {
                Console.WriteLine();
                Console.WriteLine("Pulsa una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 6);
    }


    public static void CrearFichero()
    {
        try
        {
            Console.Write("Introduce el nombre del fichero: ");
            string nombre = Console.ReadLine();

            fichero = nombre + ".txt";

            if (File.Exists(fichero))
            {
                Console.WriteLine("El fichero ya existe.");
            }
            else
            {
                FileStream archivo = File.Create(fichero);
                archivo.Close();

                Console.WriteLine("Fichero creado correctamente.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }


    public static void AñadirRegistro()
    {
        try
        {
            if (fichero == "")
            {
                Console.WriteLine("Primero debes crear un fichero.");
                return;
            }

            if (!File.Exists(fichero))
            {
                Console.WriteLine("El fichero no existe.");
                return;
            }

            Console.Write("Introduce el registro: ");
            string registro = Console.ReadLine();

            File.AppendAllText(fichero, registro + Environment.NewLine);

            Console.WriteLine("Registro añadido correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }


    public static void EliminarRegistros()
    {
        try
        {
            if (fichero == "")
            {
                Console.WriteLine("Primero debes crear un fichero.");
                return;
            }

            if (!File.Exists(fichero))
            {
                Console.WriteLine("El fichero no existe.");
                return;
            }

            File.WriteAllText(fichero, "");

            Console.WriteLine("Todos los registros han sido eliminados.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }


    public static void EliminarFichero()
    {
        try
        {
            if (fichero == "")
            {
                Console.WriteLine("Primero debes crear un fichero.");
                return;
            }

            if (File.Exists(fichero))
            {
                File.Delete(fichero);

                Console.WriteLine("Fichero eliminado correctamente.");

                fichero = "";
            }
            else
            {
                Console.WriteLine("El fichero no existe.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }


    public static void VisualizarRegistros()
    {
        try
        {
            if (fichero == "")
            {
                Console.WriteLine("Primero debes crear un fichero.");
                return;
            }

            if (!File.Exists(fichero))
            {
                Console.WriteLine("El fichero no existe.");
                return;
            }

            string[] registros = File.ReadAllLines(fichero);

            if (registros.Length == 0)
            {
                Console.WriteLine("El fichero está vacío.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(" REGISTROS ");

                for (int i = 0; i < registros.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + registros[i]);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}
