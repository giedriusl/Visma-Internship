using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public enum Gender : int
    {
        Male = 1,
        Female = 2
    }

    public enum Weekday
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MapValueToEnum<Gender, int>(3));
            Console.ReadLine();
        }

        public static TEnum MapValueToEnum<TEnum, A>(A value)
            where TEnum : struct
        {
            TEnum result;
            if(Enum.TryParse(value.ToString(), out result))
            {
                return result;
            }
            return result;
        }

        public static Gender MapIntToGender(int value)
        {
            Gender result;
            if (!Enum.TryParse(value.ToString(), out result))
            {
                throw new Exception($"Value '{value}' is not part of Gender enum");
            }

            return result;
        }

        public static Gender MapStringToGender(string value)
        {
            Gender result;
            if (!Enum.TryParse(value, out result))
            {
                throw new Exception($"Value '{value}' is not part of Gender enum");
            }

            return result;
        }

        public static Weekday MapStringToWeekday(string value)
        {
            Weekday result;
            if (!Enum.TryParse(value, out result))
            {
                throw new Exception($"Value '{value}' is not part of Weekday enum");
            }

            return result;
        }
    }
}
