using Moq;
using Moq.Protected;
using NUnit.Framework;
using System.Net;

namespace CatFactsAPI.Service
{
    [TestFixture]
    public class CatFactsServiceTests
    {
        private CatFactsService catFactsService;

        [SetUp]
        public void SetUp()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(@"[
	                    {
		                    ""status"": {
			                    ""verified"": true,
			                    ""sentCount"": 1
		                    },
		                    ""_id"": ""58e008780aac31001185ed05"",
		                    ""user"": ""58e007480aac31001185ecef"",
		                    ""text"": ""Owning a cat can reduce the risk of stroke and heart attack by a third."",
		                    ""__v"": 0,
		                    ""source"": ""user"",
		                    ""updatedAt"": ""2020-08-23T20:20:01.611Z"",
		                    ""type"": ""cat"",
		                    ""createdAt"": ""2018-03-29T20:20:03.844Z"",
		                    ""deleted"": false,
		                    ""used"": false
	                        }
                        ]"),
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            catFactsService = new CatFactsService(httpClient);
        }

        [Test]
        public async Task GetCatFacts_WithValidUrl_ReturnsCatFacts()
        {
            var catFacts = await catFactsService.GetCatFacts("https://example.com/api/catfacts");

            Assert.That(catFacts,Is.Not.Empty);
            Assert.That(catFacts.Count(), Is.EqualTo(1));
            Assert.That(catFacts.First().Text, Is.EqualTo("Owning a cat can reduce the risk of stroke and heart attack by a third."));
        }

        [Test]
        public void GetCatFacts_WithInvalidUrl_ReturnNull()
        {
            var invalidUrl = "";
            Assert.ThrowsAsync<ArgumentNullException>(() => catFactsService.GetCatFacts(invalidUrl));
        }
    }
}
