using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAcademy.Persistence.Entities
{
	public class ItemImage
	{
		public int Id { get; set; }
		public int ItemId { get; set; }
		public Item Item { get; set; } = null!;
		public required byte[] ImageData { get; set; }
	}
}
