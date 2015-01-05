using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Manager : MonoBehaviour {

	public Person person;
	public CharacterStats characterStats;

	// Use this for initialization
	void Awake () {
		characterStats.BaseAttributes = person.baseAttributes;
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
