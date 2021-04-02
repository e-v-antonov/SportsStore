using Microsoft.AspNetCore.Http;

namespace SportsStore.Infrastructure
{
    /// <summary>
    /// Класс для расширяющего метода, который генерирует URL,
    /// по которому браузер будет возвращаться после обновления корзины,
    /// принимая во внимание строку запроса
    /// </summary>
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue
            ? $"{request.Path}{request.QueryString}"
            : request.Path.ToString();
    }
}
