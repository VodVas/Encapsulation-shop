namespace Encapsulation_shop
{
    public class Order
    {
        private readonly Dictionary<Good, int> _items;

        public string Paylink { get; }

        public Order(Dictionary<Good, int> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("Список товаров не может быть null.", nameof(items));
            }

            if (items.Count == 0)
            {
                throw new ArgumentException("Список товаров не может быть пустым.", nameof(items));
            }

            foreach (var item in items)
            {
                if (item.Key == null)
                {
                    throw new ArgumentException("Товар в заказе не может быть null.", nameof(items));
                }

                if (item.Value <= 0)
                {
                    throw new ArgumentException("Количество товара должно быть положительным.", nameof(items));
                }
            }

            _items = new Dictionary<Good, int>(items);

            Paylink = GetPayLink();
        }

        private string GetPayLink()
        {
            return "https://pay.apple.com/";
        }
    }
}