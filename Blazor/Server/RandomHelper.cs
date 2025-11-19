using System.Security.Cryptography;
namespace E_Voting
{
    public static class RandomHelper
    {
        private static readonly char[] values = {
            'a','b','c','d','e','f','g','h','i','j','k','l','m',
            'n','o','p','q','r','s','t','u','v','w','x','y','z',

            'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };

        public static string GetToken(int length)
        {
            string result = "";
            for(int i = 0; i < length; i++)
            {
                result += GetRandomChar();
            }

            return result;
        }

        private static char GetRandomChar()
        {
            // get random number (unpredictable)
            byte[] buffer = new byte[4];
            RandomNumberGenerator.Fill(buffer);

            // ensure it is positive
            int index = BitConverter.ToInt32(buffer, 0);
            if(index < 0) 
            { 
                index = index * -1;
            }

            // get a number between 0 and values.Length - 1 (modulo)
            return values[index % values.Length];
        }
    }
}
