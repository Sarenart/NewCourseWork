namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProviderSupplyStock")]
    public partial class ProviderSupplyStock
    {
        public int Id { get; set; }

        public int CommodityId { get; set; }

        public int ProviderId { get; set; }

        public decimal Cost { get; set; }

        public virtual Commodity Commodity { get; set; }

        public virtual Provider Provider { get; set; }
    }
}
