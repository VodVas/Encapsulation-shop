namespace Encapsulation_shop
{
    internal class Program
    {
        public static void Main()
        {
            try
            {
                Good iPhone12 = new Good("IPhone 12");
                Good iPhone11 = new Good("IPhone 11");

                Warehouse warehouse = new Warehouse();

                Shop shop = new Shop(warehouse);

                warehouse.Deliver(iPhone12, 10);
                warehouse.Deliver(iPhone11, 1);

                shop.DisplayWarehouseGoods();

                Cart cart = shop.Cart();

                cart.Add(iPhone12, 4);
                cart.Add(iPhone11, 3);

                cart.DisplayCartItems();

                Order order = cart.Order();
                Console.WriteLine(order.Paylink);

                cart.Add(iPhone12, 9);

                shop.DisplayWarehouseGoods();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Ошибка: {exception.Message}"); 
            }
        }
    }
}