/* ---------- Ayuda!! ----------
*    Se muestra un menú interactivo que utiliza las teclas arriba y abajo para moverte en el menú,
*    la tecla Enter para seleccionar.
*    Para ello se utiliza un ciclo doWhile donde con un for y un variable opcionSelecionada que se aumenta
*    o disminuye según se pulsa abajo o arriba, se muestra el menu, cambiando de color la opción que 
*    se esta seleccionando. Este doWhile se repite hasta que se presione la tecla Enter
*/
//-Importaciones:
using System;

//-Contenido:

namespace menus
{
    class Menu{
        public Menu()
        {
            //constructor vació
        }
        // Método de menu con Titulo, indicación y arreglo de opciones, que devuelve el entero representando la posición 
        public static int menuToPosition(string titulo, string indicacion, string[] opciones){
            int opcionSeleccionada = 0;// Variable para guardar la opción del menú en que nos encontramos
            ConsoleKey key = new ConsoleKey(); // Variable para almacenar la tecla pulsada
            do{
                Console.Clear(); // Limpia la consola
                Console.ForegroundColor = ConsoleColor.DarkCyan; // Cambia el color del texto
                Console.WriteLine(titulo); 
                Console.ForegroundColor = ConsoleColor.DarkBlue; // Cambia el color del texto
                Console.WriteLine(indicacion);
                Console.ForegroundColor = ConsoleColor.DarkGray; // Cambia el color del texto
                Console.WriteLine("Utilize las flechas para moverse y pulse Enter para seleccionar... \n");
                // for que muestra las opciones poniendo de color blanco en donde se esta posicionado
                for(int x = 0 ; x < opciones.Length ; x++){
                    if(opcionSeleccionada == x){
                        Console.ForegroundColor = ConsoleColor.White; // Cambia el color del texto
                        Console.WriteLine(opciones[x]);
                    }else {
                        Console.ForegroundColor = ConsoleColor.DarkYellow; // Cambia el color del texto
                        Console.WriteLine(opciones[x]);
                    }
                }
                // Se obtiene la tecla pulsada
                key = Console.ReadKey().Key;
                // Se evalúa si se pulso arriba o abajo
                if(key == ConsoleKey.UpArrow){
                    // Se asigna a la variable opcionSeleccionada un decremento siempre y cuando el valor no sea 0
                    // Si es 0 se asigna un la ultima opcionSeleccionada que seria la ultima opcionSeleccionada del menú
                    opcionSeleccionada = opcionSeleccionada == 0 ? opciones.Length-1 : opcionSeleccionada - 1 ; 
                } else if(key == ConsoleKey.DownArrow){
                    // Se asigna a la variable opcionSeleccionada un incremento siempre y cuando el valor no sea 2
                    // Si es la ultima opcionSeleccionada se asigna un 0 que seria la primera opcionSeleccionada del menú
                    opcionSeleccionada = opcionSeleccionada == opciones.Length-1 ? 0 : opcionSeleccionada + 1 ; 
                }
            }while(key != ConsoleKey.Enter);
            return opcionSeleccionada;            
        }

        // Método de menu con Titulo, indicación y arreglo de opciones, que devuelve el string seleccionado
        public static string menuToString(string titulo, string indicacion, string[] opciones){
            int opcionSeleccionada = 0;// Variable para guardar la opcion del menú en que nos encontramos
            ConsoleKey key = new ConsoleKey(); // Variable para almacenar la tecla pulsada
            do{
                Console.Clear(); // Limpia la consola
                Console.ForegroundColor = ConsoleColor.DarkCyan; // Cambia el color del texto
                Console.WriteLine(titulo); 
                Console.ForegroundColor = ConsoleColor.DarkBlue; // Cambia el color del texto
                Console.WriteLine(indicacion);
                Console.ForegroundColor = ConsoleColor.DarkGray; // Cambia el color del texto
                Console.WriteLine("Utilize las flechas para moverse y pulse Enter para seleccionar... \n");
                // for que muestra las opciones poniendo de color blanco en donde se esta posicionado
                for(int x = 0 ; x < opciones.Length ; x++){
                    if(opcionSeleccionada == x){
                        Console.ForegroundColor = ConsoleColor.White; // Cambia el color del texto
                        Console.WriteLine(opciones[x]);
                    }else {
                        Console.ForegroundColor = ConsoleColor.DarkYellow; // Cambia el color del texto
                        Console.WriteLine(opciones[x]);
                    }
                }
                // Se obtiene la tecla pulsada
                key = Console.ReadKey().Key;
                // Se evalúa si se pulso arriba o abajo
                if(key == ConsoleKey.UpArrow){
                    // Se asigna a la variable opcionSeleccionada un decremento siempre y cuando el valor no sea 0
                    // Si es 0 se asigna un la ultima opcionSeleccionada que seria la ultima opcionSeleccionada del menú
                    opcionSeleccionada = opcionSeleccionada == 0 ? opciones.Length-1 : opcionSeleccionada - 1 ; 
                } else if(key == ConsoleKey.DownArrow){
                    // Se asigna a la variable opcionSeleccionada un incremento siempre y cuando el valor no sea 2
                    // Si es la ultima opcionSeleccionada se asigna un 0 que seria la primera opcionSeleccionada del menú
                    opcionSeleccionada = opcionSeleccionada == opciones.Length-1 ? 0 : opcionSeleccionada + 1 ; 
                }
            }while(key != ConsoleKey.Enter);
            return opciones[opcionSeleccionada];            
        }
    }
}

    

