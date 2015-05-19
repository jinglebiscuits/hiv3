using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class AttributeView : MonoBehaviour {

	private Attribute attribute;
	public Image attributeIcon;
	public Text attributeName;
	public Text attributeLevel;
	public Text attributeModifier;
	public Slider attributePointsProgress;

	private Color plusModifierColor = new Color(51, 187, 238);
	private Color minusModifierColor = new Color(255, 68, 68);

	/// <summary>
	/// how much the point value changes per tick of the coroutine.
	/// </summary>
	private float pointDelta;
	private float timeToAnimatePoint;

	// Use this for initialization
	void Start ()
	{
		pointDelta = 0.05f;
		timeToAnimatePoint = 0.5f;
	}

	public Attribute Attribute {
		get {
			return this.attribute;
		}
		set {
			attribute = value;
			attribute.pointEvent -=	UpdateView;
			attribute.pointEvent +=	UpdateView;

			attribute.modifierEvent -= UpdateModifier;
			attribute.modifierEvent += UpdateModifier;

			attributeName.text = attribute.Name;
			attributeLevel.text = attribute.Level.ToString();

			attributePointsProgress.maxValue = attribute.Level;
			attributePointsProgress.value = attribute.Points;

			UpdateModifier();
			UpdateView();

		}
	}

	void OnDestroy()
	{
		if(attribute != null)
		{
			attribute.pointEvent -= UpdateView;
			attribute.modifierEvent -= UpdateModifier;
		}
	}

	public void UpdateView()
	{
		StartCoroutine(AnimatePointChange(attribute.Level, attribute.Points));
	}

	private void UpdateModifier()
	{
		if(attribute.Modifier > 0)
		{
			attributeModifier.text = "+" + attribute.Modifier.ToString();
			attributeModifier.color = plusModifierColor;
		}
		else if(attribute.Modifier < 0)
		{
			attributeModifier.text = "-" + attribute.Modifier.ToString();
			attributeModifier.color = minusModifierColor;
		}
		else
			attributeModifier.text = "";
	}

	private IEnumerator AnimatePointChange(int actualLevel, int actualPoints)
	{
		//if the actual level = the displayed level
		if (actualLevel == Convert.ToInt32(this.attributeLevel.text))
		{
			//animate bar up to actualPoints
			while(actualPoints > attributePointsProgress.value)
			{
				attributePointsProgress.value += pointDelta;
				yield return new WaitForSeconds(timeToAnimatePoint*pointDelta);
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
					attributePointsProgress.value += pointDelta;
					yield return new WaitForSeconds(timeToAnimatePoint*pointDelta);
				}
				attributePointsProgress.value = 0;
				attributePointsProgress.maxValue ++;
				attributeLevel.text = (Convert.ToInt32(this.attributeLevel.text) + 1).ToString();
			}

			while(attributePointsProgress.value < actualPoints)
			{
				attributePointsProgress.value += pointDelta;
				yield return new WaitForSeconds(timeToAnimatePoint*pointDelta);
			}
		}
	}
}
