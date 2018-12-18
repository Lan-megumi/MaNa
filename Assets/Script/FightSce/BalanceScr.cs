using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
///	结算界面
///<summary>
public class BalanceScr : MonoBehaviour {
	public static BalanceScr Instance;

	public static BalanceScr _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(BalanceScr))as BalanceScr;
            }
            return Instance;
        }
    }
	//-----------------------------------
	public bool IFwin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StarUi(bool d){
		this.gameObject.SetActive(true);
		IFwin=d;
		if(IFwin==true){

		}else{
			
		}
	}
	public void JumpChoselevel(){
		SceneManager.LoadScene(6);
	}
}
