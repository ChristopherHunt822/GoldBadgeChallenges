using System;
using System.Collections.Generic;
using KomodoClaims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoClaims_Tests
{
    [TestClass]
    public class Claims_RepoTests
    {
        [TestMethod]
        public void CreateClaim_ShouldReturnTrue()
        {
            Claim claim = new Claim();
            ClaimsQueueRepository repo = new ClaimsQueueRepository();
            bool addResult = repo.CreateClaim(claim);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void ShowListOfClaims_ShouldReturnCollection()
        {
            Claim claim = new Claim();
            ClaimsQueueRepository repo = new ClaimsQueueRepository();
            repo.CreateClaim(claim);
            Queue<Claim> contents = repo.ShowListOfClaims();
            bool queueHasContent = contents.Contains(claim);
            Assert.IsTrue(queueHasContent);
        }
        [TestMethod]
        public void RemoveClaimFromQueue_ShouldRemoveClaimAndReturnFalse()
        {
            Claim claim = new Claim();
            ClaimsQueueRepository repo = new ClaimsQueueRepository();
            repo.CreateClaim(claim);
            repo.RemoveClaimFromQueue();
            Queue<Claim> contents = repo.ShowListOfClaims();
            bool queueHasContents = contents.Contains(claim);
            Assert.IsFalse(queueHasContents);
        }
        [TestMethod]
        public void ViewNextClaim_ShouldLeaveClaimInQueue()
        {
            Claim claim = new Claim();
            ClaimsQueueRepository repo = new ClaimsQueueRepository();
            repo.CreateClaim(claim);
            repo.ViewNextClaim();
            Queue<Claim> contents = repo.ShowListOfClaims();
            bool queueHasContent = contents.Contains(claim);
            Assert.IsTrue(queueHasContent);
        }
        
    }
}
