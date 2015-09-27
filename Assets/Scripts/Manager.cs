using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Manager : MonoBehaviour {

	public static System.Random rand = new System.Random();
	public XML xmlScript;
	public StoryContainer storyContainer;

	public static Manager manager;

	void Awake ()
	{
		if(manager == null)
		{
			DontDestroyOnLoad(gameObject);
			manager = this;
		}
		else if(manager != this)
		{
			Destroy(gameObject);
		}
	}

    void OnDisable()
    {
		Debug.Log (this.name + ": OnDisable -> saving");
        Save();
    }

	// Use this for initialization
	void Start () {
		Debug.Log (Application.persistentDataPath);
	}

	void OnLevelWasLoaded(int level)
	{
		if(level == 1)
		{
			//anything that needs to happen on level 1
		}
	}

	public void MainSceneStart()
	{
		storyContainer = GameObject.Find ("StoryContainer").GetComponent<StoryContainer>();
		gameObject.GetComponent<ViewManager>().MainSceneStart(GameObject.Find("Player"));
	}

	public void UpdateTrunks()
	{
		Player.player.FocusedPerson.UpdateAvailableTrunkList(xmlScript.trunks);
		Debug.Log (this.name + ": UpdateTrunks -> saving");
        Save();
	}

	public void LoadScene(string scene)
	{
		Application.LoadLevel(scene);
	}

	public void Save ()
	{
		string username = Player.player.Username;
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file;
		try {
			file = File.Create(Application.persistentDataPath + "/Hiv/PlayerInfo/" + username + ".dat");
		}
		catch (Exception e) {
			if (e is DirectoryNotFoundException || e is System.IO.IsolatedStorage.IsolatedStorageException) {
				Debug.Log (e);
				Debug.Log ("Creating it now");
				Directory.CreateDirectory (Application.persistentDataPath + "/Hiv/PlayerInfo");
				file = File.Create(Application.persistentDataPath + "/Hiv/PlayerInfo/" + username + ".dat");
			} else {
				Debug.Log (e);
				Debug.Log("something ain't right");
				Directory.CreateDirectory (Application.persistentDataPath + "/Hiv");
				Directory.CreateDirectory (Application.persistentDataPath + "/Hiv/PlayerInfo");
				file = File.Create(Application.persistentDataPath + "/Hiv/PlayerInfo/" + username + ".dat");
			}
		}
		bf.Serialize(file, Player.player.FocusedPerson);
		file.Close();
	}
	
	public void Load () {
		if(File.Exists(Application.persistentDataPath + "/Hiv/PlayerInfo/" + Player.player.Username + ".dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + 
										"/Hiv/PlayerInfo/" + Player.player.Username + ".dat", FileMode.Open);
            Player.player.FocusedPerson = (Person) bf.Deserialize(file);
			file.Close();
            Player.player.FocusedPerson.AvailableTrunks = new System.Collections.Generic.List<Trunk>();
		}
	}
	
	public void NewGame () {
		Debug.Log (Player.player.Username);
		Save ();
		Load ();
	}
}