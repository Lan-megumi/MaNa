using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.SceneManagement;
using System;


public class GameControoler : MonoBehaviour {
	public GameObject CardCan,EnemyCan,BlackCan,CoverCardCan;
	public static GameControoler Instance;

    public static GameControoler _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(GameControoler))as GameControoler;
            }
            return Instance;
        }
    }
//---------------------------------------------------------
	private GameObject SceDate;
	//关卡名
	public string LevelName;
	///<summary>
	///用于储存敌人数量
	///</summary>
	public int EnemyNum=0;
	//场景第x小关
	// Level_Enemy_Lib LEL ;

//---------------------------------------------------------
	// Use this for initialization
	void Start () {
		//查找储存了场景数据的SceneDate
		SetUi(false);
		SceDate=GameObject.Find("SceneDate");
		CoverCardCan.SetActive(true);
		BlackCan.SetActive(true);
		if (SceDate!=null)
		{
			//获取场景数据
			this.GetComponent<GroundScr>().GetSceGround();
			//先将Ui显示出来
			SetUi(true);

			//根据获取的数据创建敌人
			LevelName=SceDate.GetComponent<SceStar>().Re_LevelName();
			//去除空格
			string n = LevelName.Replace(" ","");
			// Debug.Log("去除空格"+n);
			//执行反射，准备生成敌人
			// LEL.NewLevel_Enemy(LevelName);
			this.GetComponent<Level_Enemy_Lib>().NewLevel_Enemy(n);
			

			//撤下遮布
			BlackCan.SetActive(false);
			//初始化场景数据
			SceDate.GetComponent<SceStar>().InitDate();
			//新建临时玩家，一般情况下是独挡新建玩家实例
			PlayerDate._instance.Testlinshi();
			//执行开始游戏
			EnemyCan.GetComponent<StartGame>().StartButton();

		}else
		{
			Debug.Log("数据未找到！");
		}
		
	}
	
///<summary>
///当战斗结束后事件执行完毕后可调用该方法返回场景
///</summary>
	public void BackSce(){
		SceneManager.LoadScene(5,LoadSceneMode.Single);
		
	}
///<summary>
///
///</sumarry>
	public void CheckEnemy(){
		
	}
	

//-----------------------------------------------------
//Ui层代码
	public void SetUi(bool i){
		CardCan.SetActive(i);
		EnemyCan.SetActive(i);
	}
	public void SetCardUi(bool n){
		CoverCardCan.SetActive(n);
	}
	
}
