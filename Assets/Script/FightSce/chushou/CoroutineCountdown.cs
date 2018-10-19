﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    该脚本功能
    实现根据角色速度影响操作回合
    分别表示玩家和敌人的回合
 */
public class CoroutineCountdown : MonoBehaviour
{
    public static CoroutineCountdown _instance;

    public Text Notetext;

    public bool IfPlayer;

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
//---------------------------------

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

        //当出现两个速度相同时的情况
        if (Player1Speed==Player2Speed)
        {
            int randomn=new System.Random().Next(0,10);
            Debug.Log("Random!"+randomn);
            if(randomn>=4) 
            {
                //玩家优先，敌人数值+1
                Player2Speed+=1;
            }else
            {
                //敌人优先，玩家数值+1
                Player1Speed+=1;
            }
            // Debug.Log("RandomSpeed:"+Player1Speed+"|"+Player2Speed);
        }
        //
        if (Player1Speed <= 0&&i==1)
        {
            i = -1;
            CheckedPlayer();
            // Debug.Log("Speed:"+Player1Speed+"|"+Player2Speed);

        }else if (Player2Speed <= 0&&i==1)
        {
            i = -1;
            CheckedPlayer();
            // Debug.Log("Speed:"+Player1Speed+"|"+Player2Speed); 
        }
    }
//  检查player
    public void CheckedPlayer(){
        if (Player1Speed==0)
        {
            
            Notetext.text="你的回合";
        }else if(Player2Speed==0){
            CountDebuff._instance.EnemyComputeDebuff();
            Notetext.text="敌方回合";
        }
    }

    public void Function_Dizzy(string Who){
        if (Who=="Player")
        {
             i = 1;
            Player1Speed = 7;
        }else if (Who=="Enemy")
        {
            i = 1;
            Player2Speed = 10;
        }
    }
}

    
    




