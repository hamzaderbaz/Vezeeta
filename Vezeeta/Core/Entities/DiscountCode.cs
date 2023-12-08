namespace Vezeeta.Core.Entities
{
    public class DiscountCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int NumberOfUses { get; set; }
        public DiscountType Type { get; set; }
        public decimal Value { get; set; }

    }

    public enum DiscountType
    {
        Percentage = 0,
        Value = 1
    }

}
