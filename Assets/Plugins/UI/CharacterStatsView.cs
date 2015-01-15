using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterStatsView : MonoBehaviour {


	public GameObject attributeViewPrefab;
	public GameObject intelligenceViewPrefab;
	public GameObject physicalViewPrefab;
	public GameObject socialViewPrefab;
	public GameObject mettleViewPrefab;
	public GameObject intelligence;
	private BaseAttributes baseAttributes;

	// Use this for initialization
	void Start ()
	{

	}

	void Update()
	{
		
	}

	public void ViewConstructor()
	{
		intelligence = (GameObject) Instantiate(intelligenceViewPrefab);
		intelligence.GetComponent<AttributeView>().Attribute = baseAttributes.intelligence;
		intelligence.transform.SetParent(this.transform, false);
		intelligence.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 0);
		
		GameObject physical = (GameObject) Instantiate(physicalViewPrefab);
		physical.GetComponent<AttributeView>().Attribute = baseAttributes.physical;
		physical.transform.SetParent(this.transform, false);
		physical.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -48);
		
		GameObject social = (GameObject) Instantiate(socialViewPrefab);
		social.GetComponent<AttributeView>().Attribute = baseAttributes.social;
		social.transform.SetParent(this.transform, false);
		social.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -96);
		
		GameObject mettle = (GameObject) Instantiate(mettleViewPrefab);
		mettle.GetComponent<AttributeView>().Attribute = baseAttributes.mettle;
		mettle.transform.SetParent(this.transform, false);
		mettle.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -144);
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
