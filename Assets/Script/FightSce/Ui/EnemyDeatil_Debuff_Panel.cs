using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///	该脚本用于创建Deatil面板上的Debuff实例
///</summary>
public class EnemyDeatil_Debuff_Panel : MonoBehaviour {
	public static EnemyDeatil_Debuff_Panel Instance;

    public static EnemyDeatil_Debuff_Panel _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(EnemyDeatil_Debuff_Panel))as EnemyDeatil_Debuff_Panel;
            }
            return Instance;
        }
    }
//------------------------------------------
	//用于储存生成物体的Obj
	///<summary>
	///	这里绑定生成Debuff的Obj预制体
	///</summary>
	public GameObject DebuffObj;
	//储存当前生成的Debuff对象的数组
	public List<GameObject> D_Obj_Array;
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		D_Obj_Array=new List<GameObject>();
	}
	public void CreatEnemyDebuff(int d_num,string d_name){
		
		GameObject Debuff_ii=Instantiate(DebuffObj);
		//设置父对象
		Debuff_ii.transform.parent=this.gameObject.transform;
		Debuff_ii.GetComponent<Deatil_Debuff_Ui>().SetBuffImg(d_name);
		Debuff_ii.GetComponent<Deatil_Debuff_Ui>().SetBuffNum(d_num);
		D_Obj_Array.Add(Debuff_ii);
	}

	public void InitScr(){
		for(int i =0;i<D_Obj_Array.Count;i++){
			D_Obj_Array[i].GetComponent<Deatil_Debuff_Ui>().DestroyObj();
			
		}
		D_Obj_Array.Clear();
	}

//--------------------------------
	public List<GameObject> Re_D_Obj_Array(){
		return D_Obj_Array;
	}

}
