namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SupplyLine")]
    public partial class SupplyLine
    {
        public int Id { get; set; }

        public int SupplyId { get; set; }

        public int CommodityId { get; set; }

        public int Quantity { get; set; }

        public decimal Cost { get; set; }

        public virtual Commodity Commodity { get; set; }

        public virtual Supply Supply { get; set; }
    }
}
