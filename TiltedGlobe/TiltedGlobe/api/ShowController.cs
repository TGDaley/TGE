using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using TiltedGlobe.Api.Models;
using TiltedGlobe.App;
using TiltedGlobe.App.Show;
using TiltedGlobe.App.User;

namespace TiltedGlobe.Api
{
    public class ShowController : BaseApiController<Show, Models.ShowViewModel>
    {
	    public ShowController(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
	    {
	    }

	    protected override List<Models.ShowViewModel> Entities
        {
            get
            {
                var user = AppUserManager.FindByName(User.Identity.Name);
                return
                    Database.Set<Show>().Where(u => u.ApplicationUser.Id ==user.Id).Select(
										entity => new ShowViewModel
                            {
															Approved = entity != null && entity.Approved,
                              CreatedTimeStamp = entity == null ? DateTime.MinValue : entity.CreatedTimeStamp,
															ShowDate = entity == null ? DateTime.MinValue : entity.ShowDate,
															Description = entity == null ? "" : entity.Description,
															Id = entity == null ? -1 : entity.Id,
															Status = entity == null ? -1 : entity.Status,
															CommercialViewerBasePrice = entity == null ? -1 : entity.CommercialViewerBasePrice,
															CommercialViewerTicketsIssued = entity == null ? -1 : entity.CommercialViewerTicketsIssued,
															CommercialViewerTicketsSold = entity == null ? -1 : entity.CommercialViewerTicketsSold,
															SingleViewerBasePrice = entity == null ? -1 : entity.SingleViewerBasePrice,
															SingleViewerTicketsIssued = entity == null ? -1 : entity.SingleViewerTicketsIssued,
															SingleViewerTicketsSold = entity == null ? -1 : entity.SingleViewerTicketsSold,
															Name = entity == null ? "" : entity.Name,
															GenreId = entity == null ? -1 : entity.Genre.Id,
															Note = entity == null ? "" : entity.Note,
															Rating = entity == null ? Rating.G : entity.Rating,
															EstimatedDuration = entity == null ? -1 : entity.EstimatedDuration,
															IsDelayedViewingEnabled = entity != null && entity.IsDelayedViewingEnabled,
															AllowCommercialViewersToStream = entity != null && entity.AllowCommercialViewersToStream,
															IsOwner = entity != null && entity.IsOwner,
															ShouldConvertToOnDemand = entity != null && entity.ShouldConvertToOnDemand,
															UpdatedTimeStamp = entity == null ? DateTime.MinValue : entity.UpdatedTimeStamp,
                              BatchId = entity == null ? "" : entity.BatchId,
															RoyaltyAgreementAwsAssetKey = entity == null ? "" : entity.RoyaltyAgreementAwsAssetKey,
															ShowThumbNailAwsAssetKey = entity == null ? "" : entity.ShowThumbNailAwsAssetKey,
															VenueContractAwsAssetKey = entity == null ? "" : entity.VenueContractAwsAssetKey,
															PlayBillAwsAssetKey = entity == null ? "" : entity.PlayBillAwsAssetKey,
															ApplicationUserId = entity == null ? "" : entity.ApplicationUser.Id
                            }).ToList();
            }
        }

        protected override IEnumerable<Show> Save(IEnumerable<Models.ShowViewModel> models)
        {
            var shows = new List<Show>();
            foreach (var model in models)
            {
                var s = new Show();
                if (model.Id != 0)
                    s = Database.Set<Show>().SingleOrDefault(i => i.Id == model.Id);

                s.Approved = model.Approved;
                if (model.Id == 0) s.CreatedTimeStamp = DateTime.UtcNow;
                s.ShowDate = model.ShowDate;
                s.Description = model.Description;
                s.Status = model.Status;
                s.CommercialViewerBasePrice = model.CommercialViewerBasePrice;
                s.CommercialViewerTicketsIssued = model.CommercialViewerTicketsIssued;
                s.CommercialViewerTicketsSold = model.CommercialViewerTicketsSold;
                s.SingleViewerBasePrice = model.SingleViewerBasePrice;
                s.SingleViewerTicketsIssued = model.SingleViewerTicketsIssued;
                s.SingleViewerTicketsSold = model.SingleViewerTicketsSold;
                s.Name = model.Name;
                s.UpdatedTimeStamp = DateTime.UtcNow;
                s.IsDelayedViewingEnabled = model.IsDelayedViewingEnabled;
                s.IsOwner = model.IsOwner;
                s.AllowCommercialViewersToStream = model.AllowCommercialViewersToStream;
                s.ShouldConvertToOnDemand = model.ShouldConvertToOnDemand;
                s.Genre = Database.Set<Genre>().Single(st => st.Id == model.GenreId);
                s.EstimatedDuration = model.EstimatedDuration;
                s.Rating = model.Rating;
                s.Note = model.Note;
                s.BatchId = model.BatchId;
                s.RoyaltyAgreementAwsAssetKey = model.RoyaltyAgreementAwsAssetKey;
                s.ShowThumbNailAwsAssetKey = model.ShowThumbNailAwsAssetKey;
                s.VenueContractAwsAssetKey = model.VenueContractAwsAssetKey;
                s.PlayBillAwsAssetKey = model.PlayBillAwsAssetKey;
                s.ApplicationUser =
                    Database.Set<ApplicationUser>().Single(u => u.Id == model.ApplicationUserId);
                shows.Add(s);
                if (model.Id == 0)
                    Database.Set<Show>().Add(s);
            }
            return shows;
        }
    }
}