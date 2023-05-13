namespace Easing;

public static partial class Easing
{
    private const double D_C1 = 1.70158;
    private const double D_C2 = Easing.D_C1 + 1.525;
    private const double D_C3 = Easing.D_C1 + 1;
    private const double D_C4 = (2 * Math.PI) / 3;
    private const double D_C5 = (2 * Math.PI) / 4.5;

    private const double D_N1 = 7.5625;
    private const double D_D1 = 2.75;
    
    #region | Ease In |

    public static double InSine(double x)
    {
        return 1 - Math.Cos((x * Math.PI) / 2);
    }
    
    public static double InQuad(double x)
    {
        return x * x;
    }
    
    public static double InCubic(double x)
    {
        return x * x * x;
    }
    public static double InQuart(double x)
    {
        return x * x * x * x;
    }
    public static double InQuint(double x)
    {
        return x * x * x * x * x;
    }

    public static double InExpo(double x)
    {
        return x == 0 ? 0 : Math.Pow(2, 10 * x - 10);
    }

    public static double InCirc(double x)
    {
        return 1 - Math.Sqrt(1 - (x * x));
    }

    public static double InBack(double x)
    {
        return Easing.D_C3 * x * x * x - Easing.D_C1 * x * x;
    }

    public static double InElastic(double x)
    {
        if (x == 0)
        {
            return 0;
        }
        if (x >= 1)
        {
            return 1;
        }

        return -Math.Pow(2, 10 * x - 10) * Math.Sin((x * 10 - 10.75) * Easing.D_C4);
    }

    public static double InBounce(double x)
    {
        return 1 - Easing.OutBounce(1 - x);
    }
    
    #endregion

    #region | Ease Out |

    public static double OutSine(double x)
    {
        return Math.Sin((x * Math.PI) / 2);
    }

    public static double OutQuad(double x)
    {
        return 1 - (1 - x) * (1 - x);
    }
    public static double OutCubic(double x)
    {
        return 1 - (1 - x) * (1 - x) * (1 - x);
    }
    public static double OutQuat(double x)
    {
        return 1 - (1 - x) * (1 - x) * (1 - x) * (1 - x);
    }
    public static double OutQuint(double x)
    {
        return 1 - (1 - x) * (1 - x) * (1 - x) * (1 - x) * (1 - x);
    }
    public static double OutExpo(double x)
    {
        return x >= 1 ? 1 : 1 - Math.Pow(2, -10 * x);
    }

    public static double OutCirc(double x)
    {
        return Math.Sqrt(1 - Math.Pow(x - 1, 2));
    }
    public static double OutBack(double x)
    {
        return 1 + Easing.D_C3 * (x - 1) * (x - 1) * (x - 1) + Easing.D_C1 * (x - 1) * (x - 1);
    }

    public static double OutElastic(double x)
    {
        if (x == 0)
        {
            return 0;
        }
        if (x >= 1)
        {
            return 1;
        }
        
        return Math.Pow(2, -10 * x) * Math.Sin((x * 10 - 0.75) * Easing.D_C4) + 1;
    }

    public static double OutBounce(double x)
    {
        if (x < 1 / Easing.D_D1)
        {
            return Easing.D_N1 * x * x;
        }

        if (x < 2 / Easing.D_D1)
        {
            x -= 1.5 / Easing.D_D1;
            return Easing.D_N1 * x * x + 0.75;
        }

        if (x < 2.5 / Easing.D_D1)
        {
            x -= 2.25 / Easing.D_D1;
            return Easing.D_N1 * x * x + 0.9375;
        }

        x -= 2.625 / Easing.D_D1;
        return Easing.D_N1 * x * x + 0.984375;
    }
    
    #endregion

    #region InOut

    public static double InOutSine(double x)
    {
        return -(Math.Cos(Math.PI * x) - 1) / 2;
    }

    public static double InOutQuad(double x)
    {
        return x < 0.5 ? 2 * x * x : 1 - Math.Pow(-2 * x + 2, 2) / 2;
    }
    public static double InOutCubic(double x)
    {
        return x < 0.5 ? 4 * x * x * x : 1 - Math.Pow(-2 * x + 2, 3) / 2;
    }
    public static double InOutQuart(double x)
    {
        return x < 0.5 ? 8 * x * x * x * x : 1 - Math.Pow(-2 * x + 2, 4) / 2;
    }
    public static double InOutQuint(double x)
    {
        return x < 0.5 ? 16 * x * x * x * x * x : 1 - Math.Pow(-2 * x + 2, 5) / 2;
    }
    public static double InOutExpo(double x)
    {
        if (x == 0)
        {
            return 0;
        }
        if (x >= 1)
        {
            return 1;
        }

        return x < 0.5 ? Math.Pow(2, 20 * x - 10) / 2 : (2 - Math.Pow(2, -20 * x + 10)) / 2;
    }

    public static double InOutCirc(double x)
    {
        return x < 0.5
            ? (1 - Math.Sqrt(1 - Math.Pow(2 * x, 2))) / 2
            : (Math.Sqrt(1 - Math.Pow(-2 * x + 2, 2)) + 1) / 2;
    }

    public static double InOutBack(double x)
    {
        if (x < 0.5)
        {
            return (Math.Pow(2 * x, 2) * ((Easing.D_C2 + 1) * 2 * x - Easing.D_C2)) / 2;
        }
        
        return (Math.Pow(2 * x - 2, 2) * ((Easing.D_C2 + 1) * (x * 2 - 2) + Easing.D_C2) + 2) / 2;
    }

    public static double InOutElastic(double x)
    {
        if (x == 0)
        {
            return 0;
        }
        if (x >= 1)
        {
            return 1;
        }

        if (x < 0.5)
        {
            return -(Math.Pow(2, 20 * x - 10) * Math.Sin((20 * x - 11.125) * Easing.D_C5)) / 2;
        }

        return (Math.Pow(2, -20 * x + 10) * Math.Sin((20 * x - 11.125) * Easing.D_C5)) / 2 + 1;
    }

    public static double InOutBounce(double x)
    {
        return x < 0.5
            ? (1 - OutBounce(1 - 2 * x)) / 2
            : (1 + OutBounce(2 * x - 1)) / 2;
    }

    #endregion

}