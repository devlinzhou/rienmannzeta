using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// </summary>
public class Constants
{
    /// <summary>
    /// Բ���ʦ�
    /// </summary>
    public const double Pi = 3.1415926536;
    /// <summary>
    /// ��Ȼ����e
    /// </summary>
    public const double e = 2.71828182846;
    /// <summary>
    /// ŷ��������
    /// </summary>
    public const double y = 0.5772156649;
    /// <summary>
    /// ���糣����
    /// </summary>
    public const double o = 4.6692016091;
 
}
/// <summary>
/// ��������
/// </summary>
public struct Complex
{
    public double Re, Im;//ʵ�����鲿

    public Complex(double re, double im)
    {
        Re = re;
        Im = im;
            
    }
    /// <summary>
    /// ���ع���
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Complex operator!(Complex a)//
    {
        return new Complex(a.Re, -a.Im);
    }

    public double Modulus()//ģ��
    {
        return Math.Sqrt(Re * Re + Im * Im);
    }

    public double ModulusSquare()
    {
        return Re * Re + Im * Im;
    }

    public double Arg()//����
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
    /// ����������ǿ��ת��Ϊƽ����������
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
    /// ���ظ������ַ�����ʽ
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Re.ToString("f3") + "  " + Im.ToString("f3") + " i";
    }
}
 
/// <summary>
/// ���������ѧ������
/// </summary>
public class MathX
{

    public static Complex Exp(Complex a)
    {
        return Math.Exp(a.Re) * new Complex(Math.Cos(a.Im), Math.Sin(a.Im));
    }
    /// <summary>
    /// ���Һ���������ָ������������ֵ
    /// </summary>
    /// <param name="a">һ������</param>
    /// <returns></returns>
    public static Complex Cos(Complex a)
    {
        return new Complex(Math.Cos(a.Re) * Math.Cosh(a.Im), Math.Sin(a.Re) * Math.Sinh(a.Im));
           
    }
    /// <summary>
    /// ���Һ���������ָ������������ֵ
    /// </summary>
    /// <param name="a">һ������</param>
    /// <returns></returns>
    public static Complex Sin(Complex a)
    {
        return new Complex(Math.Sin(a.Re) * Math.Cosh(a.Im), Math.Cos(a.Re) * Math.Sinh(a.Im));
    }
    /// <summary>
    /// ���к���������ָ������������ֵ
    /// </summary>
    /// <param name="a">һ������</param>
    /// <returns></returns>
    public static Complex Tan(Complex a)
    {
        return Sin(a) / Cos(a);
    }
    /// <summary>
    /// ���к���������ָ������������ֵ
    /// </summary>
    /// <param name="a">һ������</param>
    /// <returns></returns>
    public static Complex Cot(Complex a)
    {
        return Cos(a) / Sin(a);
    }
    /// <summary>
    /// �����������ָ������������ֵ
    /// </summary>
    /// <param name="a">һ������</param>
    /// <returns></returns>
    public static Complex Sec(Complex a)
    {
        return 1 / Cos(a);
    }
    /// <summary>
    /// ����������ָ�����������ֵ
    /// </summary>
    /// <param name="a">һ������</param>
    /// <returns></returns>
    public static Complex Csc(Complex a)
    {
        return 1 / Csc(a);
    }
    /// <summary>
    /// ����������������eΪ�׵�ָ�������Ķ���
    /// </summary>
    /// <param name="a">һ������</param>
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
    /// ����ָ��������ƽ����
    /// </summary>
    /// <param name="a">һ������</param>
    /// <returns></returns>
    public static Complex Sqrt(Complex a)
    {
        double m = a.Modulus();
        return new Complex(Math.Sqrt((m + a.Re) / 2), a.Im > 0 ? Math.Sqrt((m - a.Re) / 2) : -Math.Sqrt((m - a.Re) / 2));     
    }
    /// <summary>
    /// ָ������������ָ������Ϊ�ף�ָ����������
    /// </summary>
    /// <param name="a">ָ��</param>
    /// <param name="b">����</param>
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
    /// ����ָ���׵Ķ���
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Complex Log(Complex a,Complex b)
    {
        return Log(a) / Log(b);
    }
    /// <summary>
    /// �����Һ���
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Complex Asin(Complex a)
    {
        Complex i = new Complex(0, 1);
        return -i * Log(Sqrt(1 - a * a) + i * a);
    }
    /// <summary>
    /// �����Һ���
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Complex Acos(Complex a)
    {
        Complex i = new Complex(0, 1);
        return -i * Log(a + i * Sqrt(1 - a * a));
    }
    /// <summary>
    /// �����к���
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Complex Atan(Complex a)
    {
        Complex i = new Complex(0, 1);
        return 0.5 * i * Log((i + a) / (i - a));
    }
}
