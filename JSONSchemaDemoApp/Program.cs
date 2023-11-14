using JSONSchemaDemoApp.Demo;

while (true)
{
    Console.WriteLine("Selecciona una demo para ejecutar:");
    Console.WriteLine("1. Demo PolizaDocument");
    Console.WriteLine("2. Demo Validación personalizada");
    Console.WriteLine("3. Expresiones regulares");
    Console.WriteLine("4. Lógica condicional");
    Console.WriteLine("5. Demo 5");
    Console.WriteLine("6. Demo 6");
    Console.WriteLine("7. Demo 7");
    Console.WriteLine("8. Demo 8");
    Console.WriteLine("9. Salir");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Demo1.Run();
            break;
        case "2":
            Demo2.Run();
            break;
        case "3":
            Demo3.Run();
            break;
        case "4":
            Demo4.Run();
            break;
        case "5":
            Demo5.Run();
            break;
        case "6":
            Demo6.Run();
            break;
        case "7":
            Demo7.Run();
            break;
        case "8":
            Demo8.Run();
            break;
        case "9":
            return;
        default:
            Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
            break;
    }
}