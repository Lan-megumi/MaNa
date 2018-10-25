using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EmenyScr : MonoBehaviour {

	public int  EmenyHp;
	//-------------------------
	public Text TextHp,TextName;
	//-------------------------
	public GameObject BCheckBcak;


	public void CreatEmeny(int i){
		if (i==1)
		{
			EmenyLibrary.Emeny1 Newemeny=new EmenyLibrary.Emeny1();
			Newemeny.initdate();
			EmenyHp=Newemeny.GetHp;
			TextName.text=Newemeny.GetName;
			UpdateHpUi(EmenyHp.ToString());
		}
		else if(i==2){
			EmenyLibrary.Emeny2 Newemeny=new EmenyLibrary.Emeny2();
			Newemeny.initdate();
			EmenyHp=Newemeny.GetHp;
			TextName.text=Newemeny.GetName;
			UpdateHpUi(EmenyHp.ToString());
		}
		else{
			Debug.Log("Input wrong！The enmey"+i+" no Found!");
		}
		

	}
	public void UpdateHpUi(string hp){
			TextHp.text=hp;
	}
	public void CountDamaged(bool i,int n){
		if (i==true)
		{
			EmenyHp-=n;
		}else
		{
			EmenyHp+=n;
		}
		UpdateHpUi(EmenyHp.ToString());
	}
	
	public void UpdateBack(bool i){
		if (i==true)
		{
			BCheckBcak.SetActive(true);
		}else
		{
			BCheckBcak.SetActive(false);
		}
	}
}
