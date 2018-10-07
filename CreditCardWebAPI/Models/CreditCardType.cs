using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace CreditCardWebAPI.Models
{
    public enum CreditCardType
    {
        Unknown = 0,
        MasterCard = 1,
        VISA = 2,
        Amex = 3,
        JCB = 4
    }


    public class CardTypeInfo
    {
        public CardTypeInfo(string regEx, int length, CreditCardType type)
        {
            RegEx = regEx;
            Length = length;
            Type = type;
        }

        public string RegEx { get; set; }
        public int Length { get; set; }
        public CreditCardType Type { get; set;}


    }


}