using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockStaff.Models
{
	public class BidListItem
	{
		public int BidId { get; set; }
		public int PostingId { get; set; }
		public decimal PayRate { get; set; }
		public string PostingTitle {get; set;}

	}
}
