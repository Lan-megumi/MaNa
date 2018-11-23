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
    public static CoroutineCountdown Instance;

    public static CoroutineCountdown _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(CoroutineCountdown))as CoroutineCountdown;
            }
            return Instance;
        }
    }

    public Text Notetext;
/*
    IfPlayer：用于记录是否为玩家回合，目前暂未有引用
    IfFirst:用于记录是否是第一个回合，避免第一个回合就将牌组洗了
 */
    public bool IfPlayer,IfFirst;

//---------------------------

    private int igg = 1;    //初始条件

//用于接收Player1的速度
    private float Player1Speed=60;
//用于接收Player2的速度
    
    private float c;
    private int Round= 0;
//---------------------------

//滑动条
    public Slider targetSliderOject;
    public static List<GameObject> gm;
    public static List<Slider> iiSlider;

    private GameObject Emeny;
    public float[] Agis; //速度 的数组
    public float[] SpeedAgis;//每帧速度 数组
    public float[] AgisMax;//速度最大值   50  150  数组 
    public int[] RoundNum; //每个敌人自己的 回合 数组
    public double[] i;    //i和RoundNum是一样的int-》double
    public int[] EnemyHp;//敌人血量数组
    public int[] PlayerHp;//储存玩家血量
    //---------------------------------

    private void Awake()
    {
        // gm = new List<GameObject>();
        // iiSlider = new List<Slider>();

        c = 1/Player1Speed;    //玩家每帧的速度
        Debug.Log("cc" + c);
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gm = new List<GameObject>();
        iiSlider = new List<Slider>(); //储存滑动条
    }
    
    /// <summary>
    /// 速度和速度平均值的 数组
    /// </summary>
    public void Agiss( )
    {
        //定义数组长度
        AgisMax = new float[gm.Count];              //速度最大值数组
        Agis = new float[gm.Count];                 //速度数组
        SpeedAgis = new float[gm.Count];            // 1/速度

        RoundNum = new int[gm.Count];               //敌人回合
        i = new double[gm.Count];                   //与RoundNum相等  
        EnemyHp = new int[gm.Count];                //敌人血量
        PlayerHp = new int[1];                      //玩家自己的血量

        for (int g = 0; g < gm.Count; g++)
        {
            float avg = gm[g].GetComponent<EmenyScr>().Agi;//获取速度
            RoundNum[g] = 0; //初始每个敌人自己的回合都是0
            int enemyhp = gm[g].GetComponent<EmenyScr>().EnemyHp;//获取敌人Hp
            PlayerHp[0]= PlayerDate._instance.Hp;               //玩家血量
            Debug.Log("玩家血量："+ PlayerHp[0]);
            Debug.Log("敌人回合数："+Round);
            Debug.Log("敌人速度:" + avg);
            AgisMax[g] = avg;               //速度最大值
            Agis[g] = avg;                  //储存速度
            EnemyHp[g] = enemyhp;           //储存敌人血量

            Debug.Log(EnemyHp[g]);
            //Agiss(avg);
            SpeedAgis[g] = 1/avg;           //敌人每帧的速度
            Debug.Log(SpeedAgis[g]+"平均");
        }
        
    }

    /// <summary>
    /// 洗牌
    /// </summary>
   public void NextTrun(){                
        
        if (igg == -1 & Player1Speed == 0)
        {
            igg = 1;
            Player1Speed = 60;                  //速度恢复最大值
        }
        for(int g=0; g <Agis.Length; g++)
        {
            if (igg == -1 & Agis[g] <= 0)
            {
                igg = 1;
                Agis[g]=AgisMax[g] ;               //速度变回最大值
                //Debug.Log(Agis[g] + ":" + AgisMax[g]);
                Debug.Log( "io:" + igg);
            }
        }
   }
    void  Update()
    {

        CoroutineCountDown(); //出手判断
    }

    /// <summary>
    /// 出手判断
    /// </summary>
    public void CoroutineCountDown()
    {
        // Debug.Log("第II:" + this.igg);
        if (StartGame._instance.Startbool == true)  //点击游戏开始
        {

            // Debug.Log("II:" + this.igg);
            if (igg == 1)
            {
                GameControoler._instance.SetCardUi(true);

                Player1Speed--;

                 /*
                    敌人们速度 --，只有到速度为0的时候才进入if条件执行的方法里
                 */
                for (int g = 0; g < Agis.Length; g++)  
               
                {
                    Agis[g]--;
                    iiSlider[g].value += SpeedAgis[g];              //每帧进度条增加
                    if (Mathf.Abs(iiSlider[g].value - 1) <= 0.01f)  //当进度条的绝对值-1 小于等于0.01的时候（进度条满）
                    {
                        //敌人 回合开始
                        iiSlider[g].value = 0;
                        RoundNum[g] += 1;                           //回合加1
                        
                        i[0]=RoundNum[g];
                        i[1]=PlayerDate.Instance.ReturnHp();
                        i[2]=gm[g].GetComponent<EmenyScr>().Re_hp();


                        // Debug.Log("血量 " + EnemyHp[g]);
                        // Debug.Log("敌人i回合数" + i[g]);
                        // Debug.Log("敌人g回合数" + RoundNum[g]);

                        gm[g].GetComponent<EmenyScr>().enemyAi[0].Passivity_skill(i);
                        gm[g].GetComponent<CountDebuff>().EnemyComputeDebuff();

                    }
                }

                targetSliderOject.value += c;               //玩家每帧数速度
                if (Mathf.Abs(targetSliderOject.value - 1) <= 0.01f)
                {

                    //玩家 回合开始
                    targetSliderOject.value = 0;
                    // TestMananger._instance.VisableCard();
                }
                for (int g = 0; g < Agis.Length; g++)
                {
                    if (Player1Speed == Agis[g])            //若玩家跟敌人速度相等的话
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
                if (Player1Speed <= 0 && igg == 1)   //当玩家速度为0
                {
                    igg = -1;
                    // Debug.Log("jkhg手打");
                    CheckedPlayer();
                }
                for (int g = 0; g < Agis.Length; g++)   //遍历速度
                {
                    if (Agis[g] <= 0 && igg == 1)        //若速度等于或小于0，检查谁的回合
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
    
    //  检查player，文字显示谁的回合
    public void CheckedPlayer(){
        if (Player1Speed==0)
        {
            Notetext.text="你的回合";
            // Debug.Log("111111");
            IfPlayer=true;
            if (IfFirst!=true)
            {
                GameControoler._instance.SetCardUi(false);
                TestMananger._instance.VisableCard();
                
            }else
            {
                IfFirst=false;
            }
        }
         
        for (int g = 0; g < Agis.Length; g++)           //遍历
        {
            if (Agis[g] == 0)
            {
                Notetext.text="敌方回合";
                IfPlayer=false;

                // Debug.Log("333333");
            }
        }
    }

/*
    晕眩效果逻辑方法
 */
    public void Function_Dizzy(string Who){
        
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