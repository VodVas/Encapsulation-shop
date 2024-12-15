namespace Encapsulation_shop
{
    public class Cart
    {
        private readonly Warehouse _warehouse;
        private readonly Dictionary<Good, int> _items;
        private bool _isOrdered;

        public Cart(Warehouse warehouse)
        {
            if (warehouse == null)
            {
                throw new ArgumentNullException("Склад не может быть null.", nameof(warehouse));
            }

            _warehouse = warehouse;
            _items = new Dictionary<Good, int>();
            _isOrdered = false;
        }

        public void Add(Good good, int quantity)
        {
            if (_isOrdered)
            {
                throw new InvalidOperationException("Нельзя добавлять товары после оформления заказа.");
            }

            if (good == null)
            {
                throw new ArgumentNullException(nameof(good), "Товар не может быть null.");
            }

            if (quantity <= 0)
            {
                throw new ArgumentException("Количество должно быть положительным.");
            }

            _warehouse.Reserve(good, quantity);

            if (_items.ContainsKey(good))
            {
                _items[good] += quantity;
            }
            else
            {
                _items.Add(good, quantity);
            }
        }

        public Order Order()
        {
            if (_isOrdered)
            {
                throw new InvalidOperationException("Заказ уже оформлен.");
            }

            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Нельзя оформить пустой заказ.");
            }

            _isOrdered = true;

            return new Order(_items);
        }

        public void DisplayCartItems()
        {
            Console.WriteLine("Товары в корзине:");

            foreach (var item in _items)
            {
                Console.WriteLine($"- {item.Key.GetName()}: {item.Value} шт.");
            }
        }
    }
}