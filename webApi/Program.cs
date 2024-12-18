using Humanizer;
Console.WriteLine("Ingresa un nombre");
var nombre = Console.ReadLine();
Console.WriteLine("ingrese su carga");
var cargo = Console.ReadLine();
Console.WriteLine("Ingrese su edad");
var edad = int.Parse(Console.ReadLine());
Console.WriteLine($"hola soy {nombre} soy {cargo}y tengo {edad.ToWords()} años");