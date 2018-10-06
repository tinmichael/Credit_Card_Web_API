using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CreditCardWebAPI.Models;
using CreditCardWebAPI.Extensions;


namespace CreditCardWebAPI.Controllers
{
    public class CreditCardsController : ApiController
    {
        private CreditCardModel db = new CreditCardModel();

        // GET: api/CreditCards
        public IQueryable<CreditCard> GetCreditCards()
        {
            return db.CreditCards;
        }

        // GET: api/CreditCards/5
        [ResponseType(typeof(CreditCard))]
        public IHttpActionResult GetCreditCard(string id)
        {
            //CreditCard creditCard = db.CreditCards.Find(id);
            //if (creditCard == null)
            //{
            //    return NotFound();
            //}

            //return Ok(creditCard);

            using (var context = new CreditCardModel())
            {
              

                if (CreditCardExtensions.IsCardNumberValid(id.NormalizeCardNumber()))
                {

                    var creditCard = context.GetCreditCardByCardNumber(Convert.ToInt64(id));
                    if (creditCard == null)
                    {
                        return NotFound();
                    }
                    return Ok(creditCard);
                }
                return NotFound();

            }
        }


        // PUT: api/CreditCards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCreditCard(short id, CreditCard creditCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != creditCard.ID)
            {
                return BadRequest();
            }

            db.Entry(creditCard).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditCardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CreditCards
        [ResponseType(typeof(CreditCard))]
        public IHttpActionResult PostCreditCard(CreditCard creditCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreditCards.Add(creditCard);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = creditCard.ID }, creditCard);
        }

        // DELETE: api/CreditCards/5
        [ResponseType(typeof(CreditCard))]
        public IHttpActionResult DeleteCreditCard(short id)
        {
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return NotFound();
            }

            db.CreditCards.Remove(creditCard);
            db.SaveChanges();

            return Ok(creditCard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CreditCardExists(short id)
        {
            return db.CreditCards.Count(e => e.ID == id) > 0;
        }
    }
}