using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardWebAPI.Models
{
    public class ValidateResult
    {
      
      
        public string result { get; set; }
        public string cardType  { get; set; }
    }

    internal class Validation
    {
        public const string Valid = "Valid";
        public const string Invalid = "Invalid";
        public const string DoesNotExist = "Does Not Exist";

    }
}