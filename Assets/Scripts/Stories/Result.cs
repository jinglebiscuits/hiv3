using UnityEngine;
using System;
using System.Collections.Generic;

public class Result {

	public delegate void MyEventHandler();
	public event MyEventHandler resultEvent;

	private string title;
	private string description;
	private int timeCost;
	private List<Effect> effects;

	#region Constructors
	public Result ()
	{
		this.title = "Result_Title";
		this.description = "Result_Description";
		this.timeCost = 1;
		this.effects = new List<Effect>();
	}

	public Result (string title, string description)
	{
		this.title = title;
		this.description = description;
		this.timeCost = 1;
		this.effects = new List<Effect>();
	}

	public Result (string title, string description, int timeCost)
	{
		this.title = title;
		this.description = description;
		this.timeCost = timeCost;
		this.effects = new List<Effect>();
	}
	#endregion

	#region Accessor Methods
	public string Title {
		get {
			return this.title;
		}
		set {
			title = value;
		}
	}

	public string Description {
		get {
			return this.description;
		}
		set {
			description = value;
		}
	}
		
	public int TimeCost {
		get {
			return this.timeCost;
		}
		set {
			timeCost = value;
		}
	}

	public List<Effect> Effects {
		get {
			return this.effects;
		}
		set {
			effects = value;
		}
	}
	#endregion

	public void EffectPerson(Person person)
	{
		//Let subscribers know
		if(resultEvent != null)
		{
			resultEvent();
		}

		foreach(Effect effect in this.effects)
		{
			IQuality quality = person.QualitiesDict[effect.QualityEffected.Name];
			if(effect.ChangedBy != 169) {
				if(effect.ChangedBy > 0)
					quality.AddPoints((int) effect.ChangedBy);
				else if(effect.ChangedBy < 0)
					quality.RemovePoints(Math.Abs((int) effect.ChangedBy));
			}
			else
			{
				quality.Level = effect.SetTo;
				quality.Points = 0;
			}
		}
		person.Clock.AddPoints(TimeCost);
	}
}
