using System;
using System.Collections.Generic;

namespace Project0.DataAccess.Entities
{
    public partial class LineItem
    {
        public int OrdersId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Orders Orders { get; set; }
        public virtual Product Product { get; set; }
    }
}
