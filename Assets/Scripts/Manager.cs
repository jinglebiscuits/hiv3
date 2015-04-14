using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Manager : MonoBehaviour {

	public static System.Random rand = new System.Random();
	public XML xmlScript;
	public Person person;
	public StoryContainer storyContainer;
	
	public static Manager manager;


	//level 1 stuff
	private GameObject player;
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

	}

	// Use this for initialization
	void Start () {
		person = GameObject.Find("Player").GetComponent<Player>().FocusedPerson;
		//person.UpdateAvailableTrunkList(xmlScript.trunks);
//		storyContainer.ShowStories();
	}

	void OnLevelWasLoaded(int level)
	{
		if(level == 1)
		{
			player = GameObject.Find ("Player");
			profileAvatar = GameObject.Find("ProfileAvatar");
			avatarView = GameObject.Find ("AvatarView");

			profileAvatar.GetComponent<ProfileAvatarView>().player = player;
		}
	}

	public void MainSceneStart()
	{
		player = GameObject.Find("Player");
		storyContainer = GameObject.Find ("StoryContainer").GetComponent<StoryContainer>();
		person = player.GetComponent<Player>().FocusedPerson;
		person.UpdateAvailableTrunkList(xmlScript.trunks);
		gameObject.GetComponent<ViewManager>().MainSceneStart(player);
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateTrunks()
	{
		person.UpdateAvailableTrunkList(xmlScript.trunks);
	}

	public void LoadScene(string scene)
	{
		Application.LoadLevel(scene);
	}

//	public void Save()
//	{
//		BinaryFormatter bf = new BinaryFormatter();
//		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
//		
//		Character character = GameObject.Find("Character").GetComponent<Character>();
//		foreach(int itemNumber in character.avatar.SavedAvatar)
//		{
//			print (itemNumber);
//		}
//		
//		PlayerData data = new PlayerData();
//		data.savedAvatar = character.avatar.SavedAvatar;
//		data.gender = character.Gender;
//		
//		bf.Serialize(file, data);
//		file.Close();
//	}
//	
//	public void Load()
//	{
//		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
//		{
//			BinaryFormatter bf = new BinaryFormatter();
//			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
//			PlayerData data = (PlayerData) bf.Deserialize(file);
//			file.Close();
//			
//			Character character = GameObject.Find("Character").GetComponent<Character>();
//			
//			character.avatar.SavedAvatar = data.savedAvatar;
//			character.Gender = data.gender;
//		}
//	}
}
//
//[Serializable]
//class PlayerData
//{
//	public string gender;
//	public int[] savedAvatar;
//}
