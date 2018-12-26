using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
///<summary>
///	获取场景并将场景规则实例化出来的脚本
///</summary>
public class GroundScr : MonoBehaviour {
	public static GroundScr Instance;

    public static GroundScr _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(GroundScr))as GroundScr;
            }
            return Instance;
        }
    }

//-----------------------------------------
	//准备用于接收场景数据的变量
	private GameObject SceDate;
	//准备储存场景名字的变量
	public string SceGround;
	//准备储存场景数据库的变量
	public  GroundLib groundLib;

	
	// Use this for initialization
	void Awake () {
		//新建场景数据库的实例
		groundLib=new GroundLib();

	}

///<summary>
///	场景名称获取并且传递
///</summary>
	public void GetSceGround(){
		SceDate=GameObject.Find("SceneDate");
		SceGround=SceDate.GetComponent<SceStar>().Re_SceGround();
		// Debug.Log("GroundScr:"+SceGround);	
		ChangeGround(SceGround);

	}
	///<summary>
	///	改变场景的方法，同时改变Ui的显示
	///</summary>
	public void ChangeGround(string name){
		groundLib.UponGround(name);
		GroundUi._instance.ChangeGroundImg(name);
		//播放一个动画
	}

	
	
	public string Re_SceGround(){
		return SceGround;
	}

}
