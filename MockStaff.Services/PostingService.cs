using MockStaff.Data;
using MockStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockStaff.Services
{
	public class PostingService
	{
		private readonly Guid _userId;

		public PostingService(Guid userId)
		{
			_userId = userId;
		}

		public bool CreatePosting(PostingCreate model)
		{
			var entity = new Posting()
			{
				OwnerId = _userId,
				Title = model.Title,
				IsUrgent = model.IsUrgent,
				HiringManager = model.HiringManger,
				Status = model.Status,
				ExpirationDate = model.ExpirationDate,
				PositionType = model.PositionType,
				CreatedBy = model.CreatedBy,
				CreatedDate = DateTime.Now
			};

			using (var ctx = new ApplicationDbContext())
			{
				ctx.Postings.Add(entity);
				return ctx.SaveChanges() == 1;
			}
		}
		public IEnumerable<PostingListItem> GetPostings()
		{
			using (var ctx = new ApplicationDbContext())
			{
				var query =
					ctx
						.Postings
						.Where(e => e.OwnerId == _userId)
						.Select(
							e =>
								new PostingListItem
								{
									PostingId = e.PostingId,
									Title = e.Title,
									CreatedDate = e.CreatedDate,
									LowBid = e.LowBid,
									IsUrgent = e.IsUrgent,
									HiringManager = e.HiringManager,
									Status = e.Status,
									ExpirationDate = e.ExpirationDate,
									PositionType = e.PositionType,
									CreatedBy = e.CreatedBy
								}
								);
				return query.ToArray();
			}
		}
		//public PostingDetail GetPostingById(int id)
		//{
		//	using (var ctx = new ApplicationDbContext())
		//	{
		//		var entity = ctx .Postings .Single(e => e.PostingId == postingId)
		//	}
		//}
	}
}
