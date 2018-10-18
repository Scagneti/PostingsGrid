using MockStaff.Data;
using MockStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockStaff.Services
{

	public class BidService
	{
		private readonly Guid _userId;

		public BidService(Guid userId)
		{
			_userId = userId;
		}

		public IEnumerable<BidListItem> GetBids()
		{
			using (var ctx = new ApplicationDbContext())
			{
				var query =
					ctx
						.Bids
						.Where(e => e.OwnerId == _userId)
						.Select(
							e => new BidListItem
							{
								BidId = e.BidId,
								PostingId = e.PostingId,
								PayRate = e.PayRate
							});
				return query.ToArray();
			}
		}
		public BidDetails GetBidById(int id)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity = ctx.Bids.Single(e => e.BidId == id && e.OwnerId == _userId);
				return new BidDetails
				{
					BidId = entity.BidId,
					PayRate = entity.PayRate,
					PostingId = entity.PostingId
				};
			}
		}
		public bool CreateBid(BidCreate model)
		{
			var entity = new Bid()
			{
				OwnerId = _userId,
				PayRate = model.PayRate,
				PostingId = model.PostingId
			};
			using (var ctx = new ApplicationDbContext())
			{
				ctx.Bids.Add(entity);
				return ctx.SaveChanges() == 1;
			}
		}
		public bool UpdateBid(BidEdit model)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity = ctx.Bids.Single(e => e.BidId == model.BidId && e.OwnerId == _userId);

				entity.PayRate = model.PayRate;
				entity.PostingId = model.PostingId;

				return ctx.SaveChanges() == 1;
			}
		}
		public bool DeleteBid(int id)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity =
					ctx
						.Bids
						.Single(e => e.BidId == id & e.OwnerId == _userId);

				ctx.Bids.Remove(entity);

				return ctx.SaveChanges() == 1;
			}
		}
	}
}
