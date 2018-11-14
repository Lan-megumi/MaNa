using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private GameObject SceDate;
	private int num;
	// Use this for initialization
	void Start () {
		//查找储存了场景数据的SceneDate
		SetUi(false);
		SceDate=GameObject.Find("SceneDate");
		CoverCardCan.SetActive(true);
		BlackCan.SetActive(true);
		if (SceDate!=null)
		{
			num=SceDate.GetComponent<SceStar>().Re_SceNum();
			//先将Ui显示出来
			SetUi(true);
			//根据获取的数据创建敌人
			CreateEmeny(num);
			//撤下遮布
			BlackCan.SetActive(false);
			//初始化数据
			SceDate.GetComponent<SceStar>().Set_SceNum(0);
			PlayerDate._instance.Testlinshi();
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
	public void SetUi(bool i){
		CardCan.SetActive(i);
		EnemyCan.SetActive(i);
	}
	public void SetCardUi(bool n){
		CoverCardCan.SetActive(n);
	}
}
