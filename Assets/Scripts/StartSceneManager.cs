﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class StartSceneManager : MonoBehaviour {
	
	public bool newUsername = true;
	public bool readyToLogin = false;
	private string username;
	public Text saveURL;
	
	private List<string> usernames = new List<string>();
	
	public Button continueButton;
	public Button newButton;
	
	void Awake () {
		saveURL.GetComponent<Text>().text = Application.persistentDataPath;
	}
	
	// Use this for initialization
	void Start () {
		continueButton.interactable = false;
		newButton.interactable = false;
		
		try {
			usernames = ArrayToList(File.ReadAllLines(Application.persistentDataPath + "/Hiv/users.dat",
								Encoding.UTF8));
		}
		catch (DirectoryNotFoundException e) {
			Debug.Log(e);
			Debug.Log("Creating it now.");
			Directory.CreateDirectory(Application.persistentDataPath + "/Hiv");
		}
		catch (FileNotFoundException e) {
			Debug.Log(e);
			Debug.Log("Creating it now.");
			File.Create(Application.persistentDataPath + "/Hiv/users.dat");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void StartGame()
	{
		Application.LoadLevel("CharacterCreation");
	}
	
	public void CheckUsername(string username) {
		username = username.ToLower();
		if(username.Length > 1) {
			if (usernames.Exists(x => x == username)) {
				newUsername = false;
			}
			else {
				newUsername = true;
			}
			readyToLogin = true;
		}
		else
			readyToLogin = false;
		
		this.username = username;
		UpdateButtons();
	}
	
	private void UpdateButtons() {
		if (newUsername && readyToLogin) {
			newButton.interactable = true;
			continueButton.interactable = false;
		}
		else if (readyToLogin) {
			newButton.interactable = false;
			continueButton.interactable = true;
		}
		else {
			newButton.interactable = false;
			continueButton.interactable = false;
		}
	}
	
	public void Login() {
		print(username);
		Player.player.Username = username;
		if (usernames.Exists (x => x == username)) {
			Manager.manager.Load();
			Application.LoadLevel("CharacterInfo");
		}
		else {
			usernames.Add (username);
			UpdateUsers (ListToArray (usernames));
			Manager.manager.NewGame ();
			Application.LoadLevel("CharacterCreation");
		}
		
		//  StartGame();
	}
	
	public void UpdateUsers (string[] usernames) {
		try {
			File.WriteAllLines(Application.persistentDataPath + "/Hiv/users.dat",
											usernames, Encoding.UTF8);
		}
		catch (Exception e) {
			if (e is DirectoryNotFoundException || e is System.IO.IsolatedStorage.IsolatedStorageException) {
				Directory.CreateDirectory (Application.persistentDataPath + "/Hiv");
			} else {
				Directory.CreateDirectory (Application.persistentDataPath + "/Hiv");
			}
			File.WriteAllLines(Application.persistentDataPath + "/Hiv/users.dat",
											usernames, Encoding.UTF8);
		}
	}
	
	private string[] ListToArray (List<string> myList) {
		string[] myArray = new string[myList.Count];
		for (int i = 0; i < myList.Count; i++) {
			myArray[i] = myList[i];
		}
		return myArray;
	}
	
	private List<string> ArrayToList (string[] myArray) {
		List<string> myList = new List<string>();
		for (int i = 0; i < myArray.Length; i++) {
			myList.Add (myArray[i]);
		}
		return myList;
	}
}