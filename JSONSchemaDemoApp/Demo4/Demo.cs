using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JSONSchemaDemoApp.Demo;

/*
 Lógica condicional.
 */

public class Demo4
{
    public static void Run()
    {
        Console.WriteLine("Ejecutando Demo 4");

        string jsonSchema = File.ReadAllText("Demo4/schema-demo.json"); // Inserta el esquema JSON aquí
        string jsonData = File.ReadAllText("Demo4/data-demo.json"); // Inserta el JSON que deseas validar aquí

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
