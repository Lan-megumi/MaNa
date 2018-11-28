using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;


public class Level_Enemy_Lib:MonoBehaviour{
	public List<Level_Enemy> Level_Enemy_Libs=new List<Level_Enemy>();
	public int LevelNum=1;
//------------------------------------------
/// <summary>
///	根据反射生成 该关卡的敌人阵列
/// </summary>
	public void NewLevel_Enemy(string name,int i ){
		
		object b = Activator.CreateInstance(System.Type.GetType(name));
		// Debug.Log("dddd"+b);
		Level_Enemy_Libs.Add((Level_Enemy)b);
		Level_Enemy_Libs[0].CreatEnemy(i);
	}
	public void NextEnemy(){
		LevelNum++;
		Level_Enemy_Libs[0].CreatEnemy(LevelNum);
	}
}

//-------------------------------------------
/// <summary>
///	 关卡敌人阵列父类
/// </summary>
public class Level_Enemy{
	public virtual void CreatEnemy(int i){

	}
}
public class SanFran_Outtrainingground:Level_Enemy{
	public override void CreatEnemy(int i){
		if (i==1)
		{
			PanelScript._instance.CreatEmeny(4);

		}
		if (i==2)
		{
			PanelScript._instance.CreatEmeny(4);
			PanelScript._instance.CreatEmeny(99);
			PanelScript._instance.CreatEmeny(5);			
		}
		if (i==3)
		{
			PanelScript._instance.CreatEmeny(99);
			PanelScript._instance.CreatEmeny(6);
		}
	}

}
