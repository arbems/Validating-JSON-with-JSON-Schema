using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Globalization;

namespace JSONSchemaDemoApp.Demo2;
public class CultureFormatValidator : JsonValidator
{
    public override void Validate(JToken value, JsonValidatorContext context)
    {
        if (value.Type == JTokenType.String)
        {
            string s = value.ToString();

            try
            {
                new CultureInfo(s);
            }
            catch (CultureNotFoundException)
            {
                context.RaiseError($"Text '{s}' is not a valid culture name.");
            }
        }
    }

    public override bool CanValidate(JSchema schema)
    {
        return (schema.Format == "culture");
    }
}

