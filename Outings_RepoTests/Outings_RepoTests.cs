using System;
using System.Collections.Generic;
using KomodoOutings_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Outings_RepoTests
{
    [TestClass]
    public class Outings_RepoTests
    {
        [TestMethod]
        public void AddOutingToDirectory_ShouldReturnTrue()
        {
            Outings outing = new Outings();
            Outings_Repo repo = new Outings_Repo();
            bool addResult = repo.AddOutingToDirectory(outing);

            Assert.IsTrue(addResult);
        }

        public void GetOutingsList_ShouldReturnList()
        {
            Outings outing = new Outings();
            Outings_Repo repo = new Outings_Repo();
            repo.AddOutingToDirectory(outing);

            List<Outings> contents = repo.GetOutingsList();

            bool hasContent = contents.Contains(outing);

            Assert.IsTrue(hasContent);
        }
    }
}
