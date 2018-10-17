using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockStaff.Data
{
	public class Bid
	{
		[Key]
		public int BidId { get; set; }
		public int PostingId { get; set; }
		public decimal PayRate { get; set; }
		public Guid OwnerId { get; set; }

		public virtual Posting Posting { get; set; }
	}
}
