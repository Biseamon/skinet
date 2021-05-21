using System.Collections.Generic;

namespace skinet.Core.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }

        public CustomerBasket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<BasketItems> Items { get; set; } = new List<BasketItems>();
    }
}