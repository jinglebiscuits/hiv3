using UnityEngine;
using System.Collections;

/// <summary>
/// A story is any card the player can click on to unfold some of the game. Trunks and Branches are both stories.
/// </summary>
public class Story : MonoBehaviour {

	private string title;
	private string description;
	private string icon;
	private string buttonText;



	/// <summary>
	/// In what area can this story be played? This is basically a requirement.
	/// </summary>

	private string requirements;

	public bool Requirements(Person person)
	{

		return false;
	}
}
