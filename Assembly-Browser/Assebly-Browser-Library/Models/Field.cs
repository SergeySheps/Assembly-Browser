using System.Reflection;

namespace Assebly_Browser_Library.Models
{
    public class Field
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public Field(FieldInfo field)
        {
            Name = field.Name;
            Type = field.FieldType.Name;
        }
    }
}
