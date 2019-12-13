using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Centvrio.Emoji.DocumentationGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var unicodeStringType = typeof(UnicodeString);
            var types = unicodeStringType.Assembly.GetTypes();

            var sb = new StringBuilder(types.Length * 1000);
            sb.AppendLine("# Reference");
            sb.AppendLine();

            foreach (var type in types)
            {
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Where(prop => prop.FieldType == unicodeStringType)
                    .ToArray();
                if (!fields.Any())
                {
                    continue;
                }

                sb.AppendLine($"| {type.Name} |");
                sb.AppendLine($"| --- |");

                foreach (var prop in fields)
                {
                    sb.AppendLine($"| {prop.GetValue(null)} - `{type.Name}.{prop.Name}`");
                }

                sb.AppendLine();
            }

            File.WriteAllText("../../../../../docs/Reference.md", sb.ToString());
        }
    }
}
