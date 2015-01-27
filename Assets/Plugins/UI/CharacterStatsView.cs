using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterStatsView : MonoBehaviour {
	
	public GameObject intelligenceView;
	public GameObject physicalView;
	public GameObject socialView;
	public GameObject mettleView;
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
		//intelligence = (GameObject) Instantiate(intelligenceViewPrefab);
		intelligenceView.GetComponent<AttributeView>().Attribute = baseAttributes.intelligence;
		intelligenceView.transform.SetParent(this.transform, false);
		//intelligenceView.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 0);
		
		//GameObject physical = (GameObject) Instantiate(physicalViewPrefab);
		physicalView.GetComponent<AttributeView>().Attribute = baseAttributes.physical;
		physicalView.transform.SetParent(this.transform, false);
		//physical.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -48);
		
		//GameObject social = (GameObject) Instantiate(socialViewPrefab);
		socialView.GetComponent<AttributeView>().Attribute = baseAttributes.social;
		socialView.transform.SetParent(this.transform, false);
		//socialView.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -96);
		
		//GameObject mettle = (GameObject) Instantiate(mettleViewPrefab);
		mettleView.GetComponent<AttributeView>().Attribute = baseAttributes.mettle;
		mettleView.transform.SetParent(this.transform, false);
		//mettle.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -144);
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
