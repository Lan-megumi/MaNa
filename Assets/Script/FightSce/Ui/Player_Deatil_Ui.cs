using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Deatil_Ui : MonoBehaviour {
	public static Player_Deatil_Ui Instance;

    public static Player_Deatil_Ui _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(Player_Deatil_Ui))as Player_Deatil_Ui;
            }
            return Instance;
        }
    }
//---------------------------------------
	public Slider Hp,Mana;
	public GameObject DeatilObj;
	// Use this for initialization

	public void ShowDeatil(){
		
	}
}
