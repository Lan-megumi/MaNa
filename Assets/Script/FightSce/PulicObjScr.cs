using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
/// 该脚本可获取到全局目标的（按照阵营划分）的目标的物体
///</summary>
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
	void Awake () {
        EnemyObj=new GameObject[4];
        PlayerObj=new GameObject[3];
	}
	///<summary>
    /// 该方法为更新同步的数据,可以通过该脚本下的返回方法调用
    ///</summary>
     public void UpdateObj(){
        
         //更新敌人
         int d = EnemyPanel.childCount;
        //  Debug.Log("d:"+d);
         EnemyObj=new GameObject[d];
         List<GameObject> LinshiEnemyObj=new List<GameObject>();
        //  Debug.Log("1:"+d);
         for(int i=0;i<d;i++){
            Transform linshiTran=EnemyPanel.GetChild(i);
            if(linshiTran.gameObject.activeInHierarchy==false){

            }else{
                LinshiEnemyObj.Add(linshiTran.gameObject);
            }
         }
         for(int i =0;i<LinshiEnemyObj.Count;i++){
            EnemyObj[i]=LinshiEnemyObj[i];
         }
     }
     public void UpdatePlayer(){
         //更新玩家
         GameObject linshiPlay=this.transform.GetChild(0).GetChild(0).gameObject;
         if(linshiPlay.GetComponent<PlayerDate>()==null){
             Debug.Log("来自PulicObjScr的报告：获取玩家对象出现异常");
         }else{
            PlayerObj[0]=linshiPlay;
         }
         
     }
//----------------------------------------------
    //返回方法
     public GameObject[] Re_PlayerObj(){
         UpdatePlayer();
         return PlayerObj;
     }
    public GameObject[] Re_EnemyObj(){
         UpdateObj();
         return EnemyObj;
     }
//----------------------------------------------

	public void GroundRule3(double[] d){
		if(d[0]!=0){
        //执行伤害与受场景Rule1影响的计算
            GroundLib gb=GroundScr._instance.groundLib;
            d[0]=gb.ReckonRule1(d);
            //当第三位数为99时，即为全体无差别伤害
            if(d[2]==99){
                GameObject[] Enobj=Re_EnemyObj();
                for(int i =0;i<Enobj.Length;i++){
                    Enobj[i].transform.GetChild(0).GetComponent<EmenyScr>().CountDamaged(true,(int)d[0]);
                }
                GameObject[] Plaobj=Re_PlayerObj();
                for(int i =0;i<Plaobj.Length;i++){
                    Plaobj[i].GetComponent<PlayerDate>().AttackePlayer((int)d[0]);
                }
            }
        }

	}

    public void GroundRule2(){
        double []d;
        GroundLib gb=GroundScr._instance.groundLib;
        d=gb.ReckonRule2();
        if(d!=null){
            GameObject[] Enobj=Re_EnemyObj();
            Debug.Log("Enobj.Length "+Enobj.Length);
            for(int i =0;i<Enobj.Length;i++){
                if(Enobj[i]!=null){
                    GameObject linshiobj=Enobj[i].transform.GetChild(0).gameObject;
                    Debug.Log("Rule2:Enobj["+i+"]"+Enobj[i]);
                    linshiobj.GetComponent<EmenyScr>().ChangeDate(d);

                }
            }
            GameObject[] Plaobj=Re_PlayerObj();
            for(int i =0;i<Plaobj.Length;i++){
                if(Plaobj[i]!=null){
                    Debug.Log("Rule2:Plaobj["+i+"]"+Plaobj[i]);                    
                    Plaobj[i].GetComponent<PlayerDate>().ChangeDate(d);
                }
            }
        }
    }

    public void GroundRule2Init(){
        double []d;
        GroundLib gb=GroundScr._instance.groundLib;
        d=gb.ReckonRule2Init();
        if(d!=null){
            GameObject[] Enobj=Re_EnemyObj();
            for(int i =0;i<Enobj.Length;i++){
                if(Enobj[i]!=null){
                    Debug.Log("Enobj["+i+"]"+Enobj[i]);

                    Enobj[i].transform.GetChild(0).GetComponent<EmenyScr>().ChangeDate(d);
                }
            }
            GameObject[] Plaobj=Re_PlayerObj();
            for(int i =0;i<Plaobj.Length;i++){
                if(Plaobj[i]!=null){
                    Debug.Log("Plaobj["+i+"]"+Plaobj[i]);
                    Plaobj[i].GetComponent<PlayerDate>().ChangeDate(d);
                }
            }
        }
    }
}
