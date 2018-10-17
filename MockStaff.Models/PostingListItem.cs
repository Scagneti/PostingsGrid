using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockStaff.Models
{
	public class PostingListItem
	{
		public int PostingId { get; set; }
		public string Title { get; set; }
		public DateTimeOffset CreatedDate { get; set; }
		public override string ToString()
		{
			return base.ToString();
		}
	}
}
