using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	该脚本是用于储存怪物(Attributes类型)的数据
 */
public class EmenyLibrary{

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
		public override double Passivity_skill(double[] i){
			
			int huihe=int.Parse( i[0].ToString());
			if (huihe%2==0)
			{
				Hp+=65;
				Debug.Log("触发了自我修复！");
			}
			return 0.0;
		}
	}

	public  class Enemy4:Attributes{
		public void initdate(){
			Name="敏捷型训练木人";
			//Hp=425
			Hp=42;
			Agi=53;
		}
		public override double Passivity_skill(double[] i){
        Audios._instant.m_Audio.clip = Audios._instant.myMusicArray[0];
        Audios._instant.m_Audio.Play();
        Debug.Log("触发锤一下被动");
			int r = Random.Range(1,40);
			PlayerDate._instance.AttackePlayer(40+r);
			Debug.Log("锤一下造成了"+(40+r)+"点伤害!");
			return 0.0;
		}
	}
	
	public  class Enemy5:Attributes{
		public void initdate(){
			Name="机关训练木人";
			Hp=350;
			Agi=60;
		}
		public override double Passivity_skill(double[] i){
			int r = Random.Range(1,20);
			PlayerDate._instance.AttackePlayer(70+r);
			Debug.Log("弩箭造成了"+(70+r)+"点伤害!");	
			if (0<i[1]&&i[1]<100)
			{
				Debug.Log("触发 故障发生");
			}
			return 0.0;
		}
	}

	public class Enemy6:Attributes{
		public void initdate(){
			Name="损害的大型训练木人";
			Hp=1200;
			Agi=82;
		}
		public override double Passivity_skill(double[] i){

			if (0<i[2]&&i[2]<400)
			{
				Debug.Log("机关训练木人想使用致命重击！");
				int d = Random.Range(1,40);
				double r = Random.Range(0,1);
				if (r+0.65>=1)
				{
					PlayerDate._instance.AttackePlayer(80+d);
					Debug.Log("致命重击造成了"+(80+r)+"点伤害!");

				}else
				{
					Debug.Log("扑空了");
				}
			}else{
				Debug.Log("触发锤一下被动");
				int r = Random.Range(1,40);
				PlayerDate._instance.AttackePlayer(40+r);
				Debug.Log("锤一下造成了"+40+r+"点伤害!");
			}
			if (0<i[1]&&i[1]<100)
			{
				Debug.Log("触发 故障发生");
			}
			return 0.0;
		}
	}




//----------------------------------------
	public class Enemy99:Attributes{
		public void initdate(){
			Name="占位符";
			Hp=1200;
			Agi=82;
		}
	}
	


