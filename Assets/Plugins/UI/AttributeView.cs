using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttributeView : MonoBehaviour {

	private Attribute attribute;
	public Image attributeIcon;
	public Text attributeName;
	public Text attributeLevel;
	public Slider attributePointsProgress;

	// Use this for initialization
	void Start ()
	{
		attribute.pointEvent +=	UpdateView;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public Attribute Attribute {
		get {
			return this.attribute;
		}
		set {
			attribute = value;
			UpdateView();
		}
	}

	public void UpdateView()
	{
		attributeName.text = attribute.Name;
		attributeLevel.text = attribute.Level.ToString();
		attributePointsProgress.maxValue = attribute.Level;
		attributePointsProgress.value = attribute.Points;
	}
}
