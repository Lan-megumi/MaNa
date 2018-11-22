using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	该脚本是用于储存怪物(Attributes类型)的数据
 */
public class EmenyLibrary{
	public static EmenyLibrary _instance;
	void Awake(){
		_instance=this;
	}
/*
	调用方法时注意先执行类下的 initdate() 填充数据
 */
	public class Emeny1:Attributes{
		public void initdate(){
			Name="木质傀儡";
			Hp=1500;
			Mana=0;
			Rgs=0;
            Agi = 80;
			Imm=15;
			Avd=2;
		}
		
	}
	public class Emeny2: Attributes {
		public void initdate(){
			Name="钢铁傀儡";
			Hp=30000;
			Mana=0;
			Rgs=0;
			Agi=150;
			Imm=15;
			Avd=2;
		}
	}
	public  class Enemy3:Attributes{
		public void initdate(){
			Name="厚重型训练木人";
			Hp=600;
			Agi=78;
		}
		public override double Passivity_skill(int huihe){
			if (huihe%2==0)
			{
				Hp+=65;
				Debug.Log("触发了自我修复！");
			}
			return 0.0;
		}
	}
	
}
