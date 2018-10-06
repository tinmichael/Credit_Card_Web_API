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
        Discover = 4,
        DinersClub = 5,
        JCB = 6,
        enRoute = 7
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
        public CreditCardType Type { get; set; }


        // Array of CardTypeInfo objects.
        // Used by GetCardType() to identify credit card types.
        private static CardTypeInfo[] _cardTypeInfo =
        {
              new CardTypeInfo("^(51|52|53|54|55)", 16, CreditCardType.MasterCard),
              new CardTypeInfo("^(4)", 16, CreditCardType.VISA),
              new CardTypeInfo("^(4)", 13, CreditCardType.VISA),
              new CardTypeInfo("^(34|37)", 15, CreditCardType.Amex),
              new CardTypeInfo("^(6011)", 16, CreditCardType.Discover),
              new CardTypeInfo("^(300|301|302|303|304|305|36|38)",
                               14, CreditCardType.DinersClub),
              new CardTypeInfo("^(3)", 16, CreditCardType.JCB),
              new CardTypeInfo("^(2131|1800)", 15, CreditCardType.JCB),
              new CardTypeInfo("^(2014|2149)", 15, CreditCardType.enRoute),
        };

        public static CreditCardType GetCardType(string cardNumber)
        {
            foreach (CardTypeInfo info in _cardTypeInfo)
            {
                if (cardNumber.Length == info.Length &&
                    Regex.IsMatch(cardNumber, info.RegEx))
                    return info.Type;
            }

            return CreditCardType.Unknown;
        }
    }


}