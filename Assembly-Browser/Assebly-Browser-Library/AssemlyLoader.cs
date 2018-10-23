using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assebly_Browser_Library.Models;

namespace Assebly_Browser_Library
{
    public class AssemlyLoader
    {
        private List<Namespace> namespaces;
        private Assembly asm;

        public List<Namespace> GetAssemblyInformation(string pathDll)
        {
            asm = Assembly.LoadFrom(pathDll);
            LoadNamespaces();
            LoadDataTypes();

            return namespaces;
        }

        private void LoadNamespaces()
        {
            namespaces = new List<Namespace>();

            foreach (var type in asm.DefinedTypes)
            {
                if (namespaces.Find(x => x.Name == type.Namespace) == null)
                {
                    namespaces.Add(new Namespace()
                    {
                        Name = type.Namespace,
                    });
                }
            }
        }

        private void LoadDataTypes()
        {
            foreach (var ns in namespaces)
            {
                foreach (var type in asm.DefinedTypes.Where(x => x.Namespace == ns.Name))
                {
                    ns.DataTypes.Add(new TypeData(type));
                }
            }
        }
    }
}
