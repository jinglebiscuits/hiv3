using System.Collections.Generic;
using System.Collections;

/// <summary>
/// A Trunk represents the base of a story. Each trunk needs a unique name.
/// </summary>
public class Trunk : Story {

	/// <summary>
	/// Tags help categories stories for grouping purposes.
	/// </summary>
	private string tag;
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
	private List<Branch> branches = new List<Branch>();

	override public bool Requirements(Person person)
	{
		return false;
	}
}
