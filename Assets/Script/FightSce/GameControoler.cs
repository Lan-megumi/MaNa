using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControoler : MonoBehaviour {
	public GameObject CardCan,EnemyCan,BlackCan;
	private GameObject SceDate;
	private int num;
	// Use this for initialization
	void Start () {
		//查找储存了场景数据的SceneDate
		
		SceDate=GameObject.Find("SceneDate");
		if (SceDate!=null)
		{
			num=SceDate.GetComponent<SceStar>().Re_SceNum();
			//先将Ui显示出来
			SetUi();
			//根据获取的数据创建敌人
			CreateEmeny(num);
			//撤下遮布
			BlackCan.SetActive(false);
			//初始化数据
			SceDate.GetComponent<SceStar>().Set_SceNum(0);
			//执行开始游戏
			EnemyCan.GetComponent<StartGame>().StartButton();
		}else
		{
			Debug.Log("数据未找到！");
		}
		
	}
	
	public void CreateEmeny(int i){
		if (i==1)
		{
			PanelScript._instance.CreatEmeny(1);
		}
		if (i==2)
		{
			PanelScript._instance.CreatEmeny(1);
			PanelScript._instance.CreatEmeny(1);			
		}
		if (i==3)
		{
			PanelScript._instance.CreatEmeny(2);
			PanelScript._instance.CreatEmeny(2);
			PanelScript._instance.CreatEmeny(2);
			
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void SetUi(){
		CardCan.SetActive(true);
		EnemyCan.SetActive(true);
	}
}
