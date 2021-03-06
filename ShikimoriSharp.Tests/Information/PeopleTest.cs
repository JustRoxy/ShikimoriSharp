﻿using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Tests.Information
{
    [TestFixture]
    public class PeopleTest : TestBase
    {
        [Test]
        public async Task GetPersonTest([Values("Yoshitoshi Abe")] string x)
        {
            var person = (await Client.People.GetPerson(new Search
            {
                search = x
            })).First();

            var personById = await Client.People.GetPerson(person.Id);
            Assert.AreEqual(person.Id, personById.Id);
        }

        [Test]
        public async Task GetPersonTest([Values(1991)] long x, [Values("Yoshitoshi Abe")] string testName)
        {
            var person = await Client.People.GetPerson(x);
            Assert.IsNotNull(person);
            Assert.AreEqual(testName, person.Name);
        }

        [Test]
        public async Task GetPublisherTest()
        {
            var publisher = await Client.Publishers.GetPublisher();
            Assert.IsNotEmpty(publisher);
        }
    }
}