using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
	该脚本用于选关界面的Ui与逻辑实现
 */
public class Checklevel_Scr : MonoBehaviour {
	public static Checklevel_Scr _instance;
	//更规范的 单例写法  调用时 脚本名+Instance+方法
	public static Checklevel_Scr Instance{
		get{
			if (null==_instance)
			{
				_instance=FindObjectOfType(typeof(Checklevel_Scr))as Checklevel_Scr;
			}
			return _instance;
		}
	}
	//------------------------------------
	//声明Ui需要用到组件，Image以及储存其的数组
	public Image level1,level2,level3,level4;
	public List<Image> levelObj;
	//声明Ui需要用到Text组件
	public Text Name1,Name2,Menu1;
	//------------------------------------
	//声明逻辑部分需要用到的变量
	public int i =0;
	//------------------------------------

	void Start(){
		levelObj.Add(level1);
		levelObj.Add(level2);
		levelObj.Add(level3);
		levelObj.Add(level4);
		for (int i = 0; i < levelObj.Count; i++)
		{
			levelObj[i].gameObject.SetActive(false);
		}
		LevelUi_Scr(0);
		Menu1.text="怪物详情";
	}
	void Update(){
		if (Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow))
		{
			levelObj[i].gameObject.SetActive(false);
			i+=1;
			if (i>=levelObj.Count)
			{
				i-=1;
			}
			LevelUi_Scr(i);

		}
		else if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow))
		{
			levelObj[i].gameObject.SetActive(false);
			i-=1;
			if (i<0)
			{
				i+=1;
			}
			LevelUi_Scr(i);

		}
		//敲下回车进入关卡事件
		if (Input.GetKeyDown(KeyCode.Return))
		{
			Debug.Log("ENTER");
			LevelGo(i);

		}
	}
	//改变关卡选中Ui效果的方法，同时执行改变名称
	public void LevelUi_Scr(int i ){
		levelObj[i].gameObject.SetActive(true);
		LevelNameUi_Scr(i);
	}
	//改变关卡名称Ui的方法
	public void LevelNameUi_Scr(int i){
		if (i==0)
		{
			Name1.text="圣芙兰法师学院";
			Name2.text="露天战斗训练场";
		}
		else if (i==1)
		{
			Name1.text="圣芙兰法师学院";
			Name2.text="炼金熔炉";
		}else
		{
			Name1.text="%%";
			Name2.text="**";
		}
	}
//进入游戏关卡的方法

	public void LevelGo(int i){
		if (i==0)
		{
			SceStar.Instance.Set_SceNum("San Fran_Out training ground");
			Debug.Log("进入 露天战斗训练场");
			SceneManager.LoadScene(4,LoadSceneMode.Single);
		}
		
	}



}
 