using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///<summary>
///	结算界面
///<summary>
public class BalanceScr : MonoBehaviour {
    public GameObject balance;
    public Text result;
    public Text number;


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
        balance = GameObject.Find("U");
        balance.SetActive(false);
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StarUi(bool d){
		this.gameObject.SetActive(true);
		IFwin=d;
		if(IFwin==true){
            balance.SetActive(true);
            result.text = "胜利";
            number.text = "获得补血药 x2";
		}else{
            GameControoler._instance.StarMan();
            balance.SetActive(true);
            result.text = "失败";
            number.text = "获得补血药 x1";
        }
	}
	public void JumpChoselevel(){
		SceneManager.LoadScene(5);
	}
}
