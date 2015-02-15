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

	void Start()
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
//				trunks.Last ().Branches.Add(new Branch(branch.Element("title").Value,
//				                                       branch.Element("description").Value,
//				                                       branch.Element("icon").Value,
//				                                       branch.Element("buttonText").Value,

			}
				
//			print (trunk.Element("requirements").Value);
		}

		foreach(Trunk trunk in trunks)
		{
			print (trunk.Title);
		}

//		foreach(Trunk trunk in result)
//		{
//			print (trunk.Icon);
//		}

	}

	private Branch ElemenetToBranch(XElement eBranch)
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


	}

	private Requirement ElementToRequirement(XElement requirement)
	{
		IQuality quality = null;
		string caseSwitch = requirement.Element("quality").Descendants().First().Name.ToString();
		switch (caseSwitch)
		{
		case "attributeQuality":
			print ("att");
			quality = new Attribute(requirement.Element("quality").Value);
			break;
		case "statusQuality":
			print ("stat");
			quality = new Status(requirement.Element("quality").Value);
			break;
			//					case "itemQuality":
			//						print ("item");
			//						quality = new Item(requirement.Element("quality").Value);
			//						break;
		case "timeQuality":
			print("time");
			quality = new Clock(requirement.Element("quality").Value);
			break;
		default:
			print ("unknown quality type");
			break;
		}
		int min = int.Parse(requirement.Element("qualityMin").Value);
		int max = int.Parse (requirement.Element("qualityMax").Value);

		return new Requirement(quality, min, max);
	}
	
}
