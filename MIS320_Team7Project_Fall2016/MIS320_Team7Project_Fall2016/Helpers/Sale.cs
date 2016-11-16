namespace MIS230Team7GroupProjectFall2016.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sale()
        {
            Meals = new HashSet<Meal>();
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Store_Id { get; set; }

        public int User_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meal> Meals { get; set; }

        public virtual User User { get; set; }

        public virtual Store Store { get; set; }
    }
}
