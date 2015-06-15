using UnityEngine;
using UnityEngine.UI;

public class TrunkView : MonoBehaviour {

	private Trunk trunk;
	public Text trunkTitle;
	public Text trunkDescription;

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
