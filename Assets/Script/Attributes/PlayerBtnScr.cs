using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBtnScr : MonoBehaviour {

	///<summary>
	///	通过此读取Player的公共战斗数据以及进入Player的计算方法
	///</summary>
	public void CheckDate(){
		string type0=PlayerFightScr._instance.Re_N_Type();
		string num = PlayerFightScr._instance.Re_N_Num();
		if (num!="")
		{
			if (type0=="Damage")
			{
				PlayerDate._instance.AttackePlayer(int.Parse(num));
			}
			if (type0=="Cure")
			{
				PlayerDate._instance.CurePlayer(int.Parse(num));
			}
		}else
		{
			Debug.Log("Player公共战斗脚本中的数值为空");
		}
		PlayerFightScr._instance.InitDate();
	}

}
