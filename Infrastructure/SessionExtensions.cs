using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
namespace SportsStore.Infrastructure
{
    /// <summary>
    /// Класс для расширяющих методов, которые предоставят доступ к данным состояния сеанса
    /// </summary>
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}
