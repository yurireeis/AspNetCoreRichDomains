using System;
using System.Collections.Generic;
using Flunt.Notifications;

namespace PaymentContext.Shared.Entities
{
    public abstract class Entities : Notifiable
    {

        public Entities() { Id = Guid.NewGuid(); }
        public Guid Id { get; private set; }
    }
}
