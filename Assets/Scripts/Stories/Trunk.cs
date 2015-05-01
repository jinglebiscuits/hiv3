using System.Collections.Generic;
using System.Collections;

/// <summary>
/// A Trunk represents the base of a story. Each trunk needs a unique name.
/// </summary>
public class Trunk : Story{
	
	/// <summary>
	/// Tags help categories stories for grouping purposes.
	/// </summary>
	private string trunkTag;
	private string area;
	private string urgency;

	/// <summary>
	/// Defaults to "Always" deck, which just checks requirements.
	/// </summary>
	/// Other decks can allow for some randomness in what's available to the player.
	private string deck;

	/// <summary>
	/// All possible choices branching from this trunk.
	/// </summary>
	private List<Branch> branches;

	#region Contrustors
	public Trunk ()
		:base()
	{
		this.trunkTag = "Trunk_Tag";
		this.area = "Trunk_Area";
		this.urgency = "Trunk_Urgency";
		this.deck = "Trunk_Deck";
		this.branches = new List<Branch>();
	}
	

	public Trunk (string title, string description, string icon, string buttonText, List<Requirement> requirements, string trunkTag, string area, string urgency, string deck, List<Branch> branches)
		:base(title, description, icon, buttonText, requirements)
	{
		this.trunkTag = trunkTag;
		this.area = area;
		this.urgency = urgency;
		this.deck = deck;
		this.branches = branches;
	}
	#endregion

	#region accessor methods
	public string TrunkTag {
		get {
			return this.trunkTag;
		}
		set {
			trunkTag = value;
		}
	}

	public string Area {
		get {
			return this.area;
		}
		set {
			area = value;
		}
	}

	public string Urgency {
		get {
			return this.urgency;
		}
		set {
			urgency = value;
		}
	}

	public string Deck {
		get {
			return this.deck;
		}
		set {
			deck = value;
		}
	}

	public List<Branch> Branches {
		get {
			return this.branches;
		}
		set {
			branches = value;
		}
	}
	#endregion

	public override bool IsPlayableByPerson (Person person)
	{
		List<IQuality> qualities = person.Qualities;
		if(Area != person.Area)
			return false;

		if(Requirements.Count > 0)
		{
			foreach(Requirement requirement in Requirements)
			{
				IQuality matchingQuality = FindMatchingQuality(qualities, requirement.Quality);
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
}
