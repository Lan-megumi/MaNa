using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	}
}
