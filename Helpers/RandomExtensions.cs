using System;

namespace PatientTestApplication.Helpers
{
    public static class RandomExtensions
    {
        public static bool NextBool(this Random rnd, double trueValue = 0.5)
        {
            return rnd.NextDouble() < trueValue;
        }


        private const string charatcters = "QWERTYUIOPLKJHGFDSAZXCVBNM";

        public static char NextCharacter(this Random rnd)
        {
            return charatcters[rnd.Next(0, charatcters.Length)];
        }
    }
}