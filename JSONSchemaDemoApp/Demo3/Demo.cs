﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JSONSchemaDemoApp.Demo;

/*
 Expresiones regulares.
 */
public class Demo3
{
    public static void Run()
    {
        Console.WriteLine("Ejecutando Demo 3");

        string jsonSchema = File.ReadAllText("Demo3/schema-demo.json");
        string jsonData = File.ReadAllText("Demo3/data-demo.json");

        JSchema schema = JSchema.Parse(jsonSchema);
        JToken data = JToken.Parse(jsonData);

        IList<string> errorMessages;
        bool isValid = data.IsValid(schema, out errorMessages);

        if (isValid)
        {
            Console.WriteLine("El JSON es válido según el esquema.");
        }
        else
        {
            Console.WriteLine("El JSON no es válido según el esquema. Errores:");
            foreach (var errorMessage in errorMessages)
            {
                Console.WriteLine(errorMessage);
            }
        }
    }
}
