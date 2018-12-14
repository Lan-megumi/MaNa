using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour {
/*
	该脚本主要用于新建敌人(Ui、数据)
 */
	public GameObject Enemy;
    public static PanelScript Instance;
    RectTransform rt;

    public static PanelScript _instance{
        get{
            if (null==Instance)
            {
                Instance=FindObjectOfType(typeof(PanelScript))as PanelScript;
            }
            return Instance;
        }
    }

    //新建一个初始值用于给敌人标记是第几个生成的
    private int EnemeyIndex = 0;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
    }
	public void CreatEmeny(int i){

        GameObject Father_ii= Instantiate(Enemy);

        Father_ii.transform.parent=this.gameObject.transform;
        // Debug.Log("Fathe_ii = "+Father_ii);
        //获取预制体的 敌人子对象，可以从中拿到敌人的数据、debuff控制脚本
        Transform Tran_ii = Father_ii.transform.GetChild(0);
        // Debug.Log("Trans ii = "+Tran_ii.name);
        GameObject ii=Tran_ii.gameObject;
        // Debug.Log("GameO ii = "+ii);
        Slider iiSlider = ii.GetComponentInChildren<Slider>();
        ii.GetComponent<EmenyScr>().EnemyIndex = EnemeyIndex;
        ii.GetComponent<EmenyScr>().NewEmeny(i);
        
        if (ii.GetComponent<EmenyScr>().Re_Name()=="占位符")
        {
            CoroutineCountdown.gm.Add(null);
            DmScr._instance.enemyObj2.Add(null); 
            CoroutineCountdown.iiSlider.Add(null);
            ii.gameObject.SetActive(false);
        }else
        {
            // Debug.Log("Obj_after:"+Father_ii.transform.position);
            // Debug.Log("EnemyIndex:"+EnemeyIndex);
            Tran_ii.GetComponent<RectTransform>().anchoredPosition+=new Vector2(70*EnemeyIndex,0);

            // rt.anchoredPosition+=new Vector2(55*EnemeyIndex,0);
            // Debug.Log("rt:"+rt.anchoredPosition);

            // Debug.Log("Obj_before:"+Father_ii.transform.position);


            CoroutineCountdown.gm.Add(ii);
            DmScr._instance.enemyObj2.Add(ii); //储存敌人
            //CoroutineCountdown.EnemyObj1.Add(ii.GetComponent<GameObject>());
            CoroutineCountdown.iiSlider.Add(iiSlider);//进度条
        }
      
        
        iiSlider.value = 0;
        EnemeyIndex++;

    }
}
