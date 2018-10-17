using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockStaff.Data
{
	public enum PostingStatus
	{
		Active = 1,
		[Display(Name = "Position Filled")]Filled,
		Deleted
	}

	public enum PositionType
	{
		Project = 1, 
		StaffAug,

	}
    public class Postings
    {
		[Key]
		public int PostingId { get; set; }
		[Required]
		public Guid OwnerId { get; set; }
		[Required]
		public DateTimeOffset CreatedDate { get; set; }
		[Required]
		public decimal LowBid { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public bool IsUrgent { get; set; }
		[Required]
		public string HiringManager { get; set; }
		[Required]
		public PostingStatus Status { get; set; }
		[Required]
		public DateTimeOffset ExpirationDate { get; set; }
		[Required]
		public PositionType PositionType { get; set; }
		[Required]
		public string CreatedBy { get; set; }
	}
}
