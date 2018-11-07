using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EmenyScr : MonoBehaviour {

	public int  EmenyHp;
	//-------------------------
	public Text TextHp,TextName;
	//-------------------------
	public GameObject BCheckBcak;
    //用于记录第几个生成的敌人
    public int EnemyIndex;

    public Slider targetSliderOject, targetSliderOject1;

    public List<GameObject> emenyObj2;

    public static EmenyScr _instance;
    public float Agi;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        emenyObj2 = new List<GameObject>();
       
    }
    public void CreatEmeny(int i){
		if (i==1)
		{
			EmenyLibrary.Emeny1 Newemeny=new EmenyLibrary.Emeny1();
			Newemeny.initdate();
			EmenyHp=Newemeny.GetHp;
            Agi = Newemeny.Agi;
			TextName.text=Newemeny.GetName;
            UpdateHpUi(EmenyHp.ToString());
        }
		else if(i==2){
			EmenyLibrary.Emeny2 Newemeny=new EmenyLibrary.Emeny2();
			Newemeny.initdate();
			EmenyHp=Newemeny.GetHp;
			TextName.text=Newemeny.GetName;
			UpdateHpUi(EmenyHp.ToString());
            Agi = Newemeny.Agi;
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
    public void CountRelated(int n,int z) 
    {
        Debug.Log("n:" + n);
        Debug.Log("z:" + z);
        if (z == 0&& DmScr._instance.emenyObj2.Count==1)
        {
            DmScr._instance.emenyObj2[0].GetComponent<EmenyScr>().CountDamaged(true, n);
        }
        if(z==0)
        {
            DmScr._instance.emenyObj2[0].GetComponent<EmenyScr>().CountDamaged(true, n);
            DmScr._instance.emenyObj2[1].GetComponent<EmenyScr>().CountDamaged(true, n);
        }
        if (z == 1)
        {
            DmScr._instance.emenyObj2[0].GetComponent<EmenyScr>().CountDamaged(true, n);
            DmScr._instance.emenyObj2[1].GetComponent<EmenyScr>().CountDamaged(true, n);
            DmScr._instance.emenyObj2[2].GetComponent<EmenyScr>().CountDamaged(true, n);
        }
        if(z==2)
        {
            DmScr._instance.emenyObj2[1].GetComponent<EmenyScr>().CountDamaged(true, n);
            DmScr._instance.emenyObj2[2].GetComponent<EmenyScr>().CountDamaged(true,n);
        }
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
