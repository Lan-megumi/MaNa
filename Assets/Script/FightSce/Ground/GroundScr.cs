using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

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

/*
	场景名称获取并且传递
 */
	public void GetSceGround(){
		SceDate=GameObject.Find("SceneDate");
		SceGround=SceDate.GetComponent<SceStar>().Re_SceGround();
		// Debug.Log("GroundScr:"+SceGround);	
		groundLib.UponGround(SceGround);

	}
/*
	根据场景名称执行对应方法
*/
	
	public void FindGround(){
		// groundLib=ReadCard._instance.groundLib;
		// Debug.Log("GroundScr"+groundLib.a);


		// Debug.Log("0"+GroundDic["Strom_labyrinth"]);
		// System.Object[] o=new Object[num0.Length];

		// o[1]=num0;
		// d = GroundDic[SceGround];
		
		// MethodInfo Fun_Name=t.GetMethod("Arena");

		// Fun_Name.Invoke(groundLib,null);
		// Debug.Log("反射");
	}
	public string Re_SceGround(){
		return SceGround;
	}

}
