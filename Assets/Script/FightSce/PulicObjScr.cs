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
    ///<summary>
    /// 储存敌人的数组
    ///<summary>
    public GameObject[] EnemyObj;
     ///<summary>
    /// 储存敌人的数组
    ///<summary>
    public GameObject[] PlayerObj;

    public GameObject EnemyPanel;
	// Use this for initialization
	void Start () {

	}
	
     private void UpdateObj(){
         //该方法为更新同步的数据
         //更新敌人
         
     }
     public GameObject[] Re_PlayerObj(){
         UpdateObj();
         return PlayerObj;
     }
    public GameObject[] Re_EnemyObj(){
         UpdateObj();
         return EnemyObj;
     }
	public void Test(double[] d){
		
	}
}
