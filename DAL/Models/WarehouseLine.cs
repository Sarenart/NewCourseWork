namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WarehouseLine")]
    public partial class WarehouseLine
    {
        public int Id { get; set; }

        public int CommodityId { get; set; }

        public int WarehouseId { get; set; }

        public decimal PerUnitCost { get; set; }

        public int Quantity { get; set; }

        public virtual Commodity Commodity { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
