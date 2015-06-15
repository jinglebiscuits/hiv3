using UnityEngine;

public class CharacterStatsView : MonoBehaviour {
	
	public GameObject intelligenceView;
	public GameObject physicalView;
	public GameObject socialView;
	public GameObject mettleView;
	private BaseAttributes baseAttributes;

	public void ViewConstructor()
	{
		intelligenceView.GetComponent<AttributeView>().Attribute = baseAttributes.intelligence;
		intelligenceView.transform.SetParent(this.transform, false);

		physicalView.GetComponent<AttributeView>().Attribute = baseAttributes.physical;
		physicalView.transform.SetParent(this.transform, false);

		socialView.GetComponent<AttributeView>().Attribute = baseAttributes.social;
		socialView.transform.SetParent(this.transform, false);

		mettleView.GetComponent<AttributeView>().Attribute = baseAttributes.mettle;
		mettleView.transform.SetParent(this.transform, false);
	}


	public BaseAttributes BaseAttributes {
		get {
			return this.baseAttributes;
		}
		set {
			baseAttributes = value;
		}
	}
}
