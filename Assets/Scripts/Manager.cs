using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Manager : MonoBehaviour {

	public static System.Random rand = new System.Random();
	public XML xmlScript;
	public StoryContainer storyContainer;

	public static Manager manager;


	//level 1 stuff
	private GameObject profileAvatar;
	private GameObject avatarView;

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

	void OnEnable()
	{
        Load();
	}

    void OnDisable()
    {
        Save();
    }

	// Use this for initialization
	void Start () {
		//person.UpdateAvailableTrunkList(xmlScript.trunks);
//		storyContainer.ShowStories();
	}

	void OnLevelWasLoaded(int level)
	{
		if(level == 1)
		{
			GameObject player = GameObject.Find ("Player");
			profileAvatar = GameObject.Find("ProfileAvatar");
			avatarView = GameObject.Find ("AvatarView");

			profileAvatar.GetComponent<ProfileAvatarView>().player = player;
		}
	}

	public void MainSceneStart()
	{
		GameObject player = GameObject.Find("Player");
		storyContainer = GameObject.Find ("StoryContainer").GetComponent<StoryContainer>();
//		person.UpdateAvailableTrunkList(xmlScript.trunks);
		gameObject.GetComponent<ViewManager>().MainSceneStart(player);
	}

	public void UpdateTrunks()
	{
		Player.player.FocusedPerson.UpdateAvailableTrunkList(xmlScript.trunks);
	}

	public void LoadScene(string scene)
	{
		Application.LoadLevel(scene);
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/hivPlayerInfo.dat");
		
		bf.Serialize(file, Player.player.FocusedPerson);
		file.Close();
	}
	
	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/hivPlayerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/hivPlayerInfo.dat", FileMode.Open);
            Player.player.FocusedPerson = (Person) bf.Deserialize(file);
			file.Close();
            Player.player.FocusedPerson.AvailableTrunks = new System.Collections.Generic.List<Trunk>();
		}
	}
}