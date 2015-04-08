using UnityEngine;
using System.Collections;

public class MainSceneManager : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadScene(string scene)
	{
		Application.LoadLevel(scene);
	}
}
