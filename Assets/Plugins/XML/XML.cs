using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

public class XML : MonoBehaviour{

	public XDocument xDoc;
	public TextAsset storiesXML;
	public List<Trunk> trunks = new List<Trunk>();

	void Awake()
	{
		xDoc = XDocument.Parse(storiesXML.text);
		var result = from q in xDoc.Descendants("trunk")
			select new Trunk
				{
					Title = q.Element("title").Value,
					Description = q.Element("description").Value,
					Icon = q.Element("icon").Value,
					ButtonText = q.Element("buttonText").Value,
					TrunkTag = q.Element("trunkTag").Value,
					Area = q.Element("area").Value,
					Urgency = q.Element("urgency").Value,
					Deck = q.Element("deck").Value
				};

		foreach(XElement trunk in xDoc.Descendants("trunk"))
		{
			trunks.Add(new Trunk(
				trunk.Element("title").Value,
				trunk.Element("description").Value,
				trunk.Element("icon").Value,
				trunk.Element("buttonText").Value,
				new List<Requirement>(),
				trunk.Element("trunkTag").Value,
				trunk.Element("area").Value,
				trunk.Element("urgency").Value,
				trunk.Element("deck").Value,
				new List<Branch>()));

			if(trunk.Element("requirements").Value != "")
			{

				foreach(XElement requirement in trunk.Element("requirements").Descendants("requirement"))
				{
					trunks.Last().Requirements.Add(ElementToRequirement(requirement));
				}
			}
			foreach(XElement branch in trunk.Element("branches").Descendants("branch"))
			{
				trunks.Last ().Branches.Add(ElementToBranch(branch));

			}
		}
	}

	private Branch ElementToBranch(XElement eBranch)
	{
		Branch branch = new Branch();
		branch.Title = eBranch.Element("title").Value;
		branch.Description = eBranch.Element("description").Value;
		branch.Icon = eBranch.Element("icon").Value;
		branch.ButtonText = eBranch.Element("buttonText").Value;
		foreach(XElement requirement in eBranch.Element("requirements").Descendants("requirement"))
		{
			branch.Requirements.Add(ElementToRequirement(requirement));
		}

		branch.DefaultResult = ElementToResult(eBranch.Element("defaultResult"));

		return branch;
	}

	private Requirement ElementToRequirement(XElement requirement)
	{
		IQuality quality = MatchQuality(requirement);
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
			IQuality quality = MatchQuality(effect);
			result.Effects.Add (new Effect(quality, int.Parse(effect.Element("changedBy").Value)));
			print ("effected quality is " + quality.Name);
		}
		return result;
	}

	private IQuality MatchQuality(XElement element)
	{
		IQuality quality = null;
		string caseSwitch = element.Element("quality").Descendants().First().Name.ToString();
		switch (caseSwitch)
		{
			case "attributeQuality":
			quality = new Attribute(element.Element("quality").Value);
			break;
			case "statusQuality":
			quality = new Status(element.Element("quality").Value);
			break;
			case "itemQuality":
			print ("item");
			quality = new Item(element.Element("quality").Value);
			break;
			case "timeQuality":
			quality = new Clock(element.Element("quality").Value);
			break;
			default:
			print ("unknown quality type");
			break;
		}

		return quality;
	}
}
