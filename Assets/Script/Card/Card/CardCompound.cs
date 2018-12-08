using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
/// 该脚本用于卡牌合成是否为BM（最佳合成）的判断以及是BM是所执行的操作
///</summary>
public class CardCompound : MonoBehaviour {
    public static CardCompound _instance;
    Dictionary<string, string> d1= new Dictionary<string, string>();
    private string DicReturn;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        d1.Add("EL01Fi&EL02Fi", "1%2");  //添加最佳卡牌
        d1.Add("EL02Fi&EL01Fi", "1%2");
    }

    ///<summary>
    ///
    ///</summary>
    public void ShowButton3()
    {
         string a1=null, a2=null;  //构成  a1&a2 


      
        // Debug.Log("a1 :"+a1+ " a2 :"+a2);
        FindDic(a1, a2);   
    }

    public string FindDic(string a1, string a2)   
    {
        DicReturn = "";
        if (d1.ContainsKey(a1 + "&" + a2))
        {
            
            DicReturn = d1[a1 + "&" + a2];
            Debug.Log("Bm合成卡牌");
        }
        else
        {
            Debug.Log("非Bm合成卡牌");
             ReadCard._instance.SetId(a1, a2);
        }
        // Debug.Log("++" + d1.ContainsKey(a1 + "&" + a2));
        // Debug.Log("Dic" + DicReturn);
        return DicReturn;
    }
}
