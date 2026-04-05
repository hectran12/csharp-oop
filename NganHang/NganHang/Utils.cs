using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHang
{
    internal class Utils
    {
        private static string prefixSoTaiKhoan = "NPNHBANK";
        private static string prefixMaKh = "NHBANK_";

        public static string FormatFullName(string fullName)
        {
            try
            {
                string[] words = fullName.Split(' ');
                if (words.Length > 0)
                {
                    string fullNameFormat = "";

                    for (int i = 0; i < words.Length; i++)
                    {
                        string word = words[i];
                        fullNameFormat += word[0].ToString().ToUpper();
                        for (int y = 1; y < word.Length; y++) fullNameFormat += word[y];
                        if (i != words.Length - 1) fullNameFormat += " ";
                    }
                    return fullNameFormat;
                }
                else
                {
                    return fullName;
                }
            }
            catch (Exception e)
            {
                return fullName;
            }
        }

        public static bool checkValidPhoneNumber (string phoneNumber)
        {
            if (phoneNumber.Length != 10) return false;
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (char.IsDigit(phoneNumber[i]) == false) return false;
            }
            return true;
        }

        public static bool checkValidCCCD (string CCCD)
        {
            if (CCCD.Trim().Length != 12) return false;
            return true;
        }

        public static int randomNumber (int min, int max)
        {
            Random rd = new Random();
            int num = rd.Next(min, max);
            return num;
        }

        public static string RandomSoTaiKhoan()
        {
            return prefixSoTaiKhoan + randomNumber(1000000, 9999999);
        }
        public static string RandomMaKH ()
        {
            return prefixMaKh + randomNumber(1000000, 9999999);
        }
    }
}
