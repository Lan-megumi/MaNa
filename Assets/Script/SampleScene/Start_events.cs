using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_events : MonoBehaviour {

	// Use this for initialization
	GameObject gb;//初始化 物体
	public InputField Account,pass,Account_for,pass_for;
	
	void Start () {
		Screen.SetResolution(1280, 720, false);				//固定分辨率为1280*720窗口化

		New_Save_window.SetActive(false);					//设置新建账户为不可见
		Load_Save_window.SetActive(false);					//设置登录账号为不可见

		gb = GameObject.Find("load_save");					//找到一个名为 的按钮
		gb.active = true;									//初始化该按钮为活跃状态
		if(!File.Exists(Application.dataPath+"/saves"+"/save1.save")){
															//如果saves路径下没有一个称谓save1\
			gb.active = false;								//该按钮处于不活跃状态
			//gb.SetActive(false);							//这行代码是备用的，不显示该按钮
			Debug.Log("找不到存档");
			if(!Directory.Exists(Application.dataPath+"/saves")){
															//检查是否存在一个名为saves的文件夹
				Debug.Log("未找到文件夹saves");
				Directory.CreateDirectory(Application.dataPath+"/saves");
															//如果不存在，则创建一个
				Debug.Log("已创建文件夹saves");
			}
		}else{
			Debug.Log("找到存档");
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	private SAVE_GS New_Save(){								//定义一个存档方法
		SAVE_GS save_pub = new SAVE_GS();
		save_pub.Y_or_N=0;
		return save_pub;
	}

	public GameObject New_Save_window ;
	public GameObject Load_Save_window ;

	private int nob_i,nob_i2;

	public void NewTheSave(){								//存档按钮
		New_Save_window.SetActive(true);					//弹出新建账号框

		int i = 1;											//设定一个存档编号的参数
		for(int tabe=0;tabe==0;){							//计算该存档的编号
			if(File.Exists(Application.dataPath+"/saves"+"/save"+i+".save")){
				i++;
			}else{
				tabe=1;
			}
		}
		nob_i2=nob_i=i-1;
		Debug.Log("已建立"+(i-1)+"个存档");
		Debug.Log("即将建立第"+i+"个存档");
	}

	public void At_new(){									//新建账户窗口里的确定按钮
		string Account_text=Account.text,pass_text=pass.text;
															//将文本框的内容导入

		if(Account_text==""||Account_text=="null"||pass_text==""||pass_text=="null"){
			Account.text="";
			pass.text="";
			TipsTextScript._instance.ChangeTips("不能输入空的账号或密码");
															//检测是否出现空输入存在
		}else{
			int LinShi_4=0;									//用于判断是否有账号重复
			for(int i=nob_i;i>0;i--){
				BinaryFormatter bf_2 = new BinaryFormatter();
															//打开数据流
				FileStream LinShi_2=File.Open(Application.dataPath+"/saves" + "/save" + i + ".save",FileMode.Open);
				SAVE_GS LinShi_3 = (SAVE_GS)bf_2.Deserialize(LinShi_2);
				if(LinShi_3.Account == Account_text){
					i=0;
					Account.text="";
					pass.text="";
					LinShi_4=1;
					TipsTextScript._instance.ChangeTips("账号已存在，请重新输入");
					
				}
				LinShi_2.Close();							//关闭数据流
			}
			if(LinShi_4==0){								//如果没有重复的账号则创建一个新的账号
				SAVE_GS save_new = new SAVE_GS();			//编写存档内容
				save_new.Y_or_N=0;
				save_new.Account=Account_text;
				save_new.Password=pass_text;
				save_new.NomberD=nob_i+1;
				BinaryFormatter bf = new BinaryFormatter();	//打开数据流
				FileStream LinShi_1 = File.Create(Application.dataPath + "/saves" + "/save" + (nob_i+1) + ".save");
															//创建存档文件
				bf.Serialize(LinShi_1,save_new);			//将save_new里的数据存入LinShi_1
				LinShi_1.Close();							//关闭数据流
				FileStream LinShi_5 = File.Create(Application.dataPath + "/saves" + "/load.save");
															//建立一个用于新场景的读取文件
				bf.Serialize(LinShi_5,save_new);			//将save_new里的数据存入LinShi_5
				LinShi_5.Close();							//关闭数据流
				Debug.Log("创建完成");
				SceneManager.LoadScene("Main_interface",LoadSceneMode.Single);
															//转换场景
				Debug.Log("检查是否继续运行");
				nob_i=0;
				Account.text="";
				pass.text="";
				New_Save_window.SetActive(false);			//还原数据
			}else{
				LinShi_4=0;
			}
			
		}

		
	}

	public void back_new(){									//新建账户窗口里的返回按钮
		TipsTextScript._instance.StopTips();
		nob_i=0;
		Account.text="";
		pass.text="";
		New_Save_window.SetActive(false);					//还原数据
	}

	public void LoadTheSave(){								//打开登录窗口
		Load_Save_window.SetActive(true);
	}

	public void At_Load(){									//登录窗口里的登录按钮
	Debug.Log("At_Load");
		int LinShi_2=0;

		for(int i=2,LinShi_1=0;LinShi_1==0;i++){			//用于判断有多少个存档文件
			if(!File.Exists(Application.dataPath+"/saves"+"/save"+i+".save")){
				LinShi_2=i-1;
				LinShi_1=1;
				Debug.Log("共拥有"+LinShi_2+"个存档");
			}
		}

		string Account_text=Account_for.text,pass_text=pass_for.text;
		if(Account_text==""||Account_text=="null"||pass_text==""||pass_text=="null"){
															//判断是否有空输入框
			Account_for.text="";
			pass_for.text="";								//清空文字输入框
			TipsTextScript._instance.ChangeTips("请不要填写空的账号或密码");
			
		}else{
			int LinShi_1=0;
			for(int i=LinShi_2;i>0;i--){					//循环检查符合的账号
				BinaryFormatter bf = new BinaryFormatter();	//打开数据流
				FileStream LinShi_3 = File.Open(Application.dataPath+"/saves"+"/save"+i+".save",FileMode.Open);
				SAVE_GS LinShi_4 = (SAVE_GS) bf.Deserialize(LinShi_3);
				LinShi_3.Close();							//关闭存档文件的数据流
				Debug.Log("第"+i+"个存档账号密码为："+LinShi_4.Account+"&"+LinShi_4.Password);
				Debug.Log("获取到的输入值为："+Account_text+"&"+pass_text);
				if(LinShi_4.Account==Account_text&&LinShi_4.Password==pass_text){
					LinShi_1=i;
					Debug.Log("正在登入");
					FileStream LinShi_5 = File.Create(Application.dataPath+"/saves"+"/load.save");
					bf.Serialize(LinShi_5,LinShi_4);		//将LinShi_4里的数据存入LinShi_5
					LinShi_5.Close();						//关闭load.save的数据流
					SceneManager.LoadScene("Main_interface",LoadSceneMode.Single);
															//转换场景
				}
			}
			if(LinShi_1==0){
				
				TipsTextScript._instance.ChangeTips("密码或账号输入有误");

			}

			Account_for.text="";
			pass_for.text="";								//清空文字输入框
		}
	}

	public void back_load(){								//登录窗口里的返回按钮
		TipsTextScript._instance.StopTips();
		Account_for.text="";
		pass_for.text="";									//清空文字输入框
		Load_Save_window.SetActive(false);
	}
}
