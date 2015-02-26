using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	private Person focusedPerson;

	// Use this for initialization
	void Awake ()
	{
		DefaultSetup();
	}

	public Person FocusedPerson {
		get {
			return this.focusedPerson;
		}
		set {
			focusedPerson = value;
		}
	}

	public void DefaultSetup()
	{
		Person scott = new Person();
		focusedPerson = scott;
	}
}
