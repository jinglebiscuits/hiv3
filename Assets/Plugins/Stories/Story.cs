using UnityEngine;
using System.Collections.Generic;
using System.Collections;

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
	}

	public string Description {
		get {
			return this.description;
		}
	}

	public string Icon {
		get {
			return this.icon;
		}
	}

	public string ButtonText {
		get {
			return this.buttonText;
		}
	}

	public List<Requirement> Requirements {
		get {
			return this.requirements;
		}
	}
	#endregion
}
