using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	该脚本用于读取卡牌中的数据
	属于公共脚本
	以及非BM（最佳合成）卡牌的合成
 */
public class ReadCard : MonoBehaviour {
	public List<TestCard> Library2;
	public static ReadCard Instance;

    public static ReadCard _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(ReadCard))as ReadCard;
            }
            return Instance;
        }
    }

//------------------------------------------
	//接收两张牌的参数
	public string Cardid1,Cardid2;
	//Reckon 是面板伤害求和
	public int Reckon,CureReckon;
	private int CardDamage1,CardDamage2,Card1Cure,Card2Cure;
	public AttcakeType CardAttackeType1,CardAttackeType2,BmAttackeType;
//------------------------------------------

public GroundLib groundLib;
	// Use this for initialization
	void Start () {
		Library2 = new List<TestCard>();
		groundLib=new GroundLib();
	}

//这里是公开的传入参数的方法
/*
	该传入参数将被作用于jo()方法中，并且是触发jo()方法的唯一接口
	*/
	public void SetId(string id1,string id2){
		if (id1==""||id2=="")
		{
			Debug.Log("id传入有空值");
		}else
		{
			Cardid1=id1;
			Cardid2=id2;
			Debug.Log("融合的两张卡的id Cardid1 : " + id1 + "Cardid2 : " + id2);
			Debug.Log("------------------------------");
			jo();
		}
	}

/*
	合成调用的方法
*/
	public void jo(){
	//首先同步卡牌，因为牌库有可能被洗牌，不过好像洗了牌也不影响
		Library2=TestCardLibrary._instance.Library0;
		int a =0;
		// Debug.Log("Card1"+Cardid1+" | Card2:"+Cardid2);
		for(int i =0 ;i<Library2.Count;i++){
		//优化
			if (a>=2)
			{
				a=0;
				break;
			}
		//获取Damage值和AttacakeType
			if (Library2[i].GetCardid==Cardid1)
			{
				CardDamage1=Library2[i].GetCardDamage;
				CardAttackeType1=Library2[i].GetAttcakeType;
				Card1Cure=Library2[i].GetCardCure;
				Debug.Log("CardDamage1:"+CardDamage1);
				a++;
			}
			if (Library2[i].GetCardid==Cardid2)
			{
				CardDamage2=Library2[i].GetCardDamage;
				CardAttackeType2=Library2[i].GetAttcakeType;
				Card2Cure=Library2[i].GetCardCure;
				Debug.Log("CardDamage2:"+CardDamage2);
				a++;
			}
			// Debug.Log("Id"+i+":"+Library2[i].GetCardid);
		}
			
	


//------------------------------------------------------------
	/*
		区别于伤害的治疗
		2 - 单体治疗
		3 - 群体治疗
		需要注意的是治疗卡与其他伤害卡组和依然可以造成伤害
	 */
	//单体治疗x单体治疗/单体伤害/群体治疗/群体伤害
	 if (CardAttackeType1==(AttcakeType)2)
	 {
		 //单体治疗+单体治疗
		 if (CardAttackeType2==(AttcakeType)2)
		 {
			 CureReckon=Card1Cure+Card2Cure;
			 Reckon=CardDamage1+CardDamage2;
			 BmAttackeType=(AttcakeType)0;
		 }
		 //单体治疗+单体伤害
		 if (CardAttackeType2==(AttcakeType)0)
		 {
			 CureReckon=Card1Cure+CardDamage2;
			 Reckon=CardDamage1+CardDamage2;
			 BmAttackeType=(AttcakeType)0;

		 }
		 //单体治疗+群体治疗
		if (CardAttackeType2==(AttcakeType)3)
		 {
			 float linshiCure=Card1Cure*0.3f+Card2Cure;
			 CureReckon=(int)linshiCure;
			 float linshi=CardDamage1*0.3f+CardDamage2;
			 Reckon=(int)linshi;
			 BmAttackeType=(AttcakeType)1;
		 }
		 //单体治疗+群体伤害
		 if (CardAttackeType2==(AttcakeType)1)
		 {
			 float linshiCure=Card1Cure*0.3f+CardDamage2;
			 CureReckon=(int)linshiCure;
			 float linshi = CardDamage1*0.3f+CardDamage2;
			 Reckon=(int)linshi;
			 BmAttackeType=(AttcakeType)1;
		 }
		 //单体治疗+溅射
		 if(CardAttackeType2==(AttcakeType)4){
			 float linshiCure=Card1Cure+CardDamage2*0.6f;
			 CureReckon=(int)linshiCure;
			 float linshi = CardDamage1+CardDamage2*0.6f;
			 Reckon=(int)linshi;
			 BmAttackeType=(AttcakeType)4;
		 }
	 }

	 //群体治疗x群体治疗/单体治疗/群体伤害/单体伤害	
	 if (CardAttackeType1==(AttcakeType)3)
	 {
		 //群体治疗+群体治疗
		 if (CardAttackeType2==(AttcakeType)3)
		 {
			 CureReckon=Card1Cure+Card2Cure;
			 Reckon=CardDamage1+CardDamage2;
			 BmAttackeType=(AttcakeType)1;
		 }
		 //群体治疗+单体治疗
		 if (CardAttackeType2==(AttcakeType)2)
		 {
			 float linshiCure=Card1Cure+CardDamage2*0.3f;
			 CureReckon=(int)linshiCure;
			 float linshi =CardDamage1+CardDamage2;
			 Reckon=(int)linshi;
			 BmAttackeType=(AttcakeType)1;
		 }
		 //群体治疗+群体伤害
		 if (CardAttackeType2==(AttcakeType)1)
		 {
			CureReckon=Card1Cure+CardDamage2;
			 Reckon=CardDamage1+CardDamage2;
			 BmAttackeType=(AttcakeType)1;
		 }
		 //群体治疗+单体伤害
		 if (CardAttackeType2==(AttcakeType)0)
		 {
			 float linshiCure=Card1Cure+CardDamage2*0.3f;
			 CureReckon=(int)linshiCure;
			 float linshi =CardDamage1+CardDamage2;
			 Reckon=(int)linshi;
			 BmAttackeType=(AttcakeType)1;
		 }
		 //群体治疗+溅射
		 if (CardAttackeType2==(AttcakeType)4)
		 {
			 float linshiCure = Card1Cure+CardDamage2*0.5f;
			 CureReckon=(int)linshiCure;
			 float linshi = CardDamage1+CardDamage2*0.5f;
			 Reckon=(int)linshi;
			 BmAttackeType=(AttcakeType)4;

		 }
	 }	
	
//--------------------------------------------------------------------------
	












	/*
		根据传回类型AttcakeType来确定不同的伤害伤害计算和不同的伤害类别
		0 = 单体
		1 = 群体
		4 = 溅射
	*/
		//群体+？
		if (CardAttackeType1==(AttcakeType)1)
		{
			//群体+单体=A+B*1/3   群体DmScr
			if (CardAttackeType2==(AttcakeType)0)
			{
				float linshi=CardDamage1+CardDamage2*0.35f;
				Reckon=(int)linshi;
				BmAttackeType=(AttcakeType)1;
			}
			//群体+群体=A+B   群体DmScr
			if (CardAttackeType2==(AttcakeType)1)
			{
				Reckon=CardDamage1+CardDamage2;
				BmAttackeType=(AttcakeType)1;
			}
			//群体+溅射=A+B*1/2   群体DmScr
			if (CardAttackeType2==(AttcakeType)4)
			{
				float linshi = CardDamage1+CardDamage2*0.5f;
				Reckon=(int)linshi;
				BmAttackeType=(AttcakeType)1;
			}
			//群体+单体治疗
			if (CardAttackeType2==(AttcakeType)3)
			 {
				 float linshiCure=Card1Cure+Card2Cure*0.3f;
				CureReckon=(int)linshiCure;
				float linshi=CardDamage1+CardDamage2*0.3f;
				Reckon=(int)linshi;
				BmAttackeType=(AttcakeType)1;
		 	}
			//群体+群体治疗
			if (CardAttackeType2==(AttcakeType)3)
			{
				CureReckon=Card1Cure+Card2Cure;
				Reckon=CardDamage1+CardDamage2;
				BmAttackeType=(AttcakeType)1;
			}
		}
		//单体+？
		if (CardAttackeType1==(AttcakeType)0)
		{
			//单体+单体=A+B   单体
			if (CardAttackeType2==(AttcakeType)0)
			{
				Reckon=CardDamage1+CardDamage2;
				BmAttackeType=(AttcakeType)0;
			}
			//单体+群体=A*1/3+B  群体DmScr
			if (CardAttackeType2==(AttcakeType)1)
			{
				float linshi = CardDamage1*0.35f+CardDamage2;
				Reckon=(int)linshi;
				BmAttackeType=(AttcakeType)1;
			}
			//单体+溅射=A*2/3+B  溅射R
			if (CardAttackeType2==(AttcakeType)4)
			{
				float linshi = CardDamage1*0.6f+CardDamage2;
				Reckon=(int)linshi;
				BmAttackeType=(AttcakeType)4;
			}
			//单体+单体治疗
			 if (CardAttackeType2==(AttcakeType)2)
			 {
				CureReckon=CardDamage1+Card2Cure;
				Reckon=CardDamage1+CardDamage2;
				BmAttackeType=(AttcakeType)0;

			 }
			 //单体+群体治疗
			 if (CardAttackeType2==(AttcakeType)3)
			 {
				float linshiCure=CardDamage1*0.3f+Card2Cure;
				CureReckon=(int)linshiCure;
				float linshi = CardDamage1*0.3f+CardDamage2;
				Reckon=(int)linshi;
				BmAttackeType=(AttcakeType)1;
			 }
		}
		//溅射+?
		if (CardAttackeType1==(AttcakeType)4)
		{
			//溅射+单体=A+B*2/3 溅射R
			if (CardAttackeType2==(AttcakeType)0)
			{
				float linshi = CardDamage1+CardDamage2*0.6f;
				Reckon=(int)linshi;
				BmAttackeType=(AttcakeType)4;
			}
			//溅射+群体=A*1/2+B 群体DmScr
			if (CardAttackeType2==(AttcakeType)1)
			{
				float linshi = CardDamage1*0.5f+CardDamage2;
				Reckon=(int)linshi;
				BmAttackeType=(AttcakeType)1;
			}
			//溅射+溅射=A+B*2/3 溅射R
			if (CardAttackeType2==(AttcakeType)4)
			{
				Reckon=CardDamage1+CardDamage2;
				BmAttackeType=(AttcakeType)4;
			}
			//溅射+单体治疗
			if(CardAttackeType2==(AttcakeType)2){
				float linishiCure=CardDamage1+Card1Cure*0.6f;
				CureReckon=(int)linishiCure;
				float linshi=CardDamage1+CardDamage2*0.6f;
				Reckon=(int)linshi;
				BmAttackeType=(AttcakeType)4;
			}
			//溅射+群体治疗
			if (CardAttackeType2==(AttcakeType)3)
			{
				float linshiCure = CardDamage1*0.5f+Card1Cure;
				CureReckon=(int)linshiCure;
				float linshi = CardDamage1*0.5f+CardDamage2;
				Reckon=(int)linshi;
				BmAttackeType=(AttcakeType)1;
			}
	}
//-----------------------------------------










//--------------------------------------------------------------------------
/*
	将Reckon传入地形运算脚本
	重新给Reckon赋值
*/
	//准备数据传参 
	double [] numObj={22.1};
	if (BmAttackeType==(AttcakeType)0)
	{
		//新建用于接受 GroundScr 中 场景数据库变量？对象？
		GroundLib gb = GroundScr._instance.groundLib;
		Reckon= gb.ReckonRule1(numObj);
	}
	
//--------------------------------------------------------------------------

	
/*
	根据上方计算的BmAttackeType结果来使用传参
*/
	 //伤害结算
		if (BmAttackeType==(AttcakeType)0)
		{
			PublicFightScr._instance.StarFunction("Damaged");
			PublicFightScr._instance.StarFunction2(Reckon.ToString());
			
		}else if (BmAttackeType==(AttcakeType)1)
		{
			DmScr._instance.Dm(Reckon);
		}else if (BmAttackeType==(AttcakeType)4)
		{
			PublicFightScr._instance.StarFunction("R");
			PublicFightScr._instance.StarFunction2(Reckon.ToString());
		}
	//神奇输入↓
		else
		{
			Debug.Log("The AttcakeType is Wrong! 你输入了什么鬼？");
		}
		Debug.Log("jo方法末端 Cure:"+CureReckon);
	//治疗结算↓
		if (CureReckon!=0)
		{
			PlayerFightScr._instance.StarFuntion("Cure");
			PlayerFightScr._instance.StarFuntion2(CureReckon.ToString());
		}
/*
	执行 BuffScr 脚本，进行buff计算
*/
	 BuffScr._instance.Card1_Buff(Cardid1);
	 BuffScr._instance.Card2_Buff(Cardid2);
	 BuffScr._instance.ReckonBuff();
	 Debug.Log("-------------------");	

	}
	

	///<summary>
	///ReadCard-初始化数据
	///</summary>
	public void InitDate(){
		Cardid1=null;
		Cardid2=null;
		BmAttackeType=(AttcakeType)7;
		CardDamage1=0;
		CardDamage2=0;
		CardAttackeType1=0;
		CardAttackeType2=0;
		Reckon=0;

	}

}
