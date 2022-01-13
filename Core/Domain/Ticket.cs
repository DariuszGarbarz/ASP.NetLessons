using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Ticket : Entity
    {
        public Guid EventId { get; protected set; }
        public int Seating { get; protected set; }
        public decimal Price { get; protected set; }
        public Guid? UserId { get; protected set; }
        public string Username { get; protected set; }
        public DateTime? PutchasedAt { get; protected set; }

        public bool IsPurchased => UserId.HasValue;

        protected Ticket()
        {
        }
        public Ticket(Event @event, int seating, decimal price)
        {
            EventId = @event.Id;
            Seating = seating;
            Price = price;
            
        }
    }
}
