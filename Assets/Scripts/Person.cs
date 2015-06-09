using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Person {

	private string name;
	private string area;
	private BodyType bodyType;

	private BaseAttributes baseAttributes = new BaseAttributes();
	private BaseStatuses baseStatuses = new BaseStatuses();
	private BaseItems baseItems = new BaseItems();
	private BaseStorylines baseStorylines = new BaseStorylines();
	private BaseRelationships baseRelationships = new BaseRelationships();
    private BaseSkills baseSkills = new BaseSkills();
	private Dictionary<string, IQuality> qualitiesDict = new Dictionary<string, IQuality>();
	private Clock clock;
	private Day day;
	private Week week;
	private Homework homework;
    private Luck luck;

	private Forest forest;
	private List<Trunk> availableTrunks;

	public Person()
	{
		bodyType = BodyType.female;
		foreach(IQuality attribute in baseAttributes.attributes)
		{
			qualitiesDict.Add(attribute.Name, attribute);
		}
		Debug.Log (qualitiesDict["Intelligence"].Name);
		foreach(Status status in baseStatuses.statuses)
		{
			qualitiesDict.Add(status.Name, status);
			status.levelEvent -= UpdateStatus;
			status.levelEvent += UpdateStatus;
		}

		foreach(IQuality item in baseItems.items)
		{
			qualitiesDict.Add(item.Name, item);
		}

		foreach(IQuality storyline in baseStorylines.storylines)
		{
			qualitiesDict.Add(storyline.Name, storyline);
		}

		foreach(IQuality relationship in baseRelationships.relationships)
		{
			qualitiesDict.Add(relationship.Name, relationship);
		}

        foreach(IQuality skill in baseSkills.skills)
        {
            qualitiesDict.Add(skill.Name, skill);
        }

		clock = new Clock(14);
		qualitiesDict.Add(clock.Name, clock);

		day = new Day(6);
		qualitiesDict.Add(day.Name, day);

		week = new Week(0);
		qualitiesDict.Add(week.Name, week);

		homework = new Homework("Homework", "Affects your GPA on Monday mornings", 0, 0, false);
        qualitiesDict.Add(homework.Name, homework);

        luck = new Luck("How lucky are you?", 5, 0, false);

		forest = new Forest();
		availableTrunks = new List<Trunk>();

		area = "Home";
	}

	#region Accessor Methods
	public string Name {
		get {
			return this.name;
		}
		set {
			name = value;
		}
	}

	public BodyType BodyType {
		get {
			return this.bodyType;
		}
		set {
			bodyType = value;
		}
	}

	public string Area {
		get {
			return this.area;
		}
		set {
			area = value;
		}
	}

	public BaseAttributes BaseAttributes {
		get {
			return this.baseAttributes;
		}
		set {
			baseAttributes = value;
		}
	}

	public BaseStatuses BaseStatuses {
		get {
			return this.baseStatuses;
		}
		set {
			baseStatuses = value;
		}
	}

	public BaseStorylines BaseStorylines {
		get {
			return this.baseStorylines;
		}
		set {
			baseStorylines = value;
		}
	}

	public Dictionary<string, IQuality> QualitiesDict {
		get {
			return this.qualitiesDict;
		}
		set {
			qualitiesDict = value;
		}
	}

	public Clock Clock {
		get {
			return this.clock;
		}
		set {
			clock = value;
		}
	}

	public Day Day {
		get {
			return this.day;
		}
		set {
			day = value;
		}
	}

	public Week Week {
		get {
			return this.week;
		}
		set {
			week = value;
		}
	}

	public List<Trunk> AvailableTrunks {
		get {
			return this.availableTrunks;
		}
		set {
			availableTrunks = value;
		}
	}
	#endregion

	void OnDestroy()
	{

	}

	public void UpdateAvailableTrunkList(List<Trunk> trunks)
	{
		availableTrunks.Clear();
		availableTrunks = FetchAvailableTrunks(trunks);
	}

	public List<Trunk> FetchAvailableTrunks(List<Trunk> trunks)
	{
		List<Trunk> availableTrunks = new List<Trunk>();
		foreach(Trunk trunk in trunks)
		{
			if(trunk.IsPlayableByPerson(this)){
				availableTrunks.Add(trunk);
			}
		}
		return availableTrunks;
	}

	public void UpdateStatus(Status status)
	{
		Debug.Log (status.Name);
		(qualitiesDict["Intelligence"] as Attribute).Modifier += status.ModDictionary["Intelligence"] * status.Level - status.ModDictionary["Intelligence"] * status.OldLevel;
		(qualitiesDict["Physical"] as Attribute).Modifier += status.ModDictionary["Physical"] * status.Level - status.ModDictionary["Physical"] * status.OldLevel;
		(qualitiesDict["Social"] as Attribute).Modifier += status.ModDictionary["Social"] * status.Level - status.ModDictionary["Social"] * status.OldLevel;;
		(qualitiesDict["Mettle"] as Attribute).Modifier += status.ModDictionary["Mettle"] * status.Level - status.ModDictionary["Mettle"] * status.OldLevel;;
	}
}

public enum BodyType
{
	male,
	female
}