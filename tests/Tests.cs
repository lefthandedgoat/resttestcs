
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using tests.ResponseTypes;

namespace tests
{
    [TestFixture]
    public class Tests
    {
        string testSite = @"http://jsonplaceholder.typicode.com/";

        [Test]
        public void GET_Posts_Verify_100()
        {
            var client = new RestClient(testSite);
            var request = new RestRequest($"/posts", Method.GET);

            var response = client.Execute<List<Post>>(request);
            var data = response.Data;

            Assert.AreEqual(100, data.Count);
        }

        [Test]
        public void GET_Posts_Id_Verify_Values()
        {
            var client = new RestClient(testSite);
            var request = new RestRequest($"/posts/1", Method.GET);

            var response = client.Execute<Post>(request);
            var data = response.Data;

            Assert.AreEqual(1, data.Id);
            Assert.AreEqual(1, data.UserId);
            Assert.AreEqual("sunt aut facere repellat provident occaecati excepturi optio reprehenderit", data.Title);
            Assert.AreEqual("quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto", data.Body);
        }
    }
}
