namespace CreditCardWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CreditCard")]
    public partial class CreditCard
    {
        public short ID { get; set; }

        public long? CardNumber { get; set; }

        public DateTime? ExpiryDate { get; set; }
    }
}
