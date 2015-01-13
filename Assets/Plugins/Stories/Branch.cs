using System.Collections.Generic;
using System.Collections;

/// <summary>
/// A Branch represents a possible path from a Trunk. Branches need unique names within their story trees.
/// </summary>
public class Branch : Story{
	
	private Result defaultResult;
	private Result successResult;
	private float timeCost;
	private Story linkedEvent;

	#region Contructors
	public Branch ()
		:base()
	{
		this.title = "branch_title";
		this.description = "branch_description";
		this.icon = "branch_icon";
		this.buttonText = "branch_button_text";
		this.requirements = new List<Requirement>();
		this.defaultResult = new Result();
		this.successResult = new Result();
		this.timeCost = 1.0f;
		this.linkedEvent = new Story();
	}
	

	public Branch (string title, string description, string icon, string buttonText, List<Requirement> requirements, Result defaultResult)
		:base(title, description, icon, buttonText, requirements)
	{
		this.defaultResult = defaultResult;
		this.successResult = null;
		this.timeCost = 1.0f;
		this.linkedEvent = null;
	}

	public Branch (string title, string description, string icon, string buttonText, List<Requirement> requirements, Result defaultResult, Result successResult)
		:base(title, description, icon, buttonText, requirements)
	{
		this.defaultResult = defaultResult;
		this.successResult = successResult;
		this.timeCost = 1.0f;
		this.linkedEvent = null;
	}

	public Branch (string title, string description, string icon, string buttonText, List<Requirement> requirements, Result defaultResult, Result successResult, Story linkedEvent)
		:base(title, description, icon, buttonText, requirements)
	{
		this.defaultResult = defaultResult;
		this.successResult = successResult;
		this.timeCost = 1.0f;
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

	public float TimeCost {
		get {
			return this.timeCost;
		}
		set {
			timeCost = value;
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

	public void ChooseBranch(Person person)
	{
		//use time requirement
		UseTime();
		//Decide which result to use
		if(successResult != null)
		{
			PickResult().AffectCharacter(person);
		}
		else
			defaultResult.AffectCharacter(person);
	}

	private void UseTime()
	{
		//push time forward timeCost
	}

	private Result PickResult()
	{
		//Do some clever math stuff to pick which result
		Result result = defaultResult; //this is just a placeholder
		return result;
	}
}
