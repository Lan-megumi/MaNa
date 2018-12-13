using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
	该脚本用于发牌以及实现实例化卡牌Ui功能
 */
public class TestMananger : MonoBehaviour
{
    public static TestMananger Instance;

    public static TestMananger _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(TestMananger))as TestMananger;
            }
            return Instance;
        }
    }
    ///<summary>
    /// 储存卡牌的GameObject数组
    ///</summary>
    public List<GameObject> CardLibrary;
     ///<summary>
    /// 储存卡牌的具体数据数组
    ///</summary>
    public List<TestCard> Library1;
//-----------------------------------------------------
    //	定义用于接收卡牌属性的临时变量
    // [HideInInspector]
    public string Cardid,CardName;
    public Type CardType;
    public Element_type CardEle;
    public Rarity CardRarity;
    public int CardCost,ChoseNum;

    //-----------------------------------------------------	
    private int b= 0;
    //用于储存当前卡库的索引到的最后一张牌的位置
    private int d;
    
    void Start()
    {
        Library1 = new List<TestCard>();
        // Init();
    }

    //该方法功能为发牌，并且与Ui功能交互
    public void VisableCard()
    {
        bool IFOrd=false;
        Debug.Log("发牌！");
        //同步卡库
        Library1 = TestCardLibrary._instance.Library0;
        //初始化各个脚本的关键值
        CardCompound._instance.Init();
        Init();
        //循环给卡牌填值
        for (int i = 0; i < CardLibrary.Count; i++)
        {
            // Debug.Log("aa" + Library1);
            Cardid = Library1[b].GetCardid;
            CardType = Library1[b].GetCardType;
            CardEle = Library1[b].GetCardElement_type;
            CardRarity = Library1[b].GetCardRarity;
            CardName = Library1[b].GetCardName;
            CardCost=Library1[b].GetCardCost;
            //调用相应方法传值以及改变Ui
            CardLibrary[i].GetComponent<CardUi>().ChangeUiDate(Cardid, CardType, CardEle, CardRarity, CardName);
            CardLibrary[i].GetComponent<TestCardScr>().SetDate(Cardid,CardCost);
            CardLibrary[i].GetComponent<TestCardScr>().Init();
            d =b;
            b++;
            //当循环到牌库上限时，将索引归零并且提示发牌之后洗牌
             if (b >= Library1.Count)
            {
                b = 0;
                IFOrd=true;
            }

        }
        if (IFOrd==true)
        {
            // TestCardLibrary._instance.OrbLibrary();
            IFOrd=false;
        }
    }
    ///<summary>
    /// 执行检查目前选了第几张牌
    ///</summary>
    public void CheckChoseNum(bool bt){
        if (ChoseNum<3)
        {
            if (bt==true)
            {
                ChoseNum++;
            }else
            {
                ChoseNum--;
            }
        }else
        {
            Debug.Log("来自TestManager的报告：ChoseNum超过3");
        }
    }
    public void InitUi(){
        for(int i =0;i<CardLibrary.Count;i++){
            CardLibrary[i].GetComponent<CardUi>().Set_BchoseUi(false);
            CardLibrary[i].GetComponent<TestCardScr>().Init();
        }
    }

 //-------------------------------   
    public int Re_ChoseNum(){
        return ChoseNum;
    }
    public int Re_ArrayNum_d(){
        return d;
    }
    public void Init(){
        ChoseNum=0;
    }
}
    


