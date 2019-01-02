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

    public Transform EnemyPanel;
	// Use this for initialization
	void Start () {

	}
	
     public void UpdateObj(){
         //该方法为更新同步的数据
         //更新敌人
         int d = EnemyPanel.GetChildCount();
         List<GameObject> LinshiEnemyObj=new List<GameObject>();
        //  Debug.Log("1:"+d);
         for(int i=0;i<d;i++){
            Transform linshiTran=EnemyPanel.GetChild(i);
            if(linshiTran.gameObject.activeInHierarchy==false) {
                
            }else{
                LinshiEnemyObj.Add(linshiTran.gameObject);
                Debug.Log(i+":"+LinshiEnemyObj[i]);
                EnemyObj[i]=linshiTran.gameObject;
            }
            
         }

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
