namespace MIS230Team7GroupProjectFall2016.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Cost { get; set; }

        [Required]
        public string QtyOnHand { get; set; }

        public int Supplier_Id { get; set; }

        public int Meal_Id { get; set; }

        public virtual Meal Meal { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
