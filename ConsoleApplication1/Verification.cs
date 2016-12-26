using System;

namespace ConsoleApplication1
{
    public class Verification
    {
        /// <summary>
        ///     Compare two bools; default throws exeption = false
        /// </summary>
        /// <param name="valueToVerify"></param>
        /// <param name="valueToCompare"></param>
        /// <param name="message"></param>
        /// <param name="throwsException"></param>
        /// <returns></returns>
        public static bool VerifyBoolean(bool valueToVerify, bool valueToCompare, string message,
            bool throwsException = false)
        {
            Console.WriteLine("VerifyBoolean " + valueToVerify + " vs " + valueToCompare + " with message " + message);
            if (valueToVerify != valueToCompare)
            {
                Console.WriteLine("Verification failed!");
                if (throwsException)
                    throw new Exception("Verification failed");
                return false;
            }
            Console.WriteLine("Verification successful!");
            return true;
        }
    }
}