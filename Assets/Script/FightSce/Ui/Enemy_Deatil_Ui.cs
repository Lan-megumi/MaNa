using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///	该脚本用于控制敌人Deatil的血条显示以及Debuff显示
///</summary>
public class Enemy_Deatil_Ui : MonoBehaviour {
	public static Enemy_Deatil_Ui Instance;

    public static Enemy_Deatil_Ui _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(Enemy_Deatil_Ui))as Enemy_Deatil_Ui;
            }
            return Instance;
        }
    }
//------------------------------------------
	public Slider EnemyHp;
	public Image EnemyPortrait;


	///<summary>
    /// Enemy血条显示
    ///</summary>
	public void ShowHpDeatil(int MaxHp,int hp){
		double i = (double)hp/(double)MaxHp;
        i=System.Math.Round(i,4);
        Debug.Log("i:"+i+"  Hp:"+hp+"/MaxHp:"+MaxHp);
        EnemyHp.value=(float)i;
	}
	///<summary>
	///	查找敌人Date的Debuff接口
	///</summary>
	public void ShowDebuffUi(int[] n){
		bool IceAche=false,Fire=false,Dizzy=false,Fear=false;
		bool[] d={IceAche,Fire,Dizzy,Fear};
		int[] d_num={0,0,0,0};
		string d_name="";
		//首先先将上次生成的DebuffObj清空掉
		EnemyDeatil_Debuff_Panel._instance.InitScr();
		//开始处理数据
		for (int i = 0; i < n.Length; i++)
		{
			if(n[i]!=0){
				d[i]=true;
				d_num[i]=n[i];
				switch (i)
				{
					case 0:
						d_name="Ice";
						break;
					case 1:
						d_name="Fire";
						break;
					case 2:
						d_name="Dizzy";
						break;
					case 3:
						d_name="Fear";
						break;
					default:
						Debug.Log("来自Enemy_Deatil_Ui的报告：生成Debuff实例时出现了超出索引或空值的情况");
						break;
				}
				Debug.Log("执行生成了 "+d_name+" 的Debuff，层数是 "+d_num[i]);
				//调用 Deatil_Debuff_Panel 部分脚本内容
				EnemyDeatil_Debuff_Panel._instance.CreatEnemyDebuff(d_num[i],d_name);
			}
		}


		
	}
	
}
