using UnityEngine;
using System.Collections;

public class MainSceneManager : MonoBehaviour {

	public GameObject player;
	public GameObject manager;
	public GameObject storyContainer;
	public AvatarView avatarView;
	public GameObject sleepButton;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		manager = GameObject.Find ("Manager");
		storyContainer = GameObject.Find ("StoryContainer");

		manager.GetComponent<Manager>().MainSceneStart();
		player.GetComponent<Player>().MainSceneStart();
		storyContainer.GetComponent<StoryContainer>().manager = manager.GetComponent<Manager>();
		storyContainer.GetComponent<StoryContainer>().MainSceneStart();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadScene(string scene)
	{
		Application.LoadLevel(scene);
	}
}
