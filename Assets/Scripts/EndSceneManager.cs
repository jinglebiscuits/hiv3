using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Replay()
	{
		Application.LoadLevel("StartScene");
	}
}
