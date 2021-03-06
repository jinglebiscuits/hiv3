﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class MainSceneManager : MonoBehaviour {

	public GameObject storyContainer;
	public AvatarView avatarView;
	public GameObject sleepButton;
	public Text locationText;
	public Button shopButton;


	// Use this for initialization
	void Start () {
		storyContainer = GameObject.Find ("StoryContainer");

		Manager.manager.MainSceneStart();
		Player.player.MainSceneStart();
		storyContainer.GetComponent<StoryContainer>().manager = Manager.manager;
		storyContainer.GetComponent<StoryContainer>().MainSceneStart();
		Analytics.CustomEvent("mainSceneStart", new Dictionary<string, object>
			{
				{ "time", Time.time }
			});
	}

	public void LoadScene(string scene)
	{
		Application.LoadLevel(scene);
	}

	public void UpdateLocationText()
	{
		locationText.text = Player.player.FocusedPerson.Area;
	}
}
