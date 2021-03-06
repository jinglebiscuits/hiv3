﻿using System.Collections.Generic;

/// <summary>
/// A story is any card the player can click on to unfold some of the game. Trunks and Branches are both stories.
/// </summary>
public class Story {

	protected string title;
	protected string description;
	protected string icon;
	protected string buttonText;
	protected List<Requirement> requirements;

	#region Constructors
	public Story ()
	{
		this.title = "story_title";
		this.description = "story_description";
		this.icon = "story_icon";
		this.buttonText = "story_button_text";
		this.requirements = new List<Requirement>();
	}

	public Story (string title, string description, string icon, string buttonText, List<Requirement> requirements)
	{
		this.title = title;
		this.description = description;
		this.icon = icon;
		this.buttonText = buttonText;
		this.requirements = requirements;
	}
	#endregion

	#region Access Modifiers
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

	public string Icon {
		get {
			return this.icon;
		}
		set {
			icon = value;
		}
	}

	public string ButtonText {
		get {
			return this.buttonText;
		}
		set{
			buttonText = value;
		}
	}

	public List<Requirement> Requirements {
		get {
			return this.requirements;
		}
		set {
			requirements = value;
		}
	}
	#endregion


	#region Methods
	public bool IsVisibleToPerson(Person person)
	{
		return true;
	}

	public virtual bool IsPlayableByPerson(Person person)
	{
		if(Requirements.Count > 0)
		{
			foreach(Requirement requirement in Requirements)
			{
				IQuality matchingQuality = person.QualitiesDict[requirement.Quality.Name];
				if(matchingQuality == null)
				{
					return false;
				}
				else if (matchingQuality.Level > requirement.QualityMax || matchingQuality.Level < requirement.QualityMin) {
					return false;
				}
			}
		}
		else
		{
			return true;
		}
		return true;
	}
	#endregion
}
