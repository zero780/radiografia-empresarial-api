﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace RadiografiaEmpresarial.Core.Utils
{
    /**
     * Tomado de: https://stackoverflow.com/questions/2920744/url-slugify-algorithm-in-c/2921135#2921135
     */
    public class SlugUtil
    {
        /// <summary>
        /// Generates a permalink slug for passed string
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns>clean slug string (ex. "some-cool-topic")</returns>
        public static string Generate(string phrase, int lenght = 45)
        {
            var s = RemoveAccent(phrase).ToLower();
            s = Regex.Replace(s, @"[^a-z0-9\s-]", "");                      // remove invalid characters
            s = Regex.Replace(s, @"\s+", " ").Trim();                       // single space
            s = s.Substring(0, s.Length <= lenght ? s.Length : lenght).Trim();      // cut and trim
            s = Regex.Replace(s, @"\s", "-");                               // insert hyphens
            return s.ToLower();
        }

        public static string RemoveAccent(string txt)
        {
            var normalizedString = txt.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
