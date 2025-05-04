using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Numerics;
public class zetafunction : MonoBehaviour {

	// Use this for initialization


    Complex ComputeGamma(Complex Number, double xDelta = 0.005, double max = 20.0)
    {
        if (Number.Re > 0)
        {
            return ComputeGammaPositive(Number, xDelta, max);
        }
        else
        {
            return ComputeGamma(Number + 1, xDelta, max) / Number;
        }
    }

    Complex ComputeGamma2(Complex z, int nstep = 4000 )
    {
        Complex total = new Complex(1, 0);
        for (int n = 1; n < nstep; n++)
        {
            Complex T = MathX.Pow2((1 + n) / (double)n, z);
            Complex M = (1 + z / n);

            Complex result = T / M;

            total *= result;
        }

        return total / z;
    }

    Complex ComputeGammaPositive(Complex Number, double xDelta = 0.05, double max = 10.0)
    {
        Complex s = Number - 1;
        Complex total = new Complex(0, 0);
        for (double x = xDelta; x < max; x += xDelta)
        {
            double Df = System.Math.Exp(-x) * xDelta;
            Complex Tnew = MathX.Pow2(x, s);
            total = total + Tnew * Df;
        }
        return total;
    }

    Complex ComputeZetaBigThanOne(Complex value, int nstep)
    {
        Complex total = new Complex(0, 0);
        for (int n = 1; n < nstep; n++)
        {
            total += 1 / MathX.Pow2((double)n, value);
        }

        return total;
    }

    Complex ComputeZetaR0_1(Complex value, int nstep)
    {
        Complex total = new Complex(0, 0);

        int nsign = -1;
        for (int n = 1; n < nstep; n++)
        {
            nsign = -nsign;
			total += nsign / MathX.Pow(new Complex(n, z), value);
        }

		return total;// / (1 - MathX.Pow(new Complex(2, z), 1 - s));
    }


    Complex ComputeZetaContinue(Complex s, int nstep = 1000)
    {
        if (s.Re > 1)
        {
            return ComputeZetaBigThanOne(s, nstep);
        }
        else if (s.Re > 0)
        {
            return ComputeZetaR0_1(s, nstep);
        }
        else
        {
            return  2*
                MathX.Pow2(2* Constants.Pi, s-1) *
                MathX.Sin((Constants.Pi * s) / 2) *
				ComputeZetaContinue(1-s, nstep);
        }
    }

    Vector3 ComputeZetaContinue(Vector3 s, int nstep = 1000)
    {
        Complex T = ComputeZetaContinue(new Complex(s.x, s.y), nstep);

		return new Vector3((float)T.Re, (float)T.Im, s.z);
    }


	void Start ()
    {

	}
    double LastxOffSet = 0.5f;
    public double xOffSet = 0.5f;
    public double xSize = 0.1f;
    public double ySize = 11;
    public double xDelta = 0.1f;
    public double yDelta = 0.5f;
    public double z = 0;
	public double re = 0.5f;
    public int CStep = 100;
    public double Inalpha = 1.0f;
    public double Outalpha = 1.0f;

    public bool bDrawOrignal = false;
    public bool bDrawCompute = true;


    List<List<Vector3>> TListOri = new List<List<Vector3>>();

    List<List<Vector3>> TList = new List<List<Vector3>>();

    void Compute(double Xstart, double TxDelta, double TyDelta, bool bForceUpdate = false)
    {
        int nXCount = 0;
        int nYCount = 0;

        for (double i = Xstart - xSize; i <= Xstart+ xSize; i += TxDelta)
        {
            nXCount++;
        }
        for (double k = -ySize; k < ySize; k += TyDelta)
        {
            nYCount++;
        }

        int nTotalCount = TList.Count * (TList.Count > 0 ? TList[0].Count : 0);

        if( nTotalCount != nXCount * nYCount || bForceUpdate)
        {
            TList.Clear();
            TListOri.Clear();

            for (double i = Xstart - xSize; i <= Xstart+ xSize; i += TxDelta)
            {
                List<Vector3> TlOri = new List<Vector3>();
                List<Vector3> Tl = new List<Vector3>();

                TList.Add(Tl);
                TListOri.Add(TlOri);

                for (double k = -ySize; k < ySize; k += TyDelta)
                {

                    Vector3 V = new Vector3((float)i, (float)k, 11);

                    TlOri.Add(V * (float)Inalpha);

                    // Vector2
                    Tl.Add(ComputeZetaContinue(V, CStep)* (float)Outalpha);
                }
            }
        }
    }

    int a = 0;
	void Update ()
    {

        a++;
        if (a > 10&& false)
        {
            //a = 0;
          //  Compute();


			Vector3 V1 = Vector3.zero;
			bool bf = true;
			for (double i = -0; i <= ySize; i += (yDelta < 0.01f ? 0.01f : yDelta)) 
			{
				//Complex nStart = new Complex(0.5,i);，
				Vector3 V = ComputeZetaContinue (new Vector3((float)re, (float)i, (float)z), CStep);
				V.z = (float)z;
				if( !bf )
				{
					Debug.DrawLine(V, V1,Color.blue);
				}
				bf = false;

				V1 = V;

			}

        }

      //  return;
        Compute(xOffSet,xDelta < 0.01f ? 0.01f: xDelta, yDelta < 0.01f ? 0.01f : yDelta, LastxOffSet != xOffSet);

        LastxOffSet = xOffSet;
        if (bDrawCompute )
        {
            DrawGrid(TList);
        }

        if (bDrawOrignal)
            DrawGrid(TListOri);

        return;
	}
    //formula

    static void DrawGrid(List<List<Vector3>> Vecs)
    {
        Color Tyellow = Color.yellow;
        Color Twhite = Color.white;
        int nXCount = Vecs.Count;
        for (int i = 0; i < nXCount; i++)
        {
            List<Vector3> CurrentVector = Vecs[i];
            int nYCount = CurrentVector.Count;

            List<Vector3> CurrentiAdd1 = i == nXCount - 1 ? Vecs[0] : Vecs[i + 1];

            for (int k = 0; k < nYCount; k++)
            {
                Vector3 VStart = CurrentVector[k];
                if (i != nXCount - 1)
                {
                    Color TColor = ( k == 0 || k == nYCount - 1 ) ? Tyellow : Twhite;
                    Debug.DrawLine(VStart, CurrentiAdd1[k] , TColor);
                }

                if (k != nYCount - 1)
                {
                    Color TColor = (i == 0 || i == nXCount - 1) ? Tyellow : Twhite;
                    Debug.DrawLine(VStart, CurrentVector[k + 1] , TColor);
                }

            }
        }
    }

}
