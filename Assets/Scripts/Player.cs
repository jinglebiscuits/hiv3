﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	private Person focusedPerson;
	private string username;
	public AvatarView avatarView;
	public bool hasCreatedCharacter = false;

	public Image profileHair;
	public Image profileBody;
	public Image profileHeadColor;
	public Image profileHeadLines;
	public Image profileShirt;
	public Image profileSclera;
	public Image profileIris;
	public Image profileLips;
	public Image profileBorder;
	public Image profileBackground;

	public static Player player;

	public int test = 4;

	void Awake ()
	{
		if(player == null)
		{
			DontDestroyOnLoad(gameObject);
			player = this;
		}
		else if(player != this)
		{
			Destroy(gameObject);
		}

		if(focusedPerson == null)
		{
			DefaultSetup();
		}
	}

	void Start ()
	{
		if(Application.loadedLevelName == "CharacterCreation")
		{
			avatarView = GameObject.Find("AvatarView").GetComponent<AvatarView>();
// 			GameObject.Find("ProfileAvatar").GetComponent<ProfileAvatarView>().player = this.gameObject;
		}
	}

	public void MainSceneStart()
	{
		avatarView = GameObject.Find("AvatarView").GetComponent<AvatarView>();
// 		GameObject.Find("ProfileAvatar").GetComponent<ProfileAvatarView>().player = this.gameObject;
	}

	void OnLevelWasLoaded(int level)
	{
		if(level == 1 | level == 2)
		{
			avatarView = GameObject.Find("AvatarView").GetComponent<AvatarView>();
// 			GameObject.Find("ProfileAvatar").GetComponent<ProfileAvatarView>().player = GameObject.Find("Player");
		}
	}

	public Person FocusedPerson {
		get {
			return this.focusedPerson;
		}
		set {
			focusedPerson = value;
		}
	}
	
	public string Username {
		get {
			return this.username;
		}
		set {
			username = value;
		}
	}

	public void DefaultSetup()
	{
		Person person = new Person();
		focusedPerson = person;
	}

	public void ChangeGender(Toggle maleToggle)
	{
		if(focusedPerson.BodyType == BodyType.male && !maleToggle.isOn)
		{
			focusedPerson.ChangeGender(BodyType.female);
		}
		else {
			focusedPerson.ChangeGender(BodyType.male);
		}
		avatarView.SyncAvatar();
// 		avatarView.DisplayAppropriateBody(focusedPerson.BodyType);
	}
}
