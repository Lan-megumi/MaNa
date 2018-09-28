using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Opening : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameMaster_Button_Text.text="点一下赚一万";

		if(!File.Exists(Application.dataPath+"/saves"+"/load.save")){	//如果检查不到存档则返回上一层
			SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
			Debug.Log("读取存档出错，请重新登录");
		}

		BinaryFormatter bf = new BinaryFormatter();						//读取存档信息
		FileStream LoadDate_LS = File.Open(Application.dataPath+"/saves"+"/load.save",FileMode.Open);
		LoadDate = (SAVE_GS) bf.Deserialize(LoadDate_LS);
		LoadDate_LS.Close();
	}
	
	// Update is called once per frame
	void Update () {
		Display_Money_GB_St=LoadDate.money_GB.ToString();				//将钻石数量和金币数量显示出来
		Display_Money_ZS_St=LoadDate.money_ZS.ToString();
		Display_Money_GB.text = Display_Money_GB_St;
		Display_Money_ZS.text = Display_Money_ZS_St;

		if(!File.Exists(Application.dataPath+"/saves"+"/load.save")){	//如果检查不到存档则返回上一层
			SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
			Debug.Log("读取存档出错，请重新登录");
		}
	}
	SAVE_GS LoadDate ;
	String Display_Money_GB_St,Display_Money_ZS_St;
	public Text GameMaster_Button_Text;
	public Text Display_Money_GB , Display_Money_ZS;

	public void GM_Button() {											//这是一个测试用的按钮
			//现在的功能是金币和钻石增加一万
			LoadDate.money_GB=LoadDate.money_GB+10000;
			LoadDate.money_ZS=LoadDate.money_ZS+10000;
			BinaryFormatter bf = new BinaryFormatter();					//存起来
			FileStream LoadDate_LS_1 = File.Create(Application.dataPath+"/saves"+"/save"+LoadDate.NomberD+".save");
			bf.Serialize(LoadDate_LS_1,LoadDate);
			LoadDate_LS_1.Close();
			FileStream LoadDate_LS_2 = File.Create(Application.dataPath+"/saves"+"/load.save");
			bf.Serialize(LoadDate_LS_2,LoadDate);
			LoadDate_LS_2.Close();
	}

	public void To_Region_Button(){
		SceneManager.LoadScene("REGION",LoadSceneMode.Single);
	}
}
