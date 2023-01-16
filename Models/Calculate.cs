using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMsurgeCarentCalculater.Models
{
    public class Calculate
    {

            public static double ConvertRPN(int swrpn)
            {
                switch (swrpn)
                {
                    case 1: return 3.605;
                    case 2: return 3.668;
                    case 3: return 3.734;
                    case 4: return 3.802;
                    case 5: return 3.872;
                    case 6: return 3.945;
                    case 7: return 4.021;
                    case 8: return 4.099;
                    case 9: return 4.182;
                    case 10: return 4.182;
                    case 11: return 4.182;
                    case 12: return 4.267;
                    case 13: return 4.356;
                    case 14: return 4.449;
                    case 15: return 4.546;
                    case 16: return 4.647;
                    case 17: return 4.752;
                    case 18: return 4.863;
                    case 19: return 4.978;

                }
                return swrpn;
            }

            public static double GetU27_5(double U110, double rpn)
            {
                return U110 * Math.Sqrt(3) / rpn;

            }


            public static double GetSurgeCurent(double U1, double U2, double R)
            {

                return (U1 - U2) / R;

            }
        }
    }

