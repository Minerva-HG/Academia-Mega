using System;
using System.Text;

class Program
{
    private static Dictionary<string, string> usuarios = new Dictionary<string, string>
    {
        {"admin", "qwerty"},
        {"usuario", "pass"},
        {"test", "test"}
    };

    private const int MAX_ATTEMPTS = 3;

    static void Main(string[] args)
    {
        //Mensaje de Bienvenida
        Console.WriteLine("Este es el programa oficial de Hola Mundo");
        Console.WriteLine("Tienes que iniciar sesión");

        Console.WriteLine("Escribe tu usuario");
        string? usuarioIngresado = TryLogin();

        if(usuarioIngresado != null)
        {
            Console.WriteLine($"\nHola {usuarioIngresado}");
        }
        else
        {
            Console.WriteLine("Has excedido el número máximo de intentos");
        }

        Console.WriteLine("Presiona Enter para salir...");
        Console.ReadLine();
    }

    /*
    TODO
        Número máximo de intentos
        Lea la contraseña sin mostrarla
        Mostrar info del usuario loggeado
    */
    private static string? TryLogin()
    {  
        int intentosRestantes = MAX_ATTEMPTS;

        while(intentosRestantes > 0)
        {
            Console.WriteLine($"\nIntentos restantes: {intentosRestantes}");
            Console.WriteLine("Ingresa tu nombre de usuario");
            string ? userLogged = Console.ReadLine();

            Console.WriteLine("Escribe tu contraseña");
            string? passIngresada = ReadPassword();

            if (string.IsNullOrWhiteSpace(userLogged) || string.IsNullOrWhiteSpace(passIngresada))
            {
                Console.WriteLine("\nError: El usuario y contraseña no pueden estar vacíos");
                intentosRestantes --;
                continue;
            }

            if(userLogged != null)
            {
                //if (usuarioIngresado == usuarioCorrecto && passIngresada == passCorrecta)
                if (usuarios.ContainsKey(userLogged) && usuarios[userLogged] == passIngresada)
                {
                    Console.WriteLine("\nAcceso concedido!!!");
                    return userLogged;
                } 
                else
                {
                    Console.WriteLine("Contraseña y/o Usuario incorrectos");
                    Console.WriteLine("\n Intentalo de nuevo..."); //\n Es para salto de linea
                    intentosRestantes --;
                }
            }
        }
        return null;
    }
    private static string ReadPassword()
    {
        StringBuilder password = new StringBuilder();
        ConsoleKeyInfo keyInfo;

        do
        {
            keyInfo = Console.ReadKey(true);

            if(!char.IsControl(keyInfo.KeyChar))
            {
                password.Append(keyInfo.KeyChar);
                Console.Write("*");
            }
            else if(keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password.Remove(password.Length - 1, 1);
                Console.Write("\b \b"); // \b Es para volver un espacio atrás
            }
        }
        while(keyInfo.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password.ToString();

    }
}