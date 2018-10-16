using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    该脚本功能
    实现根据角色速度影响操作回合
 */
public class CoroutineCountdown : MonoBehaviour
{
    public static CoroutineCountdown _instance;

    public Text time1,time2,Notetext;

//显示滑动值----------------
    public int tt1 = 0;
    public int tt2 = 0;
//---------------------------

    private int i = 1;

//用于接收Player1的速度
    private float Player1Speed=7;
//用于接收Player2的速度
    private float Player2Speed=10;

    private float c ;
    private float d;
//---------------------------

//滑动条
    public Slider targetSliderOject,targetSliderOject1;
//滑动条的文本控件
    public Text targetTextObject,targetTextObject1;

//---------------------------------
    private  GameObject Player1bt1,Player1bt11;

    private  GameObject Player2bt2,Player2bt21;


    private void Awake()
    {
        _instance = this;
        c = 1 / Player1Speed;
        d = 1/Player2Speed;
        Debug.Log("cc" + c);
        Debug.Log("dd" + d);
    }
    

    void Start()
    {
        //谁先出手
        NextTrun();

        Player1bt1 = GameObject.Find("SpeedCanvas/Button1");
        Player1bt11 = GameObject.Find("SpeedCanvas/Button11");

         Player2bt2 = GameObject.Find("SpeedCanvas/Button2");
         Player2bt21 = GameObject.Find("SpeedCanvas/Button21");


    }
   
   public void NextTrun(){
       if (i == -1 & Player1Speed <= 0)
        {
            i = 1;
            Player1Speed = 7;
        }
        if (i == -1 & Player2Speed <= 0)
        {   
            i = 1;
            Player2Speed = 10;
        }
   }
    void  Update()
    {
        targetTextObject.text = "滑动值为 " + targetSliderOject.value;
        targetTextObject1.text = "滑动值为 " + targetSliderOject1.value;
        time1.text = tt1.ToString();
        time2.text = tt2.ToString();

        if (i == 1)
        {
            Player1Speed--;
            Player2Speed--;
            //
            targetSliderOject.value += c;
            if (targetSliderOject.value  ==1)
            {
                targetSliderOject.value=0;
            }
            targetSliderOject1.value += d;
            if (targetSliderOject1.value ==1)
            {
                targetSliderOject1.value = 0;
            }


        }
        if (Player1Speed <= 0)
        {
            i = -1;
            time2.text = Player2Speed.ToString();
            Player2();            
            Player1();
        }

        if (Player2Speed <= 0)
        {
            i = -1;
            time1.text = Player1Speed.ToString();
            Player1();
            Player2();
        }
        // Debug.Log("a=" + a);
        // Debug.Log("b=" + b);
        
    }

    public void CheckedPlayer(){
        if (Player1Speed==0)
        {
            
        }
    }
   //回合的判定

    public void Player1()//我方回合，禁止对面
    {
        Notetext.text = "我方回合";
        Button Bt1 = (Button)Player1bt1.GetComponent<Button>();
        Bt1.interactable = true;

        Button Bt11 = (Button)Player1bt11.GetComponent<Button>();
        Bt11.interactable = true;

        if (Player2Speed == 0)
        {
            Bt1.interactable = false;
            Bt11.interactable = false;
        }
    }
    public void Player2()//敌方回合，禁止对面
    {
        Button Bt2 = (Button)Player2bt2.GetComponent<Button>();
        Bt2.interactable = true;

        Button Bt21 = (Button)Player2bt21.GetComponent<Button>();
        Bt21.interactable = true;
        
        if (Player1Speed == 0)
        {
            Bt2.interactable = false;
            Bt21.interactable = false;
        }
        Notetext.text = "敌方回合";
    }



}

    
    




