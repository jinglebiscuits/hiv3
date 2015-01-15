using UnityEngine;
using System.Collections;

/// <summary>
/// Scrolling rect is the region of the screen that contains the stories. It is a scrolling area.
/// </summary>
public class BrowseStoriesView : MonoBehaviour {

	private Forest forest = new Forest();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Forest Forest {
		get {
			return this.forest;
		}
		set {
			forest = value;
		}
	}
}
