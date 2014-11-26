using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Helpers
{
    public static class PeselValidator
    {
        /// <summary>
        /// Mnozniki dla PESEL
        /// </summary>
        private static readonly int[] mnozniki = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        /// <summary>
        /// Sprawdza PESEL pod kątem poprawności
        /// </summary>
        /// <param name="pesel">PESEL string</param>
        /// <returns>true = OK; false = NOK</returns>
        public static bool ValidatePesel(string pesel)
        {
            bool toRet = false;
            try
            {
                if (pesel.Length == 11)
                {
                    toRet = CountSum(pesel).Equals(pesel[10].ToString());
                }
            }
            catch (Exception)
            {
                toRet = false;
            }
            return toRet;
        }

        /// <summary>
        /// Liczy sumę cyfr znaczących PESEL
        /// </summary>
        /// <param name="pesel">PESEL string</param>
        /// <returns>SUMA string</returns>
        private static string CountSum(string pesel)
        {
            int sum = 0;
            for (int i = 0; i < mnozniki.Length; i++)
            {
                sum += mnozniki[i] * int.Parse(pesel[i].ToString());
            }

            int reszta = sum % 10;
            return reszta == 0 ? reszta.ToString() : (10 - reszta).ToString();
        }
    
        
        
        
        public static DateTime? GetBirthDateFromPESEL(string pesel)
        {
            //Policz rok z uwzględnieniem XIX, XXI, XXII i XXIII wieku
            List<int> aInt = new List<int>();
            for (int i = 0; i < 11; i++)
            {
                aInt.Add(int.Parse(pesel.Substring(i, 1)));
            }

            var rok = 1900 + aInt[0] * 10 + aInt[1];
            if (aInt[2] >= 2 && aInt[2] < 8)
            {
                decimal d = aInt[2] / 2;
                rok += (int)(Math.Floor(d) * 100);
            }

            if (aInt[2] >= 8)
                rok -= 100;

            var miesiac = (aInt[2] % 2) * 10 + aInt[3];
            var dzien = aInt[4] * 10 + aInt[5];

            //Sprawdź poprawność daty urodzenia
            DateTime? result;
            try
            {
                result = new DateTime(rok, miesiac, dzien);
            }
            catch
            {
                result = null;
            }

            return result;
        }

        public static string GetSexFromPESEL(string pesel)
        {
            return (int.Parse(pesel.Substring(8, 1)) % 2 == 1) ? "M" : "K";

        }
    }
}
