namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resource")]
    public partial class Resource
    {
        [Column("resourceId")]
        public int ResourceId { get; set; }

        [Column("resourceKindId")]
        public int ResourceKindId { get; set; }

        [Column("value")]
        public double? Value { get; set; }

        [Column("date")]
        public DateTime? Date { get; set; }

        public virtual ResourceKind ResourceKind { get; set; }
    }
}
