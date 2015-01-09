using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterStats : MonoBehaviour {


	public GameObject attributeViewPrefab;
	public GameObject intelligenceViewPrefab;
	public GameObject physicalViewPrefab;
	public GameObject socialViewPrefab;
	public GameObject mettleViewPrefab;
	private BaseAttributes baseAttributes;

	// Use this for initialization
	void Start ()
	{
		GameObject intelligence = (GameObject) Instantiate(intelligenceViewPrefab);
		intelligence.GetComponent<AttributeView>().Attribute = baseAttributes.intelligence;
		intelligence.transform.SetParent(this.transform, false);
		intelligence.GetComponent<RectTransform>().position += new Vector3(0, 0, 0);

		GameObject physical = (GameObject) Instantiate(physicalViewPrefab);
		physical.GetComponent<AttributeView>().Attribute = baseAttributes.physical;
		physical.transform.SetParent(this.transform, false);
		physical.GetComponent<RectTransform>().position += new Vector3(0, -48, 0);

		GameObject social = (GameObject) Instantiate(socialViewPrefab);
		social.GetComponent<AttributeView>().Attribute = baseAttributes.social;
		social.transform.SetParent(this.transform, false);
		social.GetComponent<RectTransform>().position += new Vector3(0, -96, 0);

		GameObject mettle = (GameObject) Instantiate(mettleViewPrefab);
		mettle.GetComponent<AttributeView>().Attribute = baseAttributes.mettle;
		mettle.transform.SetParent(this.transform, false);
		mettle.GetComponent<RectTransform>().position += new Vector3(0, -144, 0);
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
