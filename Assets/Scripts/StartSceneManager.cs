using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class StartSceneManager : MonoBehaviour {
	
	public bool newUsername = true;
	public bool readyToLogin = false;
	private string username;
	
	private List<string> usernames = new List<string>();
	
	public Button continueButton;
	public Button newButton;
	
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
		}
		else if (readyToLogin) {
			newButton.interactable = false;
			continueButton.interactable = true;
		}
	}
	
	public void Login() {
		print(username);
		Player.player.Username = username;
		if (usernames.Exists (x => x == username)) {
			Manager.manager.Load();
		}
		else {
			usernames.Add (username);
			UpdateUsers (ListToArray (usernames));
			Manager.manager.NewGame ();
		}
		
		StartGame();
	}
	
	public void UpdateUsers (string[] usernames) {
		File.WriteAllLines(Application.persistentDataPath + "/Hiv/users.dat",
											usernames, Encoding.UTF8);
	}
	
	private string[] ListToArray (List<string> myList) {
		string[] myArray = new string[myList.Count];
		for (int i = 0; i < myList.Count; i++) {
			myArray[i] = myList[0];
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