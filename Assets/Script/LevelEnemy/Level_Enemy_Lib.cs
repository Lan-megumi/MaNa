using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;


public class Level_Enemy_Lib:MonoBehaviour{
	public List<Level_Enemy> Level_Enemy_Libs=new List<Level_Enemy>();
//------------------------------------------
/// <summary>
///	根据反射生成 该关卡的敌人阵列,同时会将敌人阵列最大值传值给 SceStar脚本
/// </summary>
	public void NewLevel_Enemy(string name,int i ){
		
		object b = Activator.CreateInstance(System.Type.GetType(name));
		// Debug.Log("dddd"+b);
		Level_Enemy_Libs.Add((Level_Enemy)b);
		Level_Enemy_Libs[0].CreatEnemy(i);
		SceStar._instance.Set_MaxLELnum(Level_Enemy_Libs[0].Re_MaxLELnum());	
	}
	
}

//-------------------------------------------
/// <summary>
///	 关卡敌人阵列父类
/// </summary>
public class Level_Enemy{
	public virtual void CreatEnemy(int i){

	}
	public virtual int Re_MaxLELnum(){
		return 0;
	}
}
public class SanFran_Outtrainingground:Level_Enemy{
	public override void CreatEnemy(int i){
		if (i==1)
		{
			PanelScript._instance.CreatEmeny(4);	

			DmScr._instance.SetDate();
		}
		if (i==2)
		{
			PanelScript._instance.CreatEmeny(4);
			PanelScript._instance.CreatEmeny(99);
			PanelScript._instance.CreatEmeny(5);	
			DmScr._instance.SetDate();		
		}
		if (i==3)
		{
			PanelScript._instance.CreatEmeny(99);
			PanelScript._instance.CreatEmeny(6);
			DmScr._instance.SetDate();
		}

	}
	public override int Re_MaxLELnum(){
		return 3;
	}

}
