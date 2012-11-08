using System;
using System.Collections.Generic;
using System.Text;

namespace MvcApplication1.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetFormattedExceptionMessage(this Exception ex)
        {
            var results = new StringBuilder();
            var messages = GetMessages(ex);

            for (var i = 0; i < messages.Count; i++)
            {
                if (i == 0)
                    results.Append(string.Format("Exception: {0}", messages[i]));
                else
                    results.Append(string.Format(" : Inner Exception {1}: {0}", messages[i], i));
            }

            return results.ToString();
        }

        private static List<string> GetMessages(Exception ex)
        {
            var results = new List<string>
            {
                ex.Message
            };

            if (ex.InnerException != null)
                results.AddRange(GetMessages(ex.InnerException));

            return results;
        } 
    }
}