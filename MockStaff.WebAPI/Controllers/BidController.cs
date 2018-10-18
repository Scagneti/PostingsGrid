using Microsoft.AspNet.Identity;
using MockStaff.Models;
using MockStaff.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MockStaff.WebAPI.Controllers
{
	[Authorize]
    public class BidController : ApiController
    {
		public IHttpActionResult GetAll()
		{
			BidService bidService = CreateBidService();
			var bids = bidService.GetBids();
			return Ok(bids);
		}

		public IHttpActionResult Get(int id)
		{
			BidService bidService = CreateBidService();
			var bid = bidService.GetBidById(id);
			return Ok(bid);
		}

		public IHttpActionResult Post(BidCreate bid)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var service = CreateBidService();

			if (!service.CreateBid(bid))
				return InternalServerError();

			return Ok();
		}

		public IHttpActionResult Put(BidEdit bid)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var service = CreateBidService();

			if (!service.UpdateBid(bid))
				return InternalServerError();

			return Ok();
		}

		public IHttpActionResult Delete(int id)
		{
			var service = CreateBidService();

			if (!service.DeleteBid(id))
				return InternalServerError();

			return Ok();
		}

		private BidService CreateBidService()
		{
			var userId = Guid.Parse(User.Identity.GetUserId());
			var bidService = new BidService(userId);
			return bidService;
		}
    }
}
