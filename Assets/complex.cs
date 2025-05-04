using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// </summary>
public class Constants
{
    /// <summary>
    /// 圆周率π
    /// </summary>
    public const double Pi = 3.1415926536;
    /// <summary>
    /// 自然底数e
    /// </summary>
    public const double e = 2.71828182846;
    /// <summary>
    /// 欧拉常数γ
    /// </summary>
    public const double y = 0.5772156649;
    /// <summary>
    /// 混沌常数δ
    /// </summary>
    public const double o = 4.6692016091;
 
}
/// <summary>
/// 复数类型
/// </summary>
public struct Complex
{
    public double Re, Im;//实部、虚部

    public Complex(double re, double im)
    {
        Re = re;
        Im = im;
            
    }
    /// <summary>
    /// 返回共轭
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Complex operator!(Complex a)//
    {
        return new Complex(a.Re, -a.Im);
    }

    public double Modulus()//模长
    {
        return Math.Sqrt(Re * Re + Im * Im);
    }

    public double ModulusSquare()
    {
        return Re * Re + Im * Im;
    }

    public double Arg()//幅角
    {
        if (Im > 0)
            return Math.Acos(Re / (Modulus()*1.0000000000001));
        else
            return -Math.Acos(Re / (Modulus()*1.0000000000001 ));
    }

    public static Complex operator+(Complex a,Complex b)
    {
        return new Complex(a.Re + b.Re, a.Im + b.Im);
    }
    public static Complex operator +(double a, Complex b)
    {
        return new Complex(a + b.Re, b.Im);
    }
    public static Complex operator +(Complex a, double b)
    {
        return new Complex(a.Re + b, a.Im );
    }
    //a-b
    public static Complex operator-(Complex a,Complex b)
    {
        return new Complex(a.Re - b.Re, a.Im - b.Im);
    }
    public static Complex operator -(double a, Complex b)
    {
        return new Complex(a - b.Re, b.Im);
    }
    public static Complex operator -(Complex a, double b)
    {
        return new Complex(a.Re - b, a.Im);
    }
    public static Complex operator -(Complex a)
    {
        return new Complex(-a.Re, -a.Im);
    }
    //a*b
    public static Complex operator *(Complex a,Complex b)
    {
        return new Complex(a.Re * b.Re - a.Im * b.Im, a.Re * b.Im + a.Im * b.Re);
    }
    public static Complex operator *(double a,Complex b)
    {
        return new Complex(a * b.Re , a * b.Im);
    }
    public static Complex operator *(Complex a, double b)
    {
        return new Complex(a.Re * b, a.Im * b);
    }
    //a/b
    public static Complex operator/(Complex a,Complex b)
    {
        double m = b.ModulusSquare();
        return new Complex((a.Re * b.Re + a.Im * b.Im) / m, (a.Im * b.Re - a.Re * b.Im) / m);
    }
    public static Complex operator /(double a, Complex b)
    {
        double m = b.ModulusSquare();
        return new Complex(a * b.Re / m, -a * b.Im / m);
    }
    public static Complex operator /(Complex a, double b)
    {
        return new Complex(a.Re/ b, a.Im/b);
    }
    /// <summary>
    /// 将复数类型强制转换为平面向量类型
    /// </summary>
    /// <param name="a"></param>
//     public static implicit operator Vector2(Complex a)//
//     {
//         return new Vector2(a.Re, a.Im);
//     }

    public static implicit operator Complex(double a)
    {
        return new Complex(a, 0);
    }
    /// <summary>
    /// 返回复数的字符串形式
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Re.ToString("f3") + "  " + Im.ToString("f3") + " i";
    }
}
 
/// <summary>
/// 复数域的数学函数类
/// </summary>
public class MathX
{

    public static Complex Exp(Complex a)
    {
        return Math.Exp(a.Re) * new Complex(Math.Cos(a.Im), Math.Sin(a.Im));
    }
    /// <summary>
    /// 余弦函数，返回指定复数的余弦值
    /// </summary>
    /// <param name="a">一个复数</param>
    /// <returns></returns>
    public static Complex Cos(Complex a)
    {
        return new Complex(Math.Cos(a.Re) * Math.Cosh(a.Im), Math.Sin(a.Re) * Math.Sinh(a.Im));
           
    }
    /// <summary>
    /// 正弦函数，返回指定复数的正弦值
    /// </summary>
    /// <param name="a">一个复数</param>
    /// <returns></returns>
    public static Complex Sin(Complex a)
    {
        return new Complex(Math.Sin(a.Re) * Math.Cosh(a.Im), Math.Cos(a.Re) * Math.Sinh(a.Im));
    }
    /// <summary>
    /// 正切函数，返回指定复数的正切值
    /// </summary>
    /// <param name="a">一个复数</param>
    /// <returns></returns>
    public static Complex Tan(Complex a)
    {
        return Sin(a) / Cos(a);
    }
    /// <summary>
    /// 余切函数，返回指定复数的余切值
    /// </summary>
    /// <param name="a">一个复数</param>
    /// <returns></returns>
    public static Complex Cot(Complex a)
    {
        return Cos(a) / Sin(a);
    }
    /// <summary>
    /// 正割函数，返回指定复数的正割值
    /// </summary>
    /// <param name="a">一个复数</param>
    /// <returns></returns>
    public static Complex Sec(Complex a)
    {
        return 1 / Cos(a);
    }
    /// <summary>
    /// 余割函数，返回指定复数的余割值
    /// </summary>
    /// <param name="a">一个复数</param>
    /// <returns></returns>
    public static Complex Csc(Complex a)
    {
        return 1 / Csc(a);
    }
    /// <summary>
    /// 对数函数，返回以e为底的指定复数的对数
    /// </summary>
    /// <param name="a">一个复数</param>
    /// <returns></returns>
    public static Complex Log(Complex a)
    {
        double m = a.Modulus();
        if(m>0)
        {
            return new Complex(Math.Log(a.Modulus()), a.Arg());
        }
        else
        {
            return new Complex(0, a.Arg());
        }
    }
    /// <summary>
    /// 返回指定复数的平方根
    /// </summary>
    /// <param name="a">一个复数</param>
    /// <returns></returns>
    public static Complex Sqrt(Complex a)
    {
        double m = a.Modulus();
        return new Complex(Math.Sqrt((m + a.Re) / 2), a.Im > 0 ? Math.Sqrt((m - a.Re) / 2) : -Math.Sqrt((m - a.Re) / 2));     
    }
    /// <summary>
    /// 指数函数，返回指定复数为底，指定复数次幂
    /// </summary>
    /// <param name="a">指数</param>
    /// <param name="b">底数</param>
    /// <returns></returns>
    public static Complex Pow(Complex a,Complex b)
    {
        return Exp(b * Log(a));
    }

    public static Complex Pow2(double a, Complex b)
    {
        double Loge = Math.Log(a);

        double t = Math.Exp(Loge);

        return Exp(b * Loge);
    }

    /// <summary>
    /// 返回指定底的对数
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Complex Log(Complex a,Complex b)
    {
        return Log(a) / Log(b);
    }
    /// <summary>
    /// 反正弦函数
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Complex Asin(Complex a)
    {
        Complex i = new Complex(0, 1);
        return -i * Log(Sqrt(1 - a * a) + i * a);
    }
    /// <summary>
    /// 反余弦函数
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Complex Acos(Complex a)
    {
        Complex i = new Complex(0, 1);
        return -i * Log(a + i * Sqrt(1 - a * a));
    }
    /// <summary>
    /// 反正切函数
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Complex Atan(Complex a)
    {
        Complex i = new Complex(0, 1);
        return 0.5 * i * Log((i + a) / (i - a));
    }
}
