using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Serialization;
using HelloNHibernate.Dao;
using NHibernate.Mapping.ByCode;
using System.IO;

namespace TestHelloNHibernate
{
    [TestClass]
    public class PersonMapTest
    {
        //[TestMethod] // disabled because it takes 1 minute and has no Assert, but still shows the usage of ModelMapper
        public void CanGenerateXmlMapping()
        {
            var mapper = new ModelMapper();
            mapper.AddMapping<PersonMap>();

            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            var xmlSerializer = new XmlSerializer(mapping.GetType());

            StringWriter sw = new StringWriter();
            xmlSerializer.Serialize(sw, mapping);
            string result = sw.ToString();
        }
    }
}
