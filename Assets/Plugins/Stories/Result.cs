using System.Collections;
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
			FindMatchingQuality(person.Qualities, effect.QualityEffected).AddPoints(effect.ChangedBy);
		}
		person.Clock.AddPoints(TimeCost);
	}

	private IQuality FindMatchingQuality(List<IQuality> qualities, IQuality qualityToMatch) //duplicate code. needs cleaning
	{
		foreach(IQuality quality in qualities)
		{
			if(quality.Name == qualityToMatch.Name)
			{
				return quality;
			}
		}
		return null;
	}
}
