using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrunkView : MonoBehaviour {

	private Trunk trunk;
	public Text trunkTitle;
	public Text trunkDescription;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Trunk Trunk {
		get {
			return this.trunk;
		}
		set {
			trunk = value;
			trunkTitle.text = trunk.Title;
			trunkDescription.text = trunk.Description;
		}
	}
}
