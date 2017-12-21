using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloNHibernate.Model;

namespace TestHelloNHibernate
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void GetFullNameTest()
        {
            var person = new Person
            {
                FirstName = "Test",
                LastName = "Kees"
            };

            Assert.AreEqual("Test", person.FirstName);
            Assert.AreEqual("Kees", person.LastName);

            Assert.AreEqual("Test Kees", person.GetFullName());
        }
    }
}
