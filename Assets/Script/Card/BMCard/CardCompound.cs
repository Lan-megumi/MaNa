using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
/// 该脚本用于卡牌合成是否为BM（最佳合成）的判断以及是BM是所执行的操作
///</summary>
public class CardCompound : MonoBehaviour {
    public static CardCompound Instance;

    public static CardCompound _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(CardCompound))as CardCompound;
            }
            return Instance;
        }
    }
    Dictionary<string, string> d1= new Dictionary<string, string>();
    private string DicReturn;
    //储存两个卡的id
    public  string a1, a2;  //构成  a1&a2 
    //储存两个卡的消耗
    public int b1,b2;

    void Awake()
    {
        d1.Add("EL01Fi&EL02Fi", "Bm01Fi");  //添加最佳卡牌
        d1.Add("EL02Fi&EL01Fi", "Bm01Fi");
        a1=null;
        a2=null;
    }

    ///<summary>
    /// 绑定于组合按钮
    ///</summary>
    public void ShowButton3()
    {
        //判断是否有卡牌进入合成
        if (a1!=null||a2!=null)
        {
            //获取玩家的Mana条
            int Mana=PlayerDate._instance.ReturnMana();
            int cardC1=Re_b1();
            int cardC2=Re_b2();
            if(cardC1+cardC2<=Mana){
                FindDic(a1, a2);
                Debug.Log("b1+b2"+(-cardC1-cardC2));
                PlayerDate._instance.ReckonMana(-(cardC1+cardC2));
            }else{
                Debug.Log("来自CardCompound的报告：你的Mana不够");
            }
        }else
        {
            Debug.Log("未传回两个id");
        }
    }

    public string FindDic(string a1, string a2)   
    {
        DicReturn = "";
        if (d1.ContainsKey(a1 + "&" + a2))
        {
            
            DicReturn = d1[a1 + "&" + a2];
            Debug.Log("Bm合成卡牌");
            BmCardScr._instance.ChangeBm(DicReturn);
        }
        else
        {
            Debug.Log("非Bm合成卡牌");
            ReadCard._instance.SetId(a1, a2);
        }
        Init();
        return DicReturn;
    }
//--------------------------------------------
    //储存与删除id的方法
    public void Saveid(string id){
        if (Re_a1()==null)
        {
            a1=id;
        }else if(Re_a2()==null){
            a2=id;
        }else{
            Debug.Log("来自CardCompound的报告：已经储存了两个id");
        }

    }
    public void Deletid(int i){
        if (i==2)
        {
            a2=null;
        }else if (i==1)
        {
            a1=null;
        }else
        {
            Debug.Log("来自CardCompound的报告：没有储存任何id");
            
        }
    }
//--------------------------------------------------
    public void SetCost(int cost){
        if (Re_b1()==0)
        {
            b1=cost;
        }else if(Re_b2()==0){
            b2=cost;
        }else{
            Debug.Log("来自CardCompound的报告：已经储存了两个消耗");
        }
    }
    public void DeletCost(int i){
        if (i==2)
        {
            b2=0;
        }else if (i==1)
        {
            b1=0;
        }else
        {
            Debug.Log("来自CardCompound的报告：没有储存任何消耗");
            
        }
    }
//--------------------------------------------------
    //返回方法
    public string Re_a1(){
        return a1;
    }
    public string Re_a2(){
        return a2;
    }
     public int Re_b1(){
        return b1;
    }
    public int Re_b2(){
        return b2;
    }
    public void Init(){
        a1=null;
        a2=null;
        b1=0;
        b2=0;
    }
}
