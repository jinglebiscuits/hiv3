using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	private List<Person> persons = new List<Person>();
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
		persons.Add (scott);
		focusedPerson = scott;
		transform.GetComponent<PersonView>().Person = focusedPerson;
	}
}
