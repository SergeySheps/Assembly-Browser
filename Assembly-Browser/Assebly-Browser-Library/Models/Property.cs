using System.Reflection;

namespace Assebly_Browser_Library.Models
{
    public class Property
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public Property(PropertyInfo property)
        {
            Name = property.Name;
            Type = property.PropertyType.Name;
        }
    }
}
