using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assebly_Browser_Library;
using Assebly_Browser_Library.Models;
using System.Collections.Generic;

namespace Assembly_Browser_Tests
{
    [TestClass]
    public class AssemblyLoaderTest
    {
        private const string dllPath = @"D:\Учёба\3 курс\My\СПП\1lab_spp\ClassLibrary1lab_spp\bin\Debug\ClassLibrary1lab_spp.dll";
        private List<Namespace> namespaces;

        [TestInitialize]
        public void Init()
        {
            var loader = new AssemblyLoader();
            namespaces = loader.GetAssemblyInformation(dllPath);
        }

        [TestMethod]
        public void TestNamespacesCount()
        {
            int expected = 1;

            Assert.AreEqual(expected, namespaces.Count);
        }

        [TestMethod]
        public void TestDataTypesCount()
        {
            int expected = 12;

            Assert.AreEqual(expected, namespaces[0].DataTypes.Count);
        }

        [TestMethod]
        public void TestDataTypeFieldsCount()
        {
            int expected = 3;

            Assert.AreEqual(expected, namespaces[0].DataTypes.Find(x => x.Name == "MethodInfo").Fields.Count);
        }

        [TestMethod]
        public void TestDataTypeMethodsCount()
        {
            int expected = 7;

            Assert.AreEqual(expected, namespaces[0].DataTypes.Find(x => x.Name == "MethodInfo").Methods.Count);
        }

        [TestMethod]
        public void TestDataTypePropertiesCount()
        {
            int expected = 1;

            Assert.AreEqual(expected, namespaces[0].DataTypes.Find(x => x.Name == "TraceResult").Properties.Count);
        }

    }

}
