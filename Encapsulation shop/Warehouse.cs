namespace Encapsulation_shop
{
    public class Warehouse
    {
        private readonly Dictionary<Good, int> _stock;

        public Warehouse()
        {
            _stock = new Dictionary<Good, int>();
        }

        public void Deliver(Good good, int quantity)
        {
            if (good == null)
            {
                throw new ArgumentNullException(nameof(good), "Товар не может быть null.");
            }

            if (quantity <= 0)
            {
                throw new ArgumentException("Количество должно быть положительным.", nameof(quantity));
            }

            if (_stock.ContainsKey(good))
            {
                _stock[good] += quantity;
            }
            else
            {
                _stock.Add(good, quantity);
            }
        }

        public bool HasStock(Good good, int quantity)
        {
            if (good == null)
            {
                throw new ArgumentNullException("Товар не может быть null.", nameof(good));
            }

            return _stock.ContainsKey(good) && _stock[good] >= quantity;
        }

        public void Reserve(Good good, int quantity)
        {
            if (good == null)
            {
                throw new ArgumentNullException("Товар не может быть null.", nameof(good));
            }

            if (HasStock(good, quantity) == false)
            {
                throw new InvalidOperationException($"Недостаточно товара '{good.GetName()}' на складе.");
            }

            _stock[good] -= quantity;

            if (_stock[good] == 0)
            {
                _stock.Remove(good);
            }
        }

        public Dictionary<Good, int> GetStock()
        {
            return new Dictionary<Good, int>(_stock);
        }
    }
}
