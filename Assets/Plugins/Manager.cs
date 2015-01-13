using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Manager : MonoBehaviour {

	public Person person;
	public CharacterStatsView characterStatsView;
	public 

	// Use this for initialization
	void Start () {
		characterStatsView.BaseAttributes = GameObject.Find("Player").GetComponent<Player>().FocusedPerson.baseAttributes;
		characterStatsView.ViewConstructor();
		//characterStatsView.BaseAttributes = person.baseAttributes;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddIntPointsToPerson(int points)
	{
		Attribute attribute = person.baseAttributes.intelligence;
		attribute.AddPoints(points);
		print(String.Format("level = {0}    points = {1}",attribute.Level, attribute.Points));
	}
}
