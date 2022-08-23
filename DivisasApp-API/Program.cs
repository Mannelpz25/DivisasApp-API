/* ---------- Ayuda!! ----------
*    Caso de estudio. Evidencia de aprendizaje
*/
//-Importaciones:
using RestSharp;
using Newtonsoft.Json;
using System;
using modelo; // Modelo de la response de la API
using menus; // importación para menús interactivos
//-Contenido:
class Program
{
    // Método para consultar API y realizar el cambio de divisa
    static Root cambioDivisaAPI(string divisaBase, string divisaCambio, double montoACambiar){
        var client = new RestClient("https://api.apilayer.com/exchangerates_data/convert"); //URL de la API        
        RestRequest request = new RestRequest();
        request.AddParameter("from",divisaBase); // Se agrega el parámetro from con la divisa base       
        request.AddParameter("to",divisaCambio); // Se agrega el parámetro to con la divisa de cambio 
        request.AddParameter("amount",montoACambiar); // Se agrega el parámetro amount con el monto a cambiar 
        request.AddHeader("apikey", "3pXSyZ8O0C07liPcjUM57O0KDy99W8As");//Se añade en el header de la consulta la APIKey
        var response = client.Execute(request);
        Root respuesta = JsonConvert.DeserializeObject<Root>(response.Content); // Se deserializa el JSON de la response y se asigna al objeto Root
        return respuesta; // Se retorna el objeto de la clase Root
    }

    // Método para calcular comisión
    static double calcularComision(double montoFinal){
        return (montoFinal * .05); // se retorna el 5% del monto final
    }
    // Método para mostrar resultado
    static void infoTransaccion(string divisaBase, string divisaCambio, double montoACambiar, double montoFinal, double comision, int timestamp){
        // Se crea una variable de tipo DateTime para la hora de la transacción
        DateTime horaTransaccion = new DateTime();
        // Se le asigna la hora a partir del timestamp de la API y se llama al método ToLocalTime para convertirlo a la zona horaria actual
        horaTransaccion = horaTransaccion.AddSeconds(timestamp).ToLocalTime();        
        Console.ForegroundColor = ConsoleColor.DarkBlue; // Cambia el color del texto
        Console.WriteLine("- Información de la transacción: \n");
        Console.ForegroundColor = ConsoleColor.DarkGreen; // Cambia el color del texto
        Console.WriteLine("Divisa base: $" + montoACambiar.ToString("N2") + " " + divisaBase);
        Console.WriteLine("Divisa de cambio: $" + montoFinal.ToString("N2") + " " + divisaCambio);
        Console.WriteLine("Comisión: $" + comision.ToString("N2") + " " + divisaCambio);
        Console.WriteLine("Hora de transacción: " + horaTransaccion.ToString("hh:mm:ss"));
    }

    // Método Main principal
    static void Main(string[] args)
    {
        // Creación de variables
        Root respuesta = new Root();
        string titulo = "----- E L   C O N V E R S O R -----";
        string divisaBase, divisaCambio;
        double comision;
        double montoACambiar, montoFinal;      
        
        // Se crea un arreglo con las opciones de nuestro menú interactivo
        string[] divisas = {
            "USD",
            "MXN",
            "EUR",
            "BTC"
        };

        // Se manda llamar nuestro menu, con titulo, indicación y opciones. El valor de retorno se asigna a la divisaBase
        divisaBase = Menu.menuToString(titulo,"? Divisa base:", divisas);

        // Se manda llamar nuestro menu, con titulo, indicación y opciones. El valor de retorno se asigna a la divisaCambio
        divisaCambio = Menu.menuToString(titulo,"? Divisa cambio:", divisas);


        //Se pide el monto a cambiar
        Console.Clear(); // Limpia la consola
        Console.ForegroundColor = ConsoleColor.DarkCyan; // Cambia el color del texto
        Console.WriteLine(titulo); 
        Console.ForegroundColor = ConsoleColor.DarkBlue; // Cambia el color del texto
        Console.WriteLine("? Monto a cambiar:");
        Console.ForegroundColor = ConsoleColor.Gray; // Cambia el color del texto
        montoACambiar = double.Parse(Console.ReadLine());// Se parsea a double lo que escribe el usuario para guardarla en la variable

        // Se realiza el cambio de divisa con una consulta a la API
        respuesta = cambioDivisaAPI(divisaBase, divisaCambio, montoACambiar); 
        montoFinal = respuesta.result; // se asigna el resultado al montoFinal
        comision = calcularComision(montoFinal); // Se calcula la comisión a partir del montoFinal


        //Se muestran los resultados
        Console.Clear(); // Limpia la consola
        Console.ForegroundColor = ConsoleColor.DarkCyan; // Cambia el color del texto
        Console.WriteLine(titulo);
        // Se llama al método que se encarga de mostrar todos los resultados
        infoTransaccion(divisaBase, divisaCambio, montoACambiar, montoFinal, comision, respuesta.info.timestamp);
        Console.ForegroundColor = ConsoleColor.Gray; // Cambia el color del texto
        // Se pausa el programa en espera de que se pulse cualquier tecla para finalizarlo
        Console.ReadKey();
    }
}