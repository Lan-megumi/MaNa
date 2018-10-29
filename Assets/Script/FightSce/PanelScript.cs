using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour {
/*
	该脚本主要用于新建敌人Ui
 */
	public GameObject Emeny;

	public void CreatEmeny(int i){
		Debug.Log(i);
		GameObject ii=	Instantiate(Emeny);

		 ii.transform.parent=this.gameObject.transform;

		 ii.GetComponent<EmenyScr>().CreatEmeny(i);

        Slider iiSlider = ii.GetComponentInChildren<Slider>();
        CoroutineCountdown.gm.Add(ii);
        CoroutineCountdown.iiSlider.Add(iiSlider);
        iiSlider.value = 0;

	}
}
