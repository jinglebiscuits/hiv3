using UnityEngine;
using System.Collections;

/// <summary>
/// A story is any card the player can click on to unfold some of the game. Trunks and Branches are both stories.
/// </summary>
public abstract class Story : MonoBehaviour {

	private string title;
	private string description;
	private string icon;
	private string buttonText;
	private string requirements;

	abstract public bool Requirements(Person person);
}
