using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour {
/*
	该脚本主要用于新建敌人Ui
 */
	public GameObject Emeny;
    public List<GameObject> EnemyObj0;

	public void CreatEmeny(int i){
        //EnemyObj0 = new List<GameObject>();

        Debug.Log(i);
		GameObject ii=	Instantiate(Emeny);

		 ii.transform.parent=this.gameObject.transform;

         
		 ii.GetComponent<EmenyScr>().CreatEmeny(i);

        Slider iiSlider = ii.GetComponentInChildren<Slider>();
        CoroutineCountdown.gm.Add(ii);
        DmScr._instance.emenyObj2.Add(ii); //储存敌人
        //CoroutineCountdown.EnemyObj1.Add(ii.GetComponent<GameObject>());
        CoroutineCountdown.iiSlider.Add(iiSlider);//进度条
        iiSlider.value = 0;

	}
}
