using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using CreditCardWebAPI.Models;

using System.Text.RegularExpressions;

namespace CreditCardWebAPI.Extensions
{
    using System;
    using System.Globalization;

    public static class CreditCardExtensions
    {


        public static bool IsCardNumberValid(string cardNumber)
        {
            int i, checkSum = 0;

            // Compute checksum of every other digit starting from right-most digit
            for (i = cardNumber.Length - 1; i >= 0; i -= 2)
                checkSum += (cardNumber[i] - '0');

            // Now take digits not included in first checksum, multiple by two,
            // and compute checksum of resulting digits
            for (i = cardNumber.Length - 2; i >= 0; i -= 2)
            {
                int val = ((cardNumber[i] - '0') * 2);
                while (val > 0)
                {
                    checkSum += (val % 10);
                    val /= 10;
                }
            }

            // Number is valid if sum of both checksums MOD 10 equals 0
            return ((checkSum % 10) == 0);
        }

        public static string NormalizeCardNumber(this string cardNumber)
        {
            if (cardNumber == null)
                cardNumber = String.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (char c in cardNumber)
            {
                if (Char.IsDigit(c))
                    sb.Append(c);
            }

            return sb.ToString();

        }

        public static CreditCardType GetCardType(this string cardNumber)
        {
            foreach (CardTypeInfo info in _cardTypeInfo)
            {
                if (cardNumber.Length == info.Length &&
                    Regex.IsMatch(cardNumber, info.RegEx))
                    return info.Type;
            }

            return CreditCardType.Unknown;
        }

        private static CardTypeInfo[] _cardTypeInfo =
        {
          new CardTypeInfo("^(5)", 16, CreditCardType.MasterCard),
          new CardTypeInfo("^(4)", 16, CreditCardType.VISA),
          new CardTypeInfo("^(3)", 15, CreditCardType.Amex),
          new CardTypeInfo("^(3)", 16, CreditCardType.JCB)
        };


        public static bool IsValidVISA(this CreditCard visaCard)

        {
            
                if (visaCard.ExpiryDate.HasValue)
                {
                    if (DateTime.IsLeapYear(visaCard.ExpiryDate.Value.Year))
                    {
                    return true;
                    }
                return false;
                }
            return false;
            
        }

        public static bool IsValidMaster(this CreditCard masterCard)

        {
       
            if (masterCard.ExpiryDate.HasValue)
            {
                if (masterCard.ExpiryDate.Value.Year.IsPrime())
                {
                    return true;
                }
                return false;
            }
            return false;

        }

        private static bool IsPrime(this int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            //if (number == 6737626471) return true;

            if (number % 2 == 0) return false;

            for (int i = 3; i < number; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

    }
}