using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour {
/*
	该脚本主要用于新建敌人Ui
 */
	public GameObject Emeny;
    public static PanelScript Instance;

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

	public void CreatEmeny(int i){

        //Debug.Log(i);
		GameObject ii=	Instantiate(Emeny);

		 ii.transform.parent=this.gameObject.transform;

        Slider iiSlider = ii.GetComponentInChildren<Slider>();
        ii.GetComponent<EmenyScr>().EnemyIndex = EnemeyIndex;
        ii.GetComponent<EmenyScr>().NewEmeny(i);

        CoroutineCountdown.gm.Add(ii);
        DmScr._instance.enemyObj2.Add(ii); //储存敌人
        //CoroutineCountdown.EnemyObj1.Add(ii.GetComponent<GameObject>());
        CoroutineCountdown.iiSlider.Add(iiSlider);//进度条
        DmScr._instance.SetDate();
        iiSlider.value = 0;
        EnemeyIndex++;

    }
}
