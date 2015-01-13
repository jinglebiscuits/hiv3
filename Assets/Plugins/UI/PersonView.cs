using UnityEngine;
using System.Collections;

public class PersonView : MonoBehaviour {

	private Person person;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Person Person {
		get {
			return this.person;
		}
		set {
			person = value;
		}
	}
}
