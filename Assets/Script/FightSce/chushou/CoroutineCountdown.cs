using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///    该脚本功能:实现根据角色速度影响操作回合;
///分别表示玩家和敌人的回合
///</summary>
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
//---------------------------

    public Text Notetext;
/*
    IfPlayer：用于记录是否为玩家回合，目前暂未有引用
    IfFirst:用于记录是否是第一个回合，避免第一个回合就将牌组洗了
 */
    public bool IfPlayer,IfFirst;

//---------------------------
    ///<summary>
    /// 控制
    ///</summary>
    private int igg = 1;    //CoroutineCountDown()进程在update里动，若igg=-1,CoroutineCountDown()不在继续，达成NextTrue()条件之一，可以回合结束


    private float Player1Speed=60;//用于接收Player1的速度
    //新加的背景和帮手（264-280行）检测里没有加NextTrue（），不会主动结束回合
    private float BackgroundSpeed=150;//场景速度
    private float HelperSpeed=0;//帮手速度
    private float HelperSpeedMax;
    private float c;//玩家的每帧速度

    private int Round= 0;

//滑动条
    public Slider PlayerSliderOject;  //玩家
 
//---------------------------
     /// <summary>
    /// 用于接收生成的敌人实例化数组
    ///</summary>
    public static List<GameObject> gm;
    
    ///<summary>
    /// 用于储存敌人滑动条的数组
    ///</summary>
    public static List<Slider> iiSlider;

    private GameObject Emeny;
    public float[] Agis; //敌人速度 的数组
    public float[] SpeedAgis;//每帧速度 数组
    public float[] AgisMax;//速度最大值   50  150  数组 
    public int[] RoundNum; //每个敌人自己的 回合 数组

    /// <summary>
    /// 用于给敌人Ai传值的数组
    ///</summary>
    public double[] i; 
    public int[] EnemyHp;//敌人血量数组
    // public int[] PlayerHp;//储存玩家血量
    //---------------------------------

    void Awake()
    {
        c = 1/Player1Speed;    //玩家每帧的速度
        Debug.Log("玩家每帧速度：" + c);
        gm = new List<GameObject>();   //储存敌人
        iiSlider = new List<Slider>(); //储存滑动条
        Helper_Speed(ref HelperSpeed);//帮手的传值  不知道要传啥
        Debug.Log("helpSpeed0000" + HelperSpeed);
    }
   
    
    /// <summary>
    /// 给诸多数组赋值的方法
    /// </summary>
    public void Agiss( )
    {
        //定义数组长度，gm.Count为在场的敌人数量
        AgisMax = new float[gm.Count];              //速度最大值数组
        Agis = new float[gm.Count];                 //速度数组
        SpeedAgis = new float[gm.Count];            // 1/速度

        RoundNum = new int[gm.Count];               //敌人回合
        EnemyHp = new int[gm.Count];                //敌人血量


        i = new double[10];                                     
        //给敌人数组赋值
        for (int g = 0; g < gm.Count; g++)
        {
            if (gm[g]==null)
            {
                Agis[g]=99999999;
                AgisMax[g]=99999999;

            }else
            {
                float avg = gm[g].GetComponent<EmenyScr>().Agi;//获取速度
                RoundNum[g] = 0; //初始每个敌人自己的回合都是0
                int enemyhp = gm[g].GetComponent<EmenyScr>().EnemyHp;//获取敌人Hp
                // PlayerHp[0]= PlayerDate._instance.Hp;               //玩家血量
                // Debug.Log("玩家血量："+ PlayerHp[0]);
                Debug.Log(i+"敌人回合数："+Round);
                Debug.Log(i+"敌人速度:" + avg);
                AgisMax[g] = avg;               //速度最大值
                Agis[g] = avg;                  //储存速度
                EnemyHp[g] = enemyhp;           //储存敌人血量

                // Debug.Log(EnemyHp[g]);
                //Agiss(avg);
                SpeedAgis[g] = 1/avg;           //敌人每帧的速度
            }
           
            // Debug.Log(SpeedAgis[g]+"平均");
        }
        
    }

    /// <summary>
    /// 下一回合
    /// </summary>
   public void NextTrun(){
//某个速度为0时，则igg会=-1，
        //玩家
        //Debug.Log("N_igg="+igg);
        // Debug.Log("HelperSpeed" + HelperSpeed);

        //速度恢复最大值
        if (igg == -1 & Player1Speed == 0)
        {
            igg = 1;
            Player1Speed = 60;                  //速度恢复最大值
        }
        //帮手
        if(igg==-1&&HelperSpeed<=0){
            igg = 1;
            HelperSpeed = HelperSpeedMax;
        }
        //背景
        if(igg==-1&BackgroundSpeed<=0){
            igg=1;
            BackgroundSpeed=150;
        }
        //敌人
        for(int g=0; g <Agis.Length; g++)
        {
            if (igg == -1 & Agis[g] <= 0)
            {
                //Debug.Log("执行了NextTrun方法");

                igg = 1;
                Agis[g]=AgisMax[g] ;               //速度变回最大值
                //Debug.Log(Agis[g] + ":" + AgisMax[g]);
                // Debug.Log( "io:" + igg);
            }
        }
        
        Enemy_Deatil_Ui._instance.Update_Deatil_Ui();
   }
    void  Update()
    {

        CoroutineCountDown();
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
                BackgroundSpeed--;
                HelperSpeed--;
                 /*
                    敌人们速度 --，只有到速度为0的时候才进入if条件执行的方法里
                 */
                for (int g = 0; g < Agis.Length; g++)  
                {
                    if (gm[g]!=null)
                    {
                         Agis[g]--;
                        iiSlider[g].value += SpeedAgis[g];              //每帧进度条增加
                        if (Mathf.Abs(iiSlider[g].value - 1) <= 0.01f)  //当进度条的绝对值-1 小于等于0.01的时候（进度条满）
                        {
                            //敌人 回合开始
                            iiSlider[g].value = 0;
                            RoundNum[g] += 1;                           //回合加1
                            
                            i[0]=RoundNum[g];
                            Debug.Log("PlayerHp"+PlayerDate._instance.ReturnHp());
                            i[1]=PlayerDate._instance.ReturnHp();
                            i[2]=gm[g].GetComponent<EmenyScr>().Re_hp();


                            // Debug.Log("血量 " + EnemyHp[g]);
                            // Debug.Log("敌人i回合数" + i[g]);
                            // Debug.Log("敌人g回合数" + RoundNum[g]);
                            
                        
                            gm[g].GetComponent<EmenyScr>().enemyAi[0].Passivity_skill(i);
                            gm[g].GetComponent<CountDebuff>().EnemyComputeDebuff();
                            //执行完操作后进入下一回合
                        
                        }
                    }
                   
                }

                PlayerSliderOject.value += c;               //玩家每帧数速度
                if (Mathf.Abs(PlayerSliderOject.value - 1) <= 0.01f)
                {

                    //玩家 回合开始
                    PlayerSliderOject.value = 0;
                    // TestMananger._instance.VisableCard();
                }

                //若速度相等处理
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
                if (HelperSpeed <= 0 && igg == 1)
                {
                    igg = -1;
                    CheckedPlayer();
                    NextTrun(); 
                }
                if (BackgroundSpeed <= 0 && igg == 1)   //当背景速度为0
                {
                    igg = -1;     
                    // Debug.Log("jkhg手打");
                    CheckedPlayer();
                    NextTrun(); 
                }
                for (int g = 0; g < Agis.Length; g++)   //遍历速度
                {
                    if (Agis[g] <= 0 && igg == 1)        //若速度等于或小于0，检查谁的回合
                    {
                         //Debug.Log("创建的回合");
                        igg = -1;
                        CheckedPlayer();
                        //Debug.Log("igg"+igg); 
                        NextTrun();        //结束回合
                        // Debug.Log("创建的回合2");
                        // Debug.Log("创建的回合3" + igg);
                    }
                }
            }
        }
    }
    
    ///<summary>
    /// CheckedPlayer
    /// 目前只用于修改Ui
    ///</summary>
    public void CheckedPlayer(){
        if (Player1Speed==0)   //玩家回合
        {
            Notetext.text="你的回合";
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
         
        for (int g = 0; g < Agis.Length; g++)           //敌人回合
        {
            if (Agis[g] == 0)
            {
                Notetext.text="敌方回合";
                IfPlayer=false;
            }
        }

        if(BackgroundSpeed==0)      //背景回合
        {
            //场景
            GroundLib d = GroundScr._instance.groundLib;
            double [] s= d.ReckonRule3();
            Debug.Log("来自收脚本的信息：背景回合取得的数组第一位为 "+s[0]);
            if(s[0]!=0){
                //进入结算的方法
                PulicObjScr._instance.GroundRule3(s);
                
            }
        }
        if(HelperSpeed==0)  //帮手回合
        {
            Notetext.text = "帮手回合";
        }
    }
    ///<summary>
    /// 滑动条控制脚本中的清除敌人数据方法，传入参数int i(0,1..) ;
    ///</sumarry>
    public void Update_EnemyNum(int i){
        gm[i]=null;
        iiSlider[i]=null;
        
    }
    public void Helper_Speed(ref float i)
    {
        HelperSpeed = i+80;
        HelperSpeedMax = HelperSpeed;
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