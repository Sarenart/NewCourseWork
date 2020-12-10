namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supply")]
    public partial class Supply
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supply()
        {
            SupplyLine = new HashSet<SupplyLine>();
        }

        public int Id { get; set; }

        public int SupplierId { get; set; }

        public int WarehouseId { get; set; }

        public int ApplicantId { get; set; }

        public int? ArrangerId { get; set; }

        public decimal Cost { get; set; }

        public DateTime Date { get; set; }

        public int Status { get; set; }

        public virtual Provider Provider { get; set; }

        public virtual SupplyStatusRef SupplyStatusRef { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplyLine> SupplyLine { get; set; }
    }
}
