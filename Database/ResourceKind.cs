namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResourceKind")]
    public partial class ResourceKind
    {
#pragma warning disable IDE0079 // Remove unnecessary suppression
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
#pragma warning restore IDE0079 // Remove unnecessary suppression
        public ResourceKind()
        {
            Resource = new HashSet<Resource>();
        }

        [Column("resourceKindId")]
        public int ResourceKindId { get; set; }

        [Column("name")]
        public string Name { get; set; }

#pragma warning disable IDE0079 // Remove unnecessary suppression
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
#pragma warning restore IDE0079 // Remove unnecessary suppression
        public virtual ICollection<Resource> Resource { get; set; }
    }
}
