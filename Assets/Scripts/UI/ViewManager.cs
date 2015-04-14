using UnityEngine;
using System.Collections;

public class ViewManager : MonoBehaviour {
	
	public CharacterStatsView characterStatsView;
		
	// Use this for initialization
	void Start () {
//		characterStatsView.BaseAttributes = GameObject.Find("Player").GetComponent<Player>().FocusedPerson.BaseAttributes;
//		characterStatsView.ViewConstructor();
	}

	void OnLevelWasLoaded(int level)
	{

	}

	public void MainSceneStart(GameObject player)
	{
		characterStatsView = GameObject.Find ("CharacterStatsView").GetComponent<CharacterStatsView>();
		characterStatsView.BaseAttributes = player.GetComponent<Player>().FocusedPerson.BaseAttributes;
		characterStatsView.ViewConstructor();
	}
}
