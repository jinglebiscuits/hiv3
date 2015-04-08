using UnityEngine;
using System.Collections;

public class StartSceneManager : MonoBehaviour {

	public GameObject player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void StartGame()
	{
		Application.LoadLevel("CharacterCreation");
	}
}
