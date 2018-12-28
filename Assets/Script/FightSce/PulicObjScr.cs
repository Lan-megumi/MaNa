using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulicObjScr : MonoBehaviour {
	public static PulicObjScr Instance;

    public static PulicObjScr _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(PulicObjScr))as PulicObjScr;
            }
            return Instance;
        }
    }
//--------------------------------------
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Test(double[] d){
		
	}
}
