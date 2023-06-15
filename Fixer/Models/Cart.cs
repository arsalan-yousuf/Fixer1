using Fixer.Models.VMs;

namespace Fixer.Models
{
	public class Cart
	{
		public List<CartItem> CartList { get; set; }
        public int CartTotal { get; set; }
    }
}
