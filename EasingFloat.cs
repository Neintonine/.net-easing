/*
 * Package: Easing
 * Author: Michel Fedde
 * 
 * This class implements the different easing function.
 * While I may be the author of this class, the actual formulars 
 */

namespace Easing;

public static partial class Easing
{
    private const float F_C1 = 1.70158f;
    private const float F_C2 = Easing.F_C1 + 1.525f;
    private const float F_C3 = Easing.F_C1 + 1f;
    private const float F_C4 = (2 * MathF.PI) / 3;
    private const float F_C5 = (2 * MathF.PI) / 4.5f;

    private const float F_N1 = 7.5625f;
    private const float F_D1 = 2.75f;
    
    #region | Ease In |

    public static float InSine(float x)
    {
        return 1 - MathF.Cos((x * MathF.PI) / 2);
    }
    
    public static float InQuad(float x)
    {
        return x * x;
    }
    
    public static float InCubic(float x)
    {
        return x * x * x;
    }
    public static float InQuart(float x)
    {
        return x * x * x * x;
    }
    public static float InQuint(float x)
    {
        return x * x * x * x * x;
    }

    public static float InExpo(float x)
    {
        return x == 0 ? 0 : MathF.Pow(2, 10 * x - 10);
    }

    public static float InCirc(float x)
    {
        return 1 - MathF.Sqrt(1 - (x * x));
    }

    public static float InBack(float x)
    {
        return Easing.F_C3 * x * x * x - Easing.F_C1 * x * x;
    }

    public static float InElastic(float x)
    {
        if (x == 0)
        {
            return 0;
        }
        if (x >= 1)
        {
            return 1;
        }

        return -MathF.Pow(2, 10 * x - 10) * MathF.Sin((x * 10 - 10.75f) * Easing.F_C4);
    }

    public static float InBounce(float x)
    {
        return 1 - Easing.OutBounce(1 - x);
    }
    
    #endregion

    #region | Ease Out |

    public static float OutSine(float x)
    {
        return MathF.Sin((x * MathF.PI) / 2);
    }

    public static float OutQuad(float x)
    {
        return 1 - (1 - x) * (1 - x);
    }
    public static float OutCubic(float x)
    {
        return 1 - (1 - x) * (1 - x) * (1 - x);
    }
    public static float OutQuat(float x)
    {
        return 1 - (1 - x) * (1 - x) * (1 - x) * (1 - x);
    }
    public static float OutQuint(float x)
    {
        return 1 - (1 - x) * (1 - x) * (1 - x) * (1 - x) * (1 - x);
    }
    public static float OutExpo(float x)
    {
        return x >= 1 ? 1 : 1 - MathF.Pow(2, -10 * x);
    }

    public static float OutCirc(float x)
    {
        return MathF.Sqrt(1 - MathF.Pow(x - 1, 2));
    }
    public static float OutBack(float x)
    {
        return 1 + Easing.F_C3 * (x - 1) * (x - 1) * (x - 1) + Easing.F_C1 * (x - 1) * (x - 1);
    }

    public static float OutElastic(float x)
    {
        if (x == 0)
        {
            return 0;
        }
        if (x >= 1)
        {
            return 1;
        }
        
        return MathF.Pow(2, -10 * x) * MathF.Sin((x * 10 - 0.75f) * Easing.F_C4) + 1;
    }

    public static float OutBounce(float x)
    {
        if (x < 1 / Easing.F_D1)
        {
            return Easing.F_N1 * x * x;
        }

        if (x < 2 / Easing.F_D1)
        {
            x -= 1.5f / Easing.F_D1;
            return Easing.F_N1 * x * x + 0.75f;
        }

        if (x < 2.5 / Easing.F_D1)
        {
            x -= 2.25f / Easing.F_D1;
            return Easing.F_N1 * x * x + 0.9375f;
        }

        x -= 2.625f / Easing.F_D1;
        return Easing.F_N1 * x * x + 0.984375f;
    }
    
    #endregion

    #region InOut

    public static float InOutSine(float x)
    {
        return -(MathF.Cos(MathF.PI * x) - 1) / 2;
    }

    public static float InOutQuad(float x)
    {
        return x < 0.5 ? 2 * x * x : 1 - MathF.Pow(-2 * x + 2, 2) / 2;
    }
    public static float InOutCubic(float x)
    {
        return x < 0.5 ? 4 * x * x * x : 1 - MathF.Pow(-2 * x + 2, 3) / 2;
    }
    public static float InOutQuart(float x)
    {
        return x < 0.5 ? 8 * x * x * x * x : 1 - MathF.Pow(-2 * x + 2, 4) / 2;
    }
    public static float InOutQuint(float x)
    {
        return x < 0.5 ? 16 * x * x * x * x * x : 1 - MathF.Pow(-2 * x + 2, 5) / 2;
    }
    public static float InOutExpo(float x)
    {
        if (x == 0)
        {
            return 0;
        }
        if (x >= 1)
        {
            return 1;
        }

        return x < 0.5 ? MathF.Pow(2, 20 * x - 10) / 2 : (2 - MathF.Pow(2, -20 * x + 10)) / 2;
    }

    public static float InOutCirc(float x)
    {
        return x < 0.5
            ? (1 - MathF.Sqrt(1 - MathF.Pow(2 * x, 2))) / 2
            : (MathF.Sqrt(1 - MathF.Pow(-2 * x + 2, 2)) + 1) / 2;
    }

    public static float InOutBack(float x)
    {
        if (x < 0.5)
        {
            return (MathF.Pow(2 * x, 2) * ((Easing.F_C2 + 1) * 2 * x - Easing.F_C2)) / 2;
        }
        
        return (MathF.Pow(2 * x - 2, 2) * ((Easing.F_C2 + 1) * (x * 2 - 2) + Easing.F_C2) + 2) / 2;
    }

    public static float InOutElastic(float x)
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
            return -(MathF.Pow(2, 20 * x - 10) * MathF.Sin((20 * x - 11.125f) * Easing.F_C5)) / 2;
        }

        return (MathF.Pow(2, -20 * x + 10) * MathF.Sin((20 * x - 11.125f) * Easing.F_C5)) / 2 + 1;
    }

    public static float InOutBounce(float x)
    {
        return x < 0.5
            ? (1 - OutBounce(1 - 2 * x)) / 2
            : (1 + OutBounce(2 * x - 1)) / 2;
    }

    #endregion

}