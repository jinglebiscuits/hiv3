using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

public class XML : MonoBehaviour
{

    public XDocument xDoc;
    public TextAsset[] storiesXML;
    public List<Trunk> trunks = new List<Trunk>();

    void OnLevelWasLoaded(int level)
    {
        if (Application.loadedLevelName.Equals("Main") && trunks.Count == 0) {
            foreach (TextAsset xmlText in storiesXML)
            {
                xDoc = XDocument.Parse(xmlText.text);
                foreach (XElement trunk in xDoc.Descendants("trunk"))
                {
                    trunks.Add(ElementToTrunk(trunk));
                    //Not all trunks have requirements
                    if (trunk.Element("requirements").Value != "")
                    {
                        foreach (XElement requirement in trunk.Element("requirements").Descendants("requirement"))
                        {
                            trunks.Last().Requirements.Add(ElementToRequirement(requirement));
                        }
                    }
                    
                    //All trunks have at least one default branch
                    foreach (XElement branch in trunk.Element("branches").Descendants("branch"))
                    {
                        trunks.Last().Branches.Add(ElementToBranch(branch));
                    }
                }
            }
        }
    }

    private Trunk ElementToTrunk(XElement eTrunk)
    {
        Trunk trunk = new Trunk(
            ReplaceStrings(eTrunk.Element("title").Value),
            ReplaceStrings(eTrunk.Element("description").Value),
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
        branch.Title = ReplaceStrings(eBranch.Element("title").Value);
        branch.Description = ReplaceStrings(eBranch.Element("description").Value);
        branch.Icon = eBranch.Element("icon").Value;
        branch.ButtonText = eBranch.Element("buttonText").Value;
        branch.Difficulty = int.Parse(eBranch.Element("difficulty").Value);

        //Not all branches have requirements
        if (eBranch.Element("requirements").Value != "")
        {
            foreach (XElement requirement in eBranch.Element("requirements").Descendants("requirement"))
            {
                branch.Requirements.Add(ElementToRequirement(requirement));
            }
        }

        //Not all branches have travelToArea
        if (eBranch.Element("travelToArea") != null)
        {
            branch.TravelToArea = eBranch.Element("travelToArea").Value;
        }

        //All branches have a defaultResult
        branch.DefaultResult = ElementToResult(eBranch.Element("defaultResult"));
        if (eBranch.Element("successResult") != null)
        {
            if (eBranch.Element("successResult").Value != "")
            {
                branch.SuccessResult = ElementToResult(eBranch.Element("successResult"));
            }
        }

        if (eBranch.Element("testedQualities").Value != "")
        {
            foreach (XElement testedQuality in eBranch.Element("testedQualities").Descendants("quality"))
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
        int max = int.Parse(requirement.Element("qualityMax").Value);

        return new Requirement(quality, min, max);
    }

    private Result ElementToResult(XElement eResult)
    {
        Result result = new Result();
        result.Title = ReplaceStrings(eResult.Element("title").Value);
        result.Description = ReplaceStrings(eResult.Element("description").Value);
        result.TimeCost = int.Parse(eResult.Element("timeCost").Value);

        foreach (XElement effect in eResult.Descendants("effect"))
        {
            IQuality quality = ElementToQuality(effect.Element("quality"));
            if (effect.Element("changedBy") != null)
                result.Effects.Add(new Effect(quality, int.Parse(effect.Element("changedBy").Value), 169));
            else
            {
                result.Effects.Add(new Effect(quality, 169, int.Parse(effect.Element("setTo").Value)));
            }
            if (effect.Element("show").Value == "false")
                result.Effects.Last().Show = false;
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
            case "skillQuality":
                quality = new Skill(eQuality.Value);
                break;
            case "itemQuality":
                quality = new Item(eQuality.Value);
                break;
            case "schoolQuality":
                switch (eQuality.Value)
                {
                    case "Homework":
                        quality = new Homework();
                        break;
                    default:
                        Debug.Log("unknown quality type");
                        break;
                }
                break;
            case "timeQuality":
                switch (eQuality.Value)
                {
                    case "Time":
                        quality = new Clock();
                        break;
                    case "Day":
                        quality = new Day();
                        break;
                    case "Week":
                        quality = new Week();
                        break;
                    default:
                        Debug.Log("unknown quality type");
                        break;
                }
                break;
            case "storylineQuality":
                quality = new Storyline(eQuality.Value);
                break;
            case "relationshipQuality":
                quality = new Relationship(eQuality.Value);
                break;
            case "luckQuality":
                quality = new Attribute(eQuality.Value);
                break;
            default:
                Debug.Log("unknown quality type");
                break;
        }

        return quality;
    }
    
    private string ReplaceStrings(string input) {
        Person person = Player.player.FocusedPerson;
        input = input.Replace("[AT]", person.Name);
        
        if (person.BodyType == BodyType.female) {
            input = input.Replace("[his]", "her");
            input = input.Replace("[he]", "she");
            input = input.Replace("[him]", "her");
            input = input.Replace("[himself]", "herself");
        } else {
            input = input.Replace("[", "");
            input = input.Replace("]", "");
        }
        return input;
    }
}
