﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EmenyScr : MonoBehaviour {

	public int  EnemyHp,EnemyMaxHp;
	//-------------------------
	public Text TextHp,TextName;
	public Slider HpSlider;
	//-------------------------
	public GameObject BCheckBcak;
    //用于记录第几个生成的敌人
    public int EnemyIndex;

    public Slider targetSliderOject, targetSliderOject1;

    public List<GameObject> emenyObj2;

    // public static EmenyScr _instance;
    public float Agi;

    // private void Awake()
    // {
    //     _instance = this;
    // }
    void Start()
    {
        emenyObj2 = new List<GameObject>();
       
    }
    public void CreatEmeny(int i){
		if (i==1)
		{
			EmenyLibrary.Emeny1 Newemeny=new EmenyLibrary.Emeny1();
			Newemeny.initdate();
			EnemyHp=Newemeny.GetHp;
            Agi = Newemeny.Agi;
			TextName.text=Newemeny.GetName;
        }
		else if(i==2){
			EmenyLibrary.Emeny2 Newemeny=new EmenyLibrary.Emeny2();
			Newemeny.initdate();
			EnemyHp=Newemeny.GetHp;
			TextName.text=Newemeny.GetName;
            Agi = Newemeny.Agi;
        }
		
		else{
			Debug.Log("Input wrong！The enmey"+i+" no Found!");
		}
		if (EnemyHp!=0)
		{
			EnemyMaxHp=EnemyHp;
			Update_HpSlider(EnemyMaxHp,EnemyHp);	
		}
		

	}
/*
	敌人的伤害/治疗计算,结算完成后进行Ui的修改
 */
	public void CountDamaged(bool i,int n){
		if (i==true)
		{
			EnemyHp-=n;
		}else
		{
			EnemyHp+=n;
			//过量治疗
			if (EnemyHp>EnemyMaxHp)
			{
				EnemyHp=EnemyMaxHp;
			}
		}
		// UpdateHpUi(EnemyHp.ToString());
		Update_HpSlider(EnemyMaxHp,EnemyHp);

	}
    
	public void Update_HpSlider(int Maxnum,int NowNum){
		double i = (double)NowNum/(double)Maxnum;
		Debug.Log(NowNum+"/"+Maxnum+"="+i);
		HpSlider.value=(float)i;
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