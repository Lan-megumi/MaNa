    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmScr : MonoBehaviour
{
    public static DmScr Instance;
    //用于临时储存删除第几个敌人的下标
    int linshii;
    public static DmScr _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(DmScr))as DmScr;
            }
            return Instance;
        }
    }
    ///<summary>
    /// 动态数组，用于储存其他脚本动态加入的敌人对象
    ///</summary>
    public List<GameObject> enemyObj2;
    ///<summary>
    /// 静态数组，在动态数组加载完成后赋值用于储存计算的数组
    ///</summary>
    public GameObject[] enemyObj3;   
    public float[] Hp;

    // Use this for initialization
    void Awake()
    {
        Debug.Log("Awake");
        enemyObj2 = new List<GameObject>();
        enemyObj3 = new GameObject[3];
        

    }
    ///<summary>
    /// List数组传复制给 []数组
    ///</summary>
    public void SetDate()
    {
        for (int i = 0; i < enemyObj2.Count; i++)
            {
                enemyObj3[i]=enemyObj2[i];
            }
}
    //点击，全体减血 （true，100）
    public void Dm(int num)
    {
        Debug.Log("群体伤害:" + num);
        for (int g = 0; g < 3; g++)
        {
            if(enemyObj3[g]!=null){
                enemyObj3[g].GetComponent<EmenyScr>().CountDamaged(true, num);
            }
            
        }
    }
///<summary>
/// 溅射伤害代码,根据点击事件所传回的 index传入方法中的 z 值中来判断溅射哪些对象
///</summary>
    public void CountRelated(int n, int z)
    {
        Debug.Log("溅射伤害：坐标 "+z+" 伤害 "+n);
    //选择一号位敌人
        if (z == 0)
        {
            for(int i=0;i<2;i++){
                // Debug.Log("Test1-"+i+" :"+enemyObj3[i]);

                if(enemyObj3[i]!=null){
                    enemyObj3[i].GetComponent<EmenyScr>().CountDamaged(true, n);
                }
            }
        }
    //选择中间的时候有分三个敌人和两个敌人的情况
        else if (z == 1)
        {
            for(int i=0;i<3;i++){
                if(enemyObj3[i]!=null){
                    enemyObj3[i].GetComponent<EmenyScr>().CountDamaged(true, n);
                }
            }
        }
    //选择三号位的敌人
        else if (z == 2)
        {
            for(int i=1;i<3;i++){
                if(enemyObj3[i]!=null){
                    enemyObj3[i].GetComponent<EmenyScr>().CountDamaged(true, n);
                }
            }
        }
    }
    ///<summary>
    ///该方法用于返回敌人数量
    ///</summary>
    public int Re_EnemyNum(){
        int R=0;
        for(int i =0;i<enemyObj3.Length;i++){
            if(enemyObj3[i]!=null){
                R=R+1;
            }
        }
        return R;
    }
    ///<summary>
    ///该方法相当于转接器，
    ///用于删除游戏中各个脚本下的敌人数组数据,传入参数 int i(0,1..) 为删除第几个敌人
    ///</summary>
    public void Update_EnemyNum(int i){
        Debug.Log("第"+i+"个敌人阵亡！");
        // PanelScript._instance.EnemyObj0[i]=null;
        this.GetComponent<CoroutineCountdown>().Update_EnemyNum(i);
        linshii=i;
       

    }
    public void DestoryEnemy(){
        Destroy(enemyObj3[linshii].gameObject);
        enemyObj3[linshii]=null;
        //执行GameController脚本中的检查敌人数量
        GameControoler._instance.CheckEnemy();
    }
    ///<summary>
    /// 返回敌人在DmScr下的数组
    ///</summary>
    public GameObject[] Re_EnemyObj3(){
        return enemyObj3;
    }
}
