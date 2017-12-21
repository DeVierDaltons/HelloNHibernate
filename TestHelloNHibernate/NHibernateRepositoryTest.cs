using System.IO;
using HelloNHibernate.Model;
using NHibernate.Tool.hbm2ddl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloNHibernate.Dao.Test
{
    [TestClass]
    public class NHibernatePersonRepositoryTest
    {
        private IPersonRepository _personRepo;

        [TestInitialize]
        public void CreateSchema()
        {
            DeleteDatabaseIfExists();

            var schemaUpdate = new SchemaUpdate(NHibernateHelper.Configuration);
            schemaUpdate.Execute(false, true);

            _personRepo = new NHibernatePersonRepository();
        }

        [TestMethod]
        public void CanSavePerson()
        {
            _personRepo.Save(new Person());
            Assert.AreEqual(1, _personRepo.RowCount());
        }

        [TestMethod]
        public void CanGetPerson()
        {
            var person = new Person();
            _personRepo.Save(person);
            Assert.AreEqual(1, _personRepo.RowCount());

            person = _personRepo.Get(person.Id);
            Assert.IsNotNull(person);
        }

        [TestMethod]
        public void CanUpdatePerson()
        {
            var person = new Person();
            _personRepo.Save(person);
            Assert.AreEqual(1, _personRepo.RowCount());

            person = _personRepo.Get(person.Id);
            person.FirstName = "Test";
            _personRepo.Update(person);

            Assert.AreEqual(1, _personRepo.RowCount());
            Assert.AreEqual("Test", _personRepo.Get(person.Id).FirstName);
        }

        [TestMethod]
        public void CanDeletePerson()
        {
            var person = new Person();
            _personRepo.Save(person);
            Assert.AreEqual(1, _personRepo.RowCount());

            _personRepo.Delete(person);
            Assert.AreEqual(0, _personRepo.RowCount());
        }

        [TestCleanup]
        public void DeleteDatabaseIfExists()
        {
            if (File.Exists("test.db"))
                File.Delete("test.db");
        }
    }
}