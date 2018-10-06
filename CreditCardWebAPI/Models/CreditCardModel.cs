namespace CreditCardWebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.SqlClient;


    public partial class CreditCardModel : DbContext
    {
        public CreditCardModel()
            : base("name=CreditCardModel")
        {
        }

        public virtual DbSet<CreditCard> CreditCards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public virtual CreditCard GetCreditCardByCardNumber(Nullable<Int64> creditCardNo)
        {
            var creditCardParameter = creditCardNo.HasValue ? new SqlParameter("p_creditCardNo", creditCardNo) :
                new SqlParameter("p_creditCardNo", typeof(int));


            return this.Database.SqlQuery<CreditCard>("P_CREDIT_CARD_GET_BY_NUMBER @p_creditCardNo",
                    creditCardParameter).SingleOrDefault();


        }
    }
}
