using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using SportsStore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace SportsStore.Models
{
    /// <summary>
    /// Класс службы , который осведомлен о том, как сохранять самого себя с применением состояния сеанса
    /// </summary>
    public class SessionCart : Cart
    {
        //Фабрика для созданя объектов SessionCart и снабжжения их объектом реализации ISession
        //для сохранения себя
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();

            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
