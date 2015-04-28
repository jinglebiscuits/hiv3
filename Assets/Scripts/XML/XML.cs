using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

public class XML : MonoBehaviour{

	public XDocument xDoc;
	public TextAsset[] storiesXML;
	public List<Trunk> trunks = new List<Trunk>();

	void Awake()
	{
		foreach(TextAsset xmlText in storiesXML)
		{
			xDoc = XDocument.Parse(xmlText.text);
			foreach(XElement trunk in xDoc.Descendants("trunk"))
			{
				trunks.Add(ElementToTrunk(trunk));
				//Not all trunks have requirements
				if(trunk.Element("requirements").Value != "")
				{
					foreach(XElement requirement in trunk.Element("requirements").Descendants("requirement"))
					{
						trunks.Last().Requirements.Add(ElementToRequirement(requirement));
					}
				}
				
				//All trunks have at least one default branch
				foreach(XElement branch in trunk.Element("branches").Descendants("branch"))
				{
					trunks.Last ().Branches.Add(ElementToBranch(branch));
				}
			}
		}
	}

	private Trunk ElementToTrunk(XElement eTrunk)
	{
		Trunk trunk = new Trunk(
			eTrunk.Element("title").Value,
			eTrunk.Element("description").Value,
			eTrunk.Element("icon").Value,
			eTrunk.Element("buttonText").Value,
			new List<Requirement>(),
			eTrunk.Element("trunkTag").Value,
			eTrunk.Element("area").Value,
			eTrunk.Element("urgency").Value,
			eTrunk.Element("deck").Value,
			new List<Branch>());
		return trunk;
	}

	private Branch ElementToBranch(XElement eBranch)
	{
		Branch branch = new Branch();
		branch.Title = eBranch.Element("title").Value;
		branch.Description = eBranch.Element("description").Value;
		branch.Icon = eBranch.Element("icon").Value;
		branch.ButtonText = eBranch.Element("buttonText").Value;
		branch.Difficulty = int.Parse(eBranch.Element("difficulty").Value);

		//Not all branches have requirements
		if(eBranch.Element("requirements").Value != "")
		{
			foreach(XElement requirement in eBranch.Element("requirements").Descendants("requirement"))
			{
				branch.Requirements.Add(ElementToRequirement(requirement));
			}
		}

		//All branches have a defaultResult
		branch.DefaultResult = ElementToResult(eBranch.Element("defaultResult"));
		if(eBranch.Element("successResult") != null)
		{
			if(eBranch.Element("successResult").Value != "")
			{
				branch.SuccessResult = ElementToResult(eBranch.Element("successResult"));
			}
		}

		if(eBranch.Element("testedQualities").Value != "")
		{
			foreach(XElement testedQuality in eBranch.Element("testedQualities").Descendants("quality"))
			{
				branch.TestedQualities.Add(ElementToQuality(testedQuality));
			}
		}
		return branch;
	}

	private Requirement ElementToRequirement(XElement requirement)
	{
		IQuality quality = ElementToQuality(requirement.Element("quality"));
		int min = int.Parse(requirement.Element("qualityMin").Value);
		int max = int.Parse (requirement.Element("qualityMax").Value);

		return new Requirement(quality, min, max);
	}

	private Result ElementToResult(XElement eResult)
	{
		Result result = new Result();
		result.Title = eResult.Element("title").Value;
		result.Description = eResult.Element("description").Value;
		result.TimeCost = int.Parse(eResult.Element("timeCost").Value);

		foreach(XElement effect in eResult.Descendants("effect"))
		{
			IQuality quality = ElementToQuality(effect.Element("quality"));
			result.Effects.Add (new Effect(quality, int.Parse(effect.Element("changedBy").Value)));
		}
		return result;
	}

	private IQuality ElementToQuality(XElement eQuality)
	{
		IQuality quality = null;
		string caseSwitch = eQuality.Descendants().First().Name.ToString();
		switch (caseSwitch)
		{
			case "attributeQuality":
				quality = new Attribute(eQuality.Value);
				break;
			case "statusQuality":
				quality = new Status(eQuality.Value);
				break;
			case "itemQuality":
				quality = new Item(eQuality.Value);
				break;
			case "timeQuality":
				quality = new Clock(eQuality.Value);
				break;
			case "storylineQuality":
				quality = new Storyline(eQuality.Value);
				break;
			case "relationshipQuality":
				quality = new Relationship(eQuality.Value);
				break;
			default:
				Debug.Log("unknown quality type");
				break;
		}

		return quality;
	}
}
