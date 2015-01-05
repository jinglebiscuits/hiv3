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
	
	// Update is called once per frame
	void Update () {
	
	}

	public BaseAttributes BaseAttributes {
		get {
			return this.baseAttributes;
		}
		set {
			baseAttributes = value;
			//ShowAttributes(value);
		}
	}

//	private void ShowAttributes(BaseAttributes baseAttributes)
//	{
//		int count = 0;
//		foreach(Attribute attribute in baseAttributes.attributes)
//		{
//			GameObject clone = (GameObject) Instantiate(attributeViewPrefab);
//			clone.GetComponent<AttributeView>().Attribute = attribute;
//			clone.transform.SetParent(this.transform, false);
//			clone.GetComponent<RectTransform>().position += new Vector3(0, count * -48, 0);
//			count ++;
//		}
//	}
}
