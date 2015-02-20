using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Manager : MonoBehaviour {

	public static System.Random rand = new System.Random();
	public XML xmlScript;
	public Person person;
	public StoryContainer storyContainer;


	// Use this for initialization
	void Start () {
		person = GameObject.Find("Player").GetComponent<Player>().FocusedPerson;
		person.UpdateAvailableTrunkList(xmlScript.trunks);
		storyContainer.ShowStories();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateTrunks()
	{
		person.UpdateAvailableTrunkList(xmlScript.trunks);
	}
}
