namespace Encapsulation_shop
{
    public class Shop
    {
        private readonly Warehouse _warehouse;

        public Shop(Warehouse warehouse)
        {
            if (warehouse == null)
            {
                throw new ArgumentNullException("Склад не может быть null.", nameof(warehouse));
            }

            _warehouse = warehouse;
        }

        public Cart Cart()
        {
            return new Cart(_warehouse);
        }

        public void DisplayWarehouseGoods()
        {
            Console.WriteLine("Товары на складе:");

            var stock = _warehouse.GetStock();

            foreach (var item in stock)
            {
                Console.WriteLine($"- {item.Key.GetName()}: {item.Value} шт");
            }
        }
    }
}
