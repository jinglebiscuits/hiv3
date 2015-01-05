using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Person : MonoBehaviour {

	public BaseAttributes baseAttributes = new BaseAttributes();
	public Status[] statuses = new Status[8];
	public List<IQuality> qualities = new List<IQuality>();

	public Person()
	{

	}

	public void Update()
	{

	}

	public void AddPointsToAttribute(AttributeType attributeType, int points)
	{
		Attribute attribute;
		switch (attributeType)
		{
		case AttributeType.intelligence:
			attribute = baseAttributes.intelligence;
			break;
		case AttributeType.physical:
			attribute = baseAttributes.physical;
			break;
		case AttributeType.social:
			attribute = baseAttributes.social;
			break;
		case AttributeType.mettle:
			attribute = baseAttributes.social;
			break;
		default:
			attribute = null;
			break;
		}
		if(attribute != null)
			print(String.Format("level = {0}    points = {1}",attribute.Level, attribute.Points));
	}
}

public enum AttributeType
{
	intelligence,
	physical,
	social,
	mettle
};