using System;
using System.Collections.Generic;
using Grand.Core.Domain.Catalog;
using Grand.Core.Data;
using Grand.Services.Events;
using MongoDB.Driver;
using System.Linq;
using Grand.Core;

namespace Grand.Services.Catalog
{
    /// <summary>
    /// Auction service
    /// </summary>
    public partial class AuctionService : IAuctionService
    {
        private readonly IRepository<Bid> _bidRepository;
        private readonly IEventPublisher _eventPublisher;


        public AuctionService(IRepository<Bid> bidRepository,
            IEventPublisher eventPublisher)
        {
            _bidRepository = bidRepository;
            _eventPublisher = eventPublisher;
        }

        public void DeleteBid(Bid bid)
        {
            if (bid == null)
                throw new ArgumentNullException("bid");

            _bidRepository.Delete(bid);
            _eventPublisher.EntityDeleted(bid);
        }

        public Bid GetBid(string Id)
        {
            return _bidRepository.GetById(Id);
        }

        public IPagedList<Bid> GetProductReservationsByProductId(string productId, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _bidRepository.Table.Where(x => x.ProductId == productId);
            return new PagedList<Bid>(query, pageIndex, pageSize);
        }

        public void InsertBid(Bid bid)
        {
            if (bid == null)
                throw new ArgumentNullException("bid");

            _bidRepository.Insert(bid);
            _eventPublisher.EntityInserted(bid);
        }

        public void UpdateBid(Bid bid)
        {
            if (bid == null)
                throw new ArgumentNullException("bid");

            _bidRepository.Update(bid);
            _eventPublisher.EntityUpdated(bid);
        }
    }
}
