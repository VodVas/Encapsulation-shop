namespace Encapsulation_shop
{
    public class Good
    {
        private readonly string _name;

        public Good(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Название товара не может быть пустым или состоять только из пробелов", nameof(name));
            }

            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Good otherGood)
            {
                return _name == otherGood._name;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }
    }
}