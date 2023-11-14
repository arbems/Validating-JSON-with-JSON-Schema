using JSONSchemaDemoApp.Demo2;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JSONSchemaDemoApp.Demo;

/*
 Validaciones personalizadas.
 */

public class Demo2
{
    public static void Run()
    {
        Console.WriteLine("Ejecutando Demo 2");

        string jsonSchema = File.ReadAllText("Demo2/schema-demo.json");
        string jsonData = File.ReadAllText("Demo2/data-demo.json");

        var settings = new JSchemaReaderSettings
        {
            Validators = new List<JsonValidator> { new CultureFormatValidator() }
        };

        JSchema schema = JSchema.Parse(jsonSchema, settings);
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
