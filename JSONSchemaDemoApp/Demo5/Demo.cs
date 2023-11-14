using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JSONSchemaDemoApp.Demo;
public class Demo5
{
    public static void Run()
    {
        Console.WriteLine("Ejecutando Demo 5");

        string jsonSchema = File.ReadAllText("Demo5/schema-demo.json");
        string jsonData = File.ReadAllText("Demo5/data-demo.json");

        JSchema schema = JSchema.Parse(jsonSchema);
        JObject data = JObject.Parse(jsonData);

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

        var id = Guid.NewGuid();
        var dateCreated = DateTime.Now;
        var empresa = data.SelectToken("EntityId.Empresa").Value<int>();
        var numeroPoliza = data.SelectToken("EntityId.NumeroPoliza").Value<long>();

        data.AddFirst(new JProperty("PartitionKey", new JValue($"[{empresa}][{numeroPoliza}]")));
        data.AddFirst(new JProperty("Id", new JValue(id)));
        data.Add("DateCreated", new JValue(dateCreated));

    }
}
