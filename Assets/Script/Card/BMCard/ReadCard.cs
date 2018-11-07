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
	public static ReadCard _instance;

	void Awake(){
		_instance=this;
	}

//------------------------------------------
	public string Cardid1,Cardid2;
	private int CardDamage1,CardDamage2,Reckon;
	private AttcakeType CardAttackeType1,CardAttackeType2,BmAttackeType;
//------------------------------------------

	// Use this for initialization
	void Start () {
		Library2 = new List<TestCard>();
	}

//这里是公开的传入参数的方法
/*
	该传入参数将被作用于jo()方法中，并且是触发jo()方法的唯一接口
	*/
	public void SetId(string id1,string id2){
		Cardid1=id1;
		Cardid2=id2;
		jo();
	}

/*
	合成调用的方法
	目前暂时只是根据id找到卡牌对应的伤害没有根据伤害类型
*/
	public void jo(){
	//首先同步卡牌，因为牌库有可能被洗牌，不过好像洗了牌也不影响
		Library2=TestCardLibrary._instance.Library0;
		// Debug.Log("Card1"+Cardid1+" | Card2:"+Cardid2);
		for(int i =0 ;i<Library2.Count;i++){

		//获取Damage值和AttacakeType
			if (Library2[i].GetCardid==Cardid1)
			{
				CardDamage1+=Library2[i].GetCardDamage;
				CardAttackeType1=Library2[i].GetAttcakeType;

				Debug.Log("CardDamage1:"+CardDamage1);
			}
			if (Library2[i].GetCardid==Cardid2)
			{
				CardDamage2+=Library2[i].GetCardDamage;
				CardAttackeType2=Library2[i].GetAttcakeType;
				Debug.Log("CardDamage2:"+CardDamage2);
			}
			// Debug.Log("Id"+i+":"+Library2[i].GetCardid);
		}
		


//------------------------------------------------------------
	/*
		区别于伤害的治疗
		2 - 单体治疗
		3 - 群体治疗
	 */
		//群体+？
		if (CardAttackeType1==(AttcakeType)3)
		{
			//群体+单体=A+B*1/3   群体DmScr
			if (CardAttackeType2==(AttcakeType)2)
			{
				float linshi=CardDamage1+CardDamage2*0.35f;
				Reckon=(int)linshi;
				BmAttackeType=(AttcakeType)3;
			}
			//群体+群体=A+B   群体DmScr
			if (CardAttackeType2==(AttcakeType)3)
			{
				Reckon=CardDamage1+CardDamage2;
				BmAttackeType=(AttcakeType)3;
			}
			// //群体+溅射=A+B*1/2   群体DmScr
			// if (CardAttackeType2==(AttcakeType)4)
			// {
			// }
		}
		//单体治疗+？
		if (CardAttackeType1==(AttcakeType)2)
		{
			//单体+单体=A+B   单体治疗
			if (CardAttackeType2==(AttcakeType)2)
			{
				Reckon=CardDamage1+CardDamage2;
				BmAttackeType=(AttcakeType)2;
			}
			//单体+群体=A*1/3+B  群体治疗DmScr
			if (CardAttackeType2==(AttcakeType)3)
			{
				float linshi = CardDamage1*0.35f+CardDamage2;
				Reckon=(int)linshi;
				BmAttackeType=(AttcakeType)3;

			}
			// //单体+溅射=A*2/3+B  溅射R
			// if (CardAttackeType2==(AttcakeType)4)
			// {
			// }
		}
		//溅射+?
	// 	if (CardAttackeType1==(AttcakeType)4)
	// 	{
	// 		//溅射+单体=
	// 		if (CardAttackeType2==(AttcakeType)0)
	// 		{
	// 		}
	// 		//溅射+群体=
	// 		if (CardAttackeType2==(AttcakeType)1)
	// 		{
	// 		}
	// 		//溅射+溅射=
	// 		if (CardAttackeType2==(AttcakeType)4)
	// 		{
	// 		}
	// }
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
	}
//-----------------------------------------








	/*
		区别于伤害、治疗的Debuff释放
	*/

//--------------------------------------------------------------------------
	/*
		根据上方计算的BmAttackeType结果来使用传参
	 */
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
	//治疗结算↓
		else if (BmAttackeType==(AttcakeType)2)
		{
			PublicFightScr._instance.StarFunction("Cure");
			PublicFightScr._instance.StarFunction2(Reckon.ToString());

		}else if (BmAttackeType==(AttcakeType)3)
		{
			DmScr._instance.DmCure(Reckon);

		}
	//神奇输入↓
		else
		{
			Debug.Log("The AttcakeType is Wrong! 你输入了什么鬼？");
		}
	}
	


	//在结算完成后执行清空数据初始化数据
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
