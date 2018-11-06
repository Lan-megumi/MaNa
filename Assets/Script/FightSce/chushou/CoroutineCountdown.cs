using System.Collections;
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

    private int igg = 1;    //初始条件

//用于接收Player1的速度
    private float Player1Speed=60;
//用于接收Player2的速度
    
    private float c;
//---------------------------

//滑动条
    public Slider targetSliderOject;
    public static List<GameObject> gm;
    public static List<Slider> iiSlider;

    private GameObject Emeny;
    public float[] Agis; //速度
    public float[] SpeedAgis;//每帧速度
    public float[] AgisMax;//速度最大值   50  150 

    //---------------------------------

    private void Awake()
    {
        _instance = this;

        c = 1/Player1Speed;    
        Debug.Log("cc" + c);
    }
    
    
    void Start()
    {
        //谁先出手
        //NextTrun();
        gm = new List<GameObject>();
        iiSlider = new List<Slider>();
       

    }
    public void Agiss( )
    {
        AgisMax = new float[gm.Count];              //速度最大值数组
        Agis = new float[gm.Count];                 //速度数组
        SpeedAgis = new float[gm.Count];            // 1/速度

        for (int g = 0; g < gm.Count; g++)
        {
            float avg = gm[g].GetComponent<EmenyScr>().Agi;
           
            Debug.Log("aasd:" + avg);
            AgisMax[g] = avg;
            Agis[g] = avg;
            //Agiss(avg);
            SpeedAgis[g] = 1/avg;
            Debug.Log(SpeedAgis[g]+"平均");
        }
    }

   public void NextTrun(){                
        
        if (igg == -1 & Player1Speed == 0)
        {
            igg = 1;
            Player1Speed = 60;
        }
        for(int g=0; g <Agis.Length; g++)
        {
            if (igg == -1 & Agis[g] <= 0)
            {
                igg = 1;
                Agis[g]=AgisMax[g] ;               //变回最大值
                //Debug.Log(Agis[g] + ":" + AgisMax[g]);
                Debug.Log( "io:" + igg);
            }
        }
   }
    void  Update()
    {
        
        // Debug.Log("第II:" + this.igg);
        if (StartGame._instance.Startbool == true)
        {
            // Debug.Log("II:" + this.igg);
            if (igg == 1)
            {
                Player1Speed--;
                // Debug.Log("III:" + Agis.Length);
                for (int g = 0; g < Agis.Length; g++)
                {
                    Agis[g]--;
                    iiSlider[g].value += SpeedAgis[g];
                    if (iiSlider[g].value >= 1)
                    {
                        //敌人 回合结束
                        iiSlider[g].value = 0;
                        gm[g].GetComponent<CountDebuff>().EnemyComputeDebuff();                    }
                }

                targetSliderOject.value += c;               //玩家每帧数速度
                if (targetSliderOject.value >= 1)           
                {
                    //玩家 回合结束
                    targetSliderOject.value = 0;
                    TestMananger._instance.VisableCard();
                }
                for (int g = 0; g < Agis.Length; g++)      
                {
                    if (Player1Speed == Agis[g])            //玩家跟敌人速度相等的话
                    {
                        // Debug.Log("查看" + Agis[g]);
                        int randomn = new System.Random().Next(0, 10);
                        Debug.Log("Random!" + randomn);
                        if (randomn >= 4) 
                        {
                            //玩家优先，敌人数值+1
                            Agis[g] += 1;
                        }
                        else
                        {
                            //敌人优先，玩家数值+1
                            Player1Speed += 1;
                        }

                    }
                }
                //
                if (Player1Speed <= 0 && igg == 1)          //当玩家速度为0
                {
                    igg = -1;
                    // Debug.Log("jkhg手打");
                    CheckedPlayer();
                }
                    for (int g = 0; g < Agis.Length; g++)
                    {
                        if (Agis[g] <= 0 && igg == 1)          
                        {
                            // Debug.Log("创建的回合");
                            igg = -1;
                            CheckedPlayer();
                            // Debug.Log("创建的回合2");
                            // Debug.Log("创建的回合3" + igg);
                        }
                    }
                
            }
            
        }
    }
//  检查player
    public void CheckedPlayer(){
        if (Player1Speed==0)
        {
            
            Notetext.text="你的回合";
            Debug.Log("111111");
        }
       
        for (int g = 0; g < Agis.Length; g++)
        {
            if (Agis[g] == 0)
            {
                Notetext.text="敌方回合";
                Debug.Log("333333");
            }
        }
    }

    public void Function_Dizzy(string Who){
        //if (Who=="Player")
        //{
        //     i = 1;
        //    Player1Speed = 60;
        //    Debug.Log("xxxxxxx");
        //}else if (Who=="Enemy")
        //{
        //    i = 1;
        //    Player2Speed = 70;
        //    for(int g = 0; g < Agis.Length; g++)
        //    {
        //    Agis[g] = AgisMax[g];

        //    Debug.Log(Agis[g]);
        //    }
        //}
    }
}




//targetSliderOject1.value += d;
//if (targetSliderOject1.value >= 1)
//{
//    targetSliderOject1.value = 0;

//}

//for (int i = 0; i < targetSliders.Count; i++)
//{
//    targetSliders[i].value += d;
//    if (targetSliders[i].value == 1)
//    {
//        targetSliders[i].value = 0;
//    }
//}
//else if(Player2Speed == 0)
//{
//    CountDebuff._instance.EnemyComputeDebuff();
//    Notetext.text="敌方回合";
//    Debug.Log("22222222");
//}

//当出现两个速度相同时的情况
//if (Player1Speed == Player2Speed)
//{
//    int randomn = new System.Random().Next(0, 10);
//    Debug.Log("Random!" + randomn);
//    if (randomn >= 4)
//    {
//        //玩家优先，敌人数值+1
//        Player2Speed += 1;
//    }
//    else
//    {
//        //敌人优先，玩家数值+1
//        Player1Speed += 1;
//    }
//    // Debug.Log("RandomSpeed:"+Player1Speed+"|"+Player2Speed);
//}
////
//if (Player1Speed <= 0 && i == 1)
//{
//    i = -1;
//    CheckedPlayer();
//    // Debug.Log("Speed:"+Player1Speed+"|"+Player2Speed);

//}
//else if (Player2Speed <= 0 && i == 1)
//{
//    i = -1;
//    CheckedPlayer();
//    // Debug.Log("Speed:"+Player1Speed+"|"+Player2Speed); 
//}