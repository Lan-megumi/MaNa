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

    public List<GameObject> CardLibrary;
    public List<TestCard> Library1;

    // //-----------------------------------------------------
    //	定义用于接收卡牌属性的类
    [HideInInspector]
    public string Cardid,Cardid1,Cardid2,Cardid3,Cardid4;
    public Type CardType;
    public Element_type CardEle;
    public Rarity CardRarity;
    public string CardName;

    // public string CardName1, CardName2, CardName3;

    //----------------------------------------------------

    public bool bCard, bCard1, bCard2,bCard3 = false;//融合条件，true已选，false未选
    public Text text, text1, text2,text3;//是否选择
    public bool[] bCardbool;  //已选中数组
    private bool[] BCardbool;
    public int bCardboolNum=0;
    public int BCardboolNum=0;
    

    public bool BCard, BCard1,BCard2,BCard3;
    //-----------------------------------------------------	
    private int b= 0;
    private int d;
    
    void Start()
    {
        Library1 = new List<TestCard>();
        // Debug.Log("TestManager Star");
        
        // VisableCard();
    }
   
    public void Fix()   //在CardCompound 里面调用 ，初始化选择（未选）
    {
        bool [] bCardObj={
            bCard,bCard1,bCard2,bCard3
        };
        for(int i=0;i<bCardObj.Length;i++)
        {
            if(bCardObj[i]==true){
                bCardObj[i]=false;
            }   
        }
    }



    public void ShotA()  //是否选中第一张卡牌，判断是否已选择了2张
    {
        
            BCard = true;
            if (bCard == false)
            {
                if (bCard1 == false && bCard2 == true&&bCard3==true||
                bCard1 == true && bCard2 == false&&bCard3==true||
                bCard1 == true && bCard2 == true&&bCard3==false)
                {
                    text.text = "已选够2张";
                    
                }
                else
                {
                    text.text = "已选";
                    bCard = true;
                }
            }
            else
            {
                text.text = "未选";
                bCard = false;
                //BCard=false;
            }
        
        ShotAA();   //运行检测
    }


    public void ShotB()         //是否选中第二张卡牌   
    {
       
            BCard1 = true;
            if (bCard1 == false)
            {
                if (bCard == false && bCard2 == true&&bCard3==true||
                bCard == true && bCard2 == false&&bCard3==true||
                bCard == true && bCard2 == true&&bCard3==false)
                {
                    text1.text = "已选够2张";
                }
                else
                {
                    text1.text = "已选";
                    bCard1 = true;
                }
            }
            else
            {
                text1.text = "未选";
                bCard1 = false;
                //BCard1=false;
            
        }
        ShotAA();
    }


    public void ShotC()       //是否选中第三张卡牌   
    {
        
            BCard2 = true;
            if (bCard2 == false)
            {
                if (bCard == false && bCard3 == true&&bCard1==true||
                bCard == true && bCard3 == false&&bCard1==true||
                bCard == true && bCard3 == true&&bCard1==false)
                {
                    text2.text = "已选够2张";
                }
                else
                {
                    text2.text = "已选";
                    bCard2 = true;
                }
            }
            else
            {
                text2.text = "未选";
                bCard2 = false;
                //BCard2=false;
            
        }
        ShotAA();
    }
    public void ShotD()       //是否选中第三张卡牌   
    {
        
            BCard3 = true;
            if (bCard3 == false)
            {
                if (bCard == false && bCard2 == true&&bCard1==true||
                bCard == true && bCard2 == false&&bCard1==true||
                bCard == true && bCard2 == true&&bCard1==false)
                {
                    text3.text = "已选够2张";
                }
                else
                {
                    text3.text = "已选";
                    bCard3 = true;
                }
            }
            else
            {
                text3.text = "未选";
                bCard3 = false;
                //BCard3=false;
            
        }
        ShotAA();
    }

    public void button3()//点击融合，显示id,      （其余内容未补完）//出牌条件，不得出单张或者3张
    {
        bool[] bCardbool={bCard,bCard1,bCard2,bCard3};
        for(int i=0;i<bCardbool.Length;i++){
            Debug.Log(bCardbool[i]);
            if(bCardbool[i]==true){
                  bCardboolNum++;
             }
        }
            Debug.Log("bCardboolNum:"+bCardboolNum);
            if(bCardboolNum>2||bCardboolNum==1){
                Debug.Log("这样出牌不行");
            }else{
                if (bCard == true) {        //获取第一张卡牌的id
                Cardid1 = Library1[d - 3].GetCardid;
                // CardName1 = Library1[d - 3].GetCardName;
                
                Debug.Log("融合了:" + Cardid1);
       
            }
            if (bCard1 == true)        //第二张id
            {
                    Cardid2 = Library1[d - 2].GetCardid;
                    // CardName2 = Library1[d - 2].GetCardName;
                    Debug.Log("融合了" + Cardid2);
                
            }
            if (bCard2 == true)         //第三张id
            {
                    Cardid3 = Library1[d-1].GetCardid;
                    // CardName = Library1[d-1].GetCardName;
                    Debug.Log("融合了" + Cardid3);
                
            }
            if(bCard3 ==true){
                Cardid4=Library1[d].GetCardid;
                Debug.Log("融合了"+Cardid4);
            
            }
        }


        // if (bCard == true && bCard1 == true && bCard2 == true &&bCard3==true||       
        //     bCard == true && bCard1 == false && bCard2 == false&&bCard3==false ||
        //     bCard == false && bCard1 == true && bCard2 == false&&bCard3==false ||
        //     bCard == false && bCard1 == false && bCard2 == true&&bCard3==false||
        //     bCard == false && bCard1 == false && bCard2 == false&&bCard3==true)
        // {
        //     Debug.Log("这样出牌系不可以滴，一次必须出2张牌");

        // }else {
            
        //    if (bCard == true) {        //获取第一张卡牌的id
        //         Cardid1 = Library1[d - 3].GetCardid;
        //         // CardName1 = Library1[d - 3].GetCardName;
                
        //         Debug.Log("融合了:" + Cardid1);
       
        //     }
        //     if (bCard1 == true)        //第二张id
        //     {
        //             Cardid2 = Library1[d - 2].GetCardid;
        //             // CardName2 = Library1[d - 2].GetCardName;
        //             Debug.Log("融合了" + Cardid2);
                
        //     }
        //     if (bCard2 == true)         //第三张id
        //     {
        //             Cardid3 = Library1[d-1].GetCardid;
        //             // CardName = Library1[d-1].GetCardName;
        //             Debug.Log("融合了" + Cardid3);
                
        //     }
        //     if(bCard3 ==true){
        //         Cardid4=Library1[d].GetCardid;
        //     }
        // }
    }

    //该方法功能为发牌，并且与Ui功能交互
    public void VisableCard()
    {
        text.text = "未选";  //发牌后，已选择变为未选
        text1.text = "未选";
        text2.text = "未选";
        text3.text="未选";
        
        Debug.Log("发牌！");
        // UpdateLibrary();
        Library1 = TestCardLibrary._instance.Library0;
        //Debug.Log("1:" + Library1[1]);
        /*
			i上限为Ui界面牌的数量，3
		 */
         //界面显示初始化卡牌内容

        for (int i = 0; i < CardLibrary.Count; i++)
        {
            // Debug.Log("aa" + Library1);
            if (b == Library1.Count)
            {
                b = 0;
            }
            Cardid = Library1[b].GetCardid;
            CardType = Library1[b].GetCardType;
            CardEle = Library1[b].GetCardElement_type;
            CardRarity = Library1[b].GetCardRarity;
            CardName = Library1[b].GetCardName;

            CardLibrary[i].GetComponent<CardUi>().ChangeUi(Cardid, CardType, CardEle, CardRarity, CardName);
            d =b;
            b++;
            

        }
    }
    public void ShotAA()    //判断获取第几张卡牌
    {
        Debug.Log("------------------");
        Debug.Log("ShotAA-d:" + d);
        bool[] BCardbool={BCard,BCard1,BCard2,BCard3};
        for(int i=0;i<BCardbool.Length;i++){
            if(BCardbool[i]==true){
            Cardid = Library1[i].GetCardid;
            CardType = Library1[i].GetCardType;
            CardEle = Library1[i].GetCardElement_type;
            CardRarity = Library1[i].GetCardRarity;
            CardName = Library1[i].GetCardName;
            BCardbool[i]=false;
            Debug.Log("BCardbool[i]"+BCardbool[i]);
            Debug.Log("选中的Cardid"+Cardid);
             }
        }

// d=3    
// 4 =d    i=3   
// 3 =d-1  i=2
// 2 =d-2  i=1
// 1 =d-3  i=0

//d=i
        
        // if(BCard3==true){
        //     Cardid = Library1[d].GetCardid;
        //     CardType = Library1[d].GetCardType;
        //     CardEle = Library1[d].GetCardElement_type;
        //     CardRarity = Library1[d].GetCardRarity;
        //     CardName = Library1[d].GetCardName;
        //     BCard3 = false;
        // }
        // if (BCard2 == true)    //第三张卡牌的信息
        // {
        //     Cardid = Library1[d-1].GetCardid;
        //     CardType = Library1[d-1].GetCardType;
        //     CardEle = Library1[d-1].GetCardElement_type;
        //     CardRarity = Library1[d-1].GetCardRarity;
        //     CardName = Library1[d-1].GetCardName;
   
        //     BCard2 = false;
            
        // }
        // if (BCard1 == true)        //第二张卡牌的信息
        // {

        //     Cardid = Library1[d - 2].GetCardid;
        //     CardType = Library1[d - 2].GetCardType;
        //     CardEle = Library1[d - 2].GetCardElement_type;
        //     CardRarity = Library1[d - 2].GetCardRarity;
        //     CardName = Library1[d - 2].GetCardName;
    
        //     BCard1 = false;
            
        // }
        // if (BCard == true)             //第一张卡牌的信息
        // {
        //     Cardid = Library1[d - 3].GetCardid;
        //     CardType = Library1[d - 3].GetCardType;
        //     CardEle = Library1[d - 3].GetCardElement_type;
        //     CardRarity = Library1[d - 3].GetCardRarity;
        //     CardName = Library1[d - 3].GetCardName;
        //     BCard = false;
            
        // }
        Fix();  //初始化卡牌是否选择
    }
}
    


