using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class complexvisualize : MonoBehaviour {


    public Vector2 C1;
    public Vector2 C2;

	public int nstetp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {








	}
	Vector3 GetPoint( Complex s )
	{

		return new Vector3 ((float)s.Re, (float)s.Im, 0);
	}



    void OnDrawGizmosSelected()
    {
       // Gizmos.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
       // Gizmos.DrawWireCube(gameObject.GetComponent<Renderer>().bounds.center, gameObject.GetComponent<Renderer>().bounds.size);
		Complex a = new Complex(C1.x, C1.y);
		if( false )
		{
			//Complex a = new Complex(C1.x, C1.y);
			Complex b = new Complex(C2.x, C2.y);

			Complex c = MathX.Pow(a , b);
			//c = a * b;
			Complex d = MathX.Log(a );
			//Complex e = b * d ;
		
			//Complex c = a * b;


			Vector3 Vpos = new Vector3((float)c.Re, (float)c.Im, 0);

	        Gizmos.DrawSphere(Vpos, 0.1f);

	        Gizmos.DrawLine(Vector3.zero, Vpos);
			Gizmos.color = Color.red;
			Gizmos.DrawLine(Vector3.zero, new Vector3((float)a.Re, (float)a.Im, 0));
			Gizmos.color = Color.green;
			Gizmos.DrawLine(Vector3.zero, new Vector3((float)b.Re, (float)b.Im, 0));
			//Gizmos.color = Color.blue;
			Gizmos.DrawLine(Vector3.zero, new Vector3((float)c.Re, (float)c.Im, 0));


			//Complex d = MathX.Log(a );
		}

		Complex Total = new Complex (0, 0);
		Complex TotalRed = Total;
		Complex TotalBule = Total;

		int bsign = 1;
		for (int n = 1; n < nstetp; ++n) 
		{
			var T = MathX.Pow2(n, -a) * bsign;

			var nT = T + Total;
			Gizmos.color = Color.white;
			Gizmos.DrawLine(GetPoint(Total), GetPoint(nT));

			if (bsign > 0) {
				var nb =TotalBule + T * bsign;
				Gizmos.color = Color.blue;
				Gizmos.DrawLine(GetPoint(TotalBule), GetPoint(nb));
				TotalBule = nb;
			} else
			{
				var nr = TotalRed + T * bsign;
				Gizmos.color = Color.red;
				Gizmos.DrawLine(GetPoint(TotalRed), GetPoint(nr));
				TotalRed = nr;
			}
			//Gizmos.DrawLine(GetPoint(TotalLast), GetPoint(nT));
			//
			//GetPoint

			Total = nT;
			bsign = 0 - bsign;
		}


    }
}
