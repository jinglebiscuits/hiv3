using UnityEngine;
using System.Collections;

public class ViewManager : MonoBehaviour {
	
	public CharacterStatsView characterStatsView;
		
	// Use this for initialization
	void Start () {
		characterStatsView.BaseAttributes = GameObject.Find("Player").GetComponent<Player>().FocusedPerson.BaseAttributes;
		characterStatsView.ViewConstructor();
	}
}
