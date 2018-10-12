using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyLibrary : Attributes {
	public static EmenyLibrary _instance;
	void Awake(){
		_instance=this;
	}

	public void Emeny1(){
		Hp=1500;
		Mana=0;
		Rgs=0;
		Agi=50;
		Imm=15;
		Avd=2;
	}
}
