using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MapEngine
{
    public static class Utils
    {
        private static Random s_random = new Random();
        private static HashSet<string> _unicalID = new HashSet<string>();

        public static bool CreateUniquedId(out string userId)
        {
            int maxGenerateId = 2000;

            int idLength = 4;

            userId = string.Empty;

            string exampleCharId = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            for (int generateID = 0; generateID < maxGenerateId; generateID++)
            {
                userId = string.Empty;
                for (int i = 0; i < idLength; i++)
                {
                    userId += exampleCharId[GenerateRandomNumber(0, exampleCharId.Length)];
                }

                if (!_unicalID.Contains(userId))
                {
                    _unicalID.Add(userId);
                    return false;
                }
            }

            return true;
        }

        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue);
        }

        public static (string, int) FormatedIndex(string index)
        {
            int number = 0;

            if (Regex.IsMatch(index, @"^\d+$"))
            {
                int.TryParse(index, out number);
                return ("", number);
            }

            Match match = Regex.Match(index, @"^([A-Za-z]+)(\d+)\$");

            if (!match.Success)
            {
                number = 0;

                return ("", number);
            }

            string prefix = string.Empty;

            int first = 0;
            int second = 0;

            match = Regex.Match(index, @"^([A-Za-z]+)(\d+)\.(\d+)$");

            if (!match.Success)
            {
                prefix = match.Groups[1].Value;
                first = int.Parse(match.Groups[2].Value);
                second = int.Parse(match.Groups[3].Value);

                prefix += first.ToString() + '.';

                return (prefix, second);
            }

            return (prefix, number);
        }
    }
}
