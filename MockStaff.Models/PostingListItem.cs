﻿using MockStaff.Data;
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
		public decimal? LowBid { get; set; }
		public bool IsUrgent { get; set; }
		public string HiringManager { get; set; }
		public PostingStatus Status { get; set; }
		public DateTimeOffset ExpirationDate { get; set; }
		public PositionType PositionType { get; set; }
		public string CreatedBy { get; set; }
		public override string ToString()
		{
			return base.ToString();
		}
	}
}
