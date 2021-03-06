﻿using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Scrolling rect is the region of the screen that contains the stories. It is a scrolling area.
/// </summary>
public class BrowseStoriesView : MonoBehaviour {

	private ScrollRect scrollRect;

	// Use this for initialization
	void Awake () {
		scrollRect = transform.GetComponent<ScrollRect>();
		scrollRect.verticalNormalizedPosition = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetScrollToTop()
	{
		scrollRect.verticalNormalizedPosition = 1;
	}
}
