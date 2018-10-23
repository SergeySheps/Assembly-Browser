using System.Collections.Generic;

namespace Assebly_Browser_Library.Models
{
    public class Namespace
    {
        public string Name { get; set; }

        public List<TypeData> DataTypes { get; set; }

        public Namespace()
        {
            DataTypes = new List<TypeData>();
        }

    }
}
