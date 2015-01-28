using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class AttributeView : MonoBehaviour {

	private Attribute attribute;
	public Image attributeIcon;
	public Text attributeName;
	public Text attributeLevel;
	public Slider attributePointsProgress;

	// Use this for initialization
	void Start ()
	{
		//When pointEvent() is called on attached attribute, run the UpdateView() method.
		//attribute.pointEvent +=	UpdateView;
	}

	public Attribute Attribute {
		get {
			return this.attribute;
		}
		set {
			attribute = value;
			attribute.pointEvent -=	UpdateView;
			attribute.pointEvent +=	UpdateView;
			attributeName.text = attribute.Name;
			attributeLevel.text = attribute.Level.ToString();
			attributePointsProgress.maxValue = attribute.Level;
			attributePointsProgress.value = attribute.Points;
			UpdateView();
		}
	}

	public void UpdateView()
	{
		StartCoroutine(AnimatePointChange(attribute.Level, attribute.Points));
	}

	private IEnumerator AnimatePointChange(int actualLevel, int actualPoints)
	{
		//if the actual level = the displayed level
		if (actualLevel == Convert.ToInt32(this.attributeLevel.text))
		{
			//animate bar up to actualPoints
			while(actualPoints > attributePointsProgress.value)
			{
				attributePointsProgress.value += 0.1f;
				yield return new WaitForSeconds(0.05f);
			}
		}
		//if the actual level is greater than the displayed level
		else if(actualLevel > Convert.ToInt32(this.attributeLevel.text))
		{
			//animate points going up until the levels are the same
			while(actualLevel > Convert.ToInt32(this.attributeLevel.text))
			{
				//animate points going up until slider value = displayed level
				while(attributePointsProgress.value < Convert.ToInt32(this.attributeLevel.text))
				{
					attributePointsProgress.value += 0.1f;
					yield return new WaitForSeconds(0.05f);
				}
				attributePointsProgress.value = 0;
				attributePointsProgress.maxValue ++;
				attributeLevel.text = (Convert.ToInt32(this.attributeLevel.text) + 1).ToString();
			}

			while(attributePointsProgress.value < actualPoints)
			{
				attributePointsProgress.value += 0.1f;
				yield return new WaitForSeconds(0.05f);
			}
		}
	}
}
