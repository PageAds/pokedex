using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Pokedex.Data.HttpClients;
using Pokedex.Data.Models.FunTranslationsApi;
using System.Net;
using Xunit;

namespace Pokedex.UnitTests
{
    public class FunTranslationsApiClientTests
    {
        private readonly FunTranslationsApiClient subject;
        private readonly Mock<HttpMessageHandler> messageHandlerMock;

        private readonly string fakeApiUrl = "https://fake-api/translate/";

        public FunTranslationsApiClientTests()
        {
            var funTranslationsResponseMock = new FunTranslationsResponse
            {
                Contents = new Contents
                {
                    Translated = "translated text"
                }
            };

            messageHandlerMock = new Mock<HttpMessageHandler>();
            messageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(funTranslationsResponseMock))
                });

            var httpClient = new HttpClient(messageHandlerMock.Object)
            {
                BaseAddress = new Uri(fakeApiUrl)
            };

            subject = new FunTranslationsApiClient(httpClient);
        }

        [Fact]
        public async Task GetTranslation_WhenTranslationTypeIsYoda_YodaRequestUriShouldBeUsed()
        {
            var textToTranslate = "test";
            var expectedUrl = @$"{fakeApiUrl}yoda.json?text={textToTranslate}";

            await subject.GetTranslation(textToTranslate, TranslationType.Yoda);

            messageHandlerMock.Protected()
                .Verify("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(x => x.RequestUri.ToString() == expectedUrl), ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task GetTranslation_WhenTranslationTypeIsShakespeare_ShakespeareRequestUriShouldBeUsed()
        {
            var textToTranslate = "test";
            var expectedUrl = @$"{fakeApiUrl}shakespeare.json?text={textToTranslate}";

            await subject.GetTranslation(textToTranslate, TranslationType.Shakespeare);

            messageHandlerMock.Protected()
                .Verify("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(x => x.RequestUri.ToString() == expectedUrl), ItExpr.IsAny<CancellationToken>());
        }
    }
}