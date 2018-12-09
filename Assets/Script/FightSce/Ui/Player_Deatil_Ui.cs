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
    ///<summary>
    /// 血条显示
    ///</summary>
	public void ShowHpDeatil(int MaxHp,int hp){
		double i = (double)hp/(double)MaxHp;
        double d = 4000.00f/5555.00f;
        i=System.Math.Round(i,4);
        Debug.Log("i:"+i+"  Hp:"+hp+"/MaxHp:"+MaxHp);
        Hp.value=(float)i;
	}

     ///<summary>
    /// Mana显示
    ///</summary>
	public void ShowMannaDeatil(int MaxMana,int mana){
		double i = (double)mana/(double)MaxMana;
        i=System.Math.Round(i,4);
        Mana.value=(float)i;
	}
    public void ShowDebuffUi(){
        
    }
}
