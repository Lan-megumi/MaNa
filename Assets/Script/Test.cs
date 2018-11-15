
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

public class Test:MonoBehaviour{
	public void aa(){
		object a = Activator.CreateInstance(System.Type.GetType("A"));
		object b = Activator.CreateInstance(System.Type.GetType("B"),new object[]{"Hello"});
		object c = Activator.CreateInstance(System.Type.GetType("C"), new object[] { "Name", "Value" });
		Debug.Log(b);
	}
}
    class A
    {
        public A(){Debug.Log("Creating A");}
    }
    class B
    {
        public B(string msg) {Debug.Log("Creating B with "+msg);}
    }
 
    class C
    {
        public C(string name, string value){Debug.Log("Creating C at"+name+":"+value);}
    }
 


