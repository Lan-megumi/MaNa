using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
///	结算界面
///<summary>
public class BalanceScr : MonoBehaviour {
    public GameObject balance;
    public GameObject wim;
    public GameObject fail;


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
        wim = GameObject.Find("U/Win");
        fail = GameObject.Find("U/Fail");
        wim.SetActive(false);
        fail.SetActive(false);
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
            wim.SetActive(true);
		}else{
            balance.SetActive(true);
            fail.SetActive(true);
        }
	}
	public void JumpChoselevel(){
		SceneManager.LoadScene(5);
	}
}
