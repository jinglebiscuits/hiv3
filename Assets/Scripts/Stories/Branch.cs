using System.Collections.Generic;
using System.Collections;
using System;

/// <summary>
/// A Branch represents a possible path from a Trunk. Branches need unique names within their story trees.
/// </summary>
public class Branch : Story{
	
	private Result defaultResult;
	private Result successResult;
	private List<IQuality> testedQualities;
	private int difficulty;
	private float chanceOfSuccess;
	private Result chosenResult;
	private Story linkedEvent;

	#region Contructors
	public Branch ()
		:base()
	{
		this.title = "branch_title";
		this.description = "branch_description";
		this.icon = "branch_icon";
		this.buttonText = "Go";
		this.requirements = new List<Requirement>();
		this.defaultResult = new Result();
		this.successResult = null;
		this.testedQualities = new List<IQuality>();
		this.chosenResult = null;
		this.linkedEvent = new Story();
	}

	public Branch (string title, string description, string icon, string buttonText, List<Requirement> requirements, Result defaultResult)
		:base(title, description, icon, buttonText, requirements)
	{
		this.defaultResult = defaultResult;
		this.successResult = null;
		this.testedQualities = new List<IQuality>();
		this.chosenResult = null;
		this.linkedEvent = null;
	}

	public Branch (string title, string description, string icon, string buttonText, List<Requirement> requirements,
	               Result defaultResult, Result successResult, List<IQuality> testedQualities, int difficulty)
		:base(title, description, icon, buttonText, requirements)
	{
		this.defaultResult = defaultResult;
		this.successResult = successResult;
		this.testedQualities = testedQualities;
		this.difficulty = difficulty;
		this.chosenResult = null;
		this.linkedEvent = null;
	}

	public Branch (string title, string description, string icon, string buttonText, List<Requirement> requirements,
	               Result defaultResult, Result successResult, List<IQuality> testedQualities, int difficulty, Story linkedEvent)
		:base(title, description, icon, buttonText, requirements)
	{
		this.defaultResult = defaultResult;
		this.successResult = successResult;
		this.testedQualities = testedQualities;
		this.difficulty = difficulty;
		this.chosenResult = null;
		this.linkedEvent = linkedEvent;
	}
	#endregion

	#region Accessor Methods
	public Result DefaultResult {
		get {
			return this.defaultResult;
		}
		set {
			defaultResult = value;
		}
	}

	public Result SuccessResult {
		get {
			return this.successResult;
		}
		set {
			successResult = value;
		}
	}

	public List<IQuality> TestedQualities {
		get {
			return this.testedQualities;
		}
		set {
			testedQualities = value;
		}
	}

	public int Difficulty {
		get {
			return this.difficulty;
		}
		set {
			difficulty = value;
		}
	}
	
	public float ChanceOfSuccess {
		get {
			return this.chanceOfSuccess;
		}
		set {
			chanceOfSuccess = value;
		}
	}

	public Result ChosenResult {
		get {
			return this.chosenResult;
		}
		set {
			chosenResult = value;
		}
	}

	public Story LinkedEvent {
		get {
			return this.linkedEvent;
		}
		set {
			linkedEvent = value;
		}
	}
	#endregion

	public void CalculateChanceOfSuccess(Person person)
	{
		int qualityLevelSum = 0;
		foreach(IQuality quality in TestedQualities)
		{
			qualityLevelSum += FindMatchingQuality(person.Qualities, quality).Level;
		}
		float qualityLevel = (float) qualityLevelSum/TestedQualities.Count;
		float difficultyScaler = 0.6f;
		ChanceOfSuccess = Math.Min(100, qualityLevel*difficultyScaler*100/difficulty);
	}

	public void ChooseBranch(Person person)
	{
		//Decide which result to use
		if(successResult != null)
		{
			PickResult(person.Qualities);
		}
		else
			chosenResult = defaultResult;

		chosenResult.EffectPerson(person);
	}

	private void PickResult(List<IQuality> qualities)
	{
		if(Manager.rand.Next(101) <= ChanceOfSuccess)
			chosenResult = successResult;
		else
			chosenResult = defaultResult;
	}
}
