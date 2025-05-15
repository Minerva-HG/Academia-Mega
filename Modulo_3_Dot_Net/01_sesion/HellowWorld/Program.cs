// mi primer programa en C#
//Actual
using System;

class Program
{
    private static Dictionary<string, string> usuarios = new Dictionary<string, string>
    {
        {"admin", "qwerty"},
        {"usuario", "pass"},
        {"test", "test"}
    };

    static void Main(string[] args)
    {
        //Mensaje de Bienvenida
        Console.WriteLine("Este es el programa oficial de Hola Mundo");
        Console.WriteLine("Tienes que iniciar sesión");

        //Definir el usuario y la contraseña
        //string usuarioCorrecto = "admin";
        //String passCorrecta = "qwerty";

        Console.WriteLine("Escribe tu usuario");
        string? usuarioIngresado = Console.ReadLine();
        Console.WriteLine("Escribe tu contraseña");
        string? passIngresada = Console.ReadLine();

        if(usuarioIngresado == null)
        {
            usuarioIngresado = "";
        }

        if(passIngresada == null)
        {
            passIngresada = "";
        }

        //if (usuarioIngresado == usuarioCorrecto && passIngresada == passCorrecta)
        if (usuarios.ContainsKey(usuarioIngresado) && usuarios[usuarioIngresado] == passIngresada)
        {
            Console.WriteLine("Has ingresado con éxito");
            for(int i = 1; i<=50; i++)
            {
                Console.WriteLine($"{i}. ¡¡¡Hola Usuario, gracias!!!");
            }
            Console.WriteLine("\n Presiona enter para salir del programa...");
            Console.ReadLine();
        } 
        else
        {
            Console.WriteLine("Contraseña y/o Usuario incorrectos");
            Console.WriteLine("\n Presiona enter para salir del programa...");
            Console.ReadLine();
        }
    }
}