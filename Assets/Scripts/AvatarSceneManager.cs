﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AvatarSceneManager : MonoBehaviour {

	public GameObject player;
	public AvatarView avatarView;
	public GameObject genderTogglePanel;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		if(player.GetComponent<Player>().hasCreatedCharacter)
		{
			genderTogglePanel.SetActive(false);
		}

		avatarView.DisplayAppropriateBody(player.GetComponent<Player>().FocusedPerson.BodyType);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeGenderConnector(Toggle maleToggle)
	{
		player.GetComponent<Player>().ChangeGender(maleToggle);
	}

	public void CommitChanges()
	{
		Player playerScript = player.GetComponent<Player>();
		playerScript.hasCreatedCharacter = true;
//		player.GetComponent<Avatar>().hair = (Image) Instantiate(avatarView.hair) as Image;
//		player.GetComponent<Avatar>().body = (Image) Instantiate(avatarView.body) as Image;
//		player.GetComponent<Avatar>().headColor = (Image) Instantiate(avatarView.headColor) as Image;
//		player.GetComponent<Avatar>().headLines = (Image) Instantiate(avatarView.headLines) as Image;
//		player.GetComponent<Avatar>().pants = (Image) Instantiate(avatarView.pants) as Image;
//		player.GetComponent<Avatar>().shirt = (Image) Instantiate(avatarView.shirt) as Image;
//		player.GetComponent<Avatar>().shoes = (Image) Instantiate(avatarView.shoes) as Image;
//		player.GetComponent<Avatar>().sclera = (Image) Instantiate(avatarView.sclera) as Image;
//		player.GetComponent<Avatar>().iris = (Image) Instantiate(avatarView.iris) as Image;
//		player.GetComponent<Avatar>().lips = (Image) Instantiate(avatarView.lips) as Image;
	}
}
