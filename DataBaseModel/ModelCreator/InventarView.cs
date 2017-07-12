namespace ModelCreator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LHELP.InventarView")]
    public partial class InventarView
    {
        public string InventarGuid { get; set; }

        public string FoodName { get; set; }

        public string FoodSort { get; set; }

        public string Messurement { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Amount { get; set; }

        public int? User_Id { get; set; }
    }
}
