namespace Fixer.Models.VMs
{
    public class CartItem
    {
        public string Name { get; set; }
        public byte[] ByteImage { get; set; }
        public int Quantity { get; set; }
        public int ServiceID { get; set; }
        public int ServicePrice { get; set; }
        public int TotalPrice { get; set; }
    }
}
