namespace Pokedex.Data.Handlers
{
    public class FunTranslationsApiAuthenticationHandler : DelegatingHandler
    {
        private readonly string apiSecret;

        public FunTranslationsApiAuthenticationHandler(string apiSecret)
        {
            this.apiSecret = apiSecret;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("X-FunTranslations-Api-Secret", apiSecret);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
