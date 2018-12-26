using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GroundUi : MonoBehaviour {
	// Use this for initialization
	public static GroundUi Instance;

    public static GroundUi _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(GroundUi))as GroundUi;
            }
            return Instance;
        }
    }
//-----------------------------------------
	public Image Groundimg,GroundDeatil;
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		GroundDeatil.enabled=false;
	}
	public void ChangeGroundImg(string name){
		Sprite a = Resources.Load("GroundImg/"+name,typeof(Sprite))as Sprite;
		Groundimg.sprite=a;
		if(a!=null){
			Sprite b = Resources.Load("GroundImg/"+name+"_Deatil",typeof(Sprite))as Sprite;
			GroundDeatil.sprite=b;
		}
	}
	public void DeatilController(bool d){
		GroundDeatil.enabled=d;
	}
}
