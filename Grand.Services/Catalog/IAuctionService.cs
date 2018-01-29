using Grand.Core;
using Grand.Core.Domain.Catalog;
using System;
using System.Collections.Generic;

namespace Grand.Services.Catalog
{
    /// <summary>
    /// Auction service interface
    /// </summary>
    public partial interface IAuctionService
    {
        /// <summary>
        /// Deletes bid
        /// </summary>
        /// <param name="bid"></param>
        void DeleteBid(Bid bid);

        /// <summary>
        /// Inserts bid
        /// </summary>
        /// <param name="bid"></param>
        void InsertBid(Bid bid);

        /// <summary>
        /// Updates bid
        /// </summary>
        /// <param name="bid"></param>
        void UpdateBid(Bid bid);

        /// <summary>
        /// Gets bids for product Id
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Bids</returns>
        IPagedList<Bid> GetProductReservationsByProductId(string productId, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets bid for specified Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Bid</returns>
        Bid GetBid(string Id);
    }
}
