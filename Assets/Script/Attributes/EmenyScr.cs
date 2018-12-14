using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EmenyScr : MonoBehaviour {

	public int  EnemyHp,EnemyMaxHp;
    public int EnemyIndex;
	public bool BChose_Deatil;
	//-------------------------
	public Text TextName;
	public Slider HpSlider;
	//-------------------------
	public GameObject BCheckBcak;
    //用于记录第几个生成的敌人
	
    public Slider targetSliderOject, targetSliderOject1;

    public List<GameObject> emenyObj2;
	public List<Attributes> enemyAi;

    // public static EmenyScr _instance;
    public float Agi;

    // private void Awake()
    // {
    //     _instance = this;
    // }
    void Awake()
    {
        emenyObj2 = new List<GameObject>();
		enemyAi=new List<Attributes>();
		// Debug.Log("Creat enemyAi");
		
		// enemyAi=null;
    }
	/// <summary>
	///	单个敌人实例化
	/// </summary>
    public void NewEmeny(int i){
		if (i==1)
		{
			Emeny1 Newemeny=new Emeny1();
			Newemeny.initdate();
			EnemyHp=Newemeny.GetHp;
            Agi = Newemeny.Agi;
			TextName.text=Newemeny.GetName;
			// enemyAi[0]=Newemeny;
		
        }
		else if(i==2){
			Emeny2 Newemeny=new Emeny2();
			Newemeny.initdate();
			EnemyHp=Newemeny.GetHp;
			TextName.text=Newemeny.GetName;
            Agi = Newemeny.Agi;
			// enemyAi[0]=Newemeny;
        }else if(i==3){
			Enemy3 Newemeny=new Enemy3();
			Newemeny.initdate();
			EnemyHp=Newemeny.GetHp;
            Agi = Newemeny.Agi;
			TextName.text=Newemeny.GetName;
			// double [] b={0};
			Debug.Log(enemyAi);
			// enemyAi[0]=Newemeny;
			enemyAi.Add(Newemeny);
		}else if(i==4){
			Enemy4 Newemeny=new Enemy4();
			Newemeny.initdate();
			EnemyHp=Newemeny.GetHp;
            Agi = Newemeny.Agi;
			TextName.text=Newemeny.GetName;
			enemyAi.Add(Newemeny);
		}else if(i==5){
			Enemy5 Newemeny=new Enemy5();
			Newemeny.initdate();
			EnemyHp=Newemeny.GetHp;
            Agi = Newemeny.Agi;
			TextName.text=Newemeny.GetName;
			enemyAi.Add(Newemeny);
		}else if(i==6){
			Enemy6 Newemeny=new Enemy6();
			Newemeny.initdate();
			EnemyHp=Newemeny.GetHp;
            Agi = Newemeny.Agi;
			TextName.text=Newemeny.GetName;
			enemyAi.Add(Newemeny);
		}else if(i==99){
			Enemy99 Newemeny=new Enemy99();
			Newemeny.initdate();
			EnemyHp=Newemeny.GetHp;
            Agi = Newemeny.Agi;
			TextName.text=Newemeny.GetName;
			// double [] b={0};
			Debug.Log(enemyAi);
			// enemyAi[0]=Newemeny;
			enemyAi.Add(Newemeny);
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
	

///<summary>
///	敌人的伤害/治疗计算:True伤害，n为伤害值,结算完成后进行Ui的修改、阵亡事件
///</summary>
	public void CountDamaged(bool i,int n){
		if (i==true)
		{
            
            EnemyHp -=n;
			//播放动画
			this.transform.GetChild(1).GetComponent<EnemyAni_Scr>().StarDamged();
			Debug.Log("造成伤害："+n+" 剩余血量:"+EnemyHp);
		}else
		{
			EnemyHp+=n;
			//过量治疗
			if (EnemyHp>EnemyMaxHp)
			{
				EnemyHp=EnemyMaxHp;
			}
			//播放动画
			this.transform.GetChild(1).GetComponent<EnemyAni_Scr>().StarCure();

		}
		// UpdateHpUi(EnemyHp.ToString());
		Update_HpSlider(EnemyMaxHp,EnemyHp);
		//伤害结算完成判断是否阵亡
		if (EnemyHp<=0)
		{
            Audios._instance.m_Audio.clip = Audios._instance.myMusicArray[7];
            Audios._instance.m_Audio.Play();

            //清理各个脚本敌人数组的数据
            DmScr._instance.Update_EnemyNum(EnemyIndex);
			
		}
	}
	///<summary>
	///	执行更新Deatil面板Ui的方法
	///</summary>
    public void Set_Enemy_Deatil_Ui(){
		if(this.GetComponentInParent<CountDebuff>().Re_Debuffnum()!=null&&this.gameObject!=null){
			int[] DebuffArray = this.GetComponent<CountDebuff>().Re_Debuffnum();
			Enemy_Deatil_Ui._instance.ShowDebuffUi(DebuffArray);
		}
		int Maxhp= this.Re_Maxhp();
		int hp= this.Re_hp();
		Enemy_Deatil_Ui._instance.ShowHpDeatil(Maxhp,hp);

	}

	public void Update_HpSlider(int Maxnum,int NowNum){
		double i = (double)NowNum/(double)Maxnum;
		Debug.Log(NowNum+"/"+Maxnum+"="+i);
		HpSlider.value=(float)i;
	}
    public void UpdateBack(bool i){
		if (i==true)
		{
			// BCheckBcak.SetActive(true);
		}else
		{
			// BCheckBcak.SetActive(false);
		}
	}
	///<summary>
	///	执行更新单个敌人下的 BchoseDeatil 变量，传入参数为Bool
	///</summary>
	public void Set_BchoseDeatil(bool t){
		BChose_Deatil=t;
	}


//----------------------------------------
	public int Re_hp(){
		return EnemyHp;
	}
	public string Re_Name(){
		string i = TextName.text;
		return  i;
	}
	public int Re_Maxhp(){
		return EnemyMaxHp;
	}
	public bool Re_BchoseDeatil(){
		return BChose_Deatil;
	}
  
}
