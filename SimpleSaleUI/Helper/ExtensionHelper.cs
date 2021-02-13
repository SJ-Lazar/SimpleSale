using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleSaleUI.Helper
{
    public static class ExtensionHelper
    {

        public static bool ValidatePassword(this string @this)
        {
            bool P_IsValid = false;
            try
            {
                P_IsValid = Regex.IsMatch(@this, @"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[_!@#$%^&+=]).*$", RegexOptions.IgnoreCase);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return P_IsValid;
        }
        public static bool ValidateEmail(this string @this)
        {
            bool IsValid = false;
            try
            {
                IsValid = Regex.IsMatch(@this, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsValid;
        }
        public static bool IsEmpty(this string @this)
        {
            bool IsBlank = false;
            try
            {
                IsBlank = (String.IsNullOrEmpty(@this)) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsBlank;
        }
        public static bool ValidateNumber(this string @this)
        {
            bool N_IsValid = false;
            try
            {
                N_IsValid = Regex.IsMatch(@this, @"^(?:\+?1[-. ]?)?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", RegexOptions.IgnoreCase);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return N_IsValid;
        }
        public static bool ValidateDecimal(this string @this)
        {
            bool D_IsValid = false;
            try
            {
                D_IsValid = Regex.IsMatch(@this, @"\d{1,12}\.\d\d", RegexOptions.IgnoreCase);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return D_IsValid;

        }
        public static bool IsDesimal(this string @this)
        {
            string decimalNumber = ".0123456789";
            for (int i = 0; i < @this.Trim().Length; i++)
            {
                if (decimalNumber.IndexOf(@this[i]) == -1)
                {
                    return false;
                }
            }

            return true;
        }
        public static bool IsNumeric(this string @this)
        {
            string decimalNumber = "0123456789";
            for (int i = 0; i < @this.Trim().Length; i++)
            {
                if (decimalNumber.IndexOf(@this[i]) == -1)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
