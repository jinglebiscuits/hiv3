using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndSceneManager : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Replay()
	{
		Application.LoadLevel("StartScene");
	}
}
