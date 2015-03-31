using UnityEngine;
using System.Collections;

public class MainSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadScene(string scene)
	{
		Application.LoadLevel(scene);
	}
}
