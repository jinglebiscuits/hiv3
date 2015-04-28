using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Person : MonoBehaviour{

	private string name;
	private BodyType bodyType;

	private BaseAttributes baseAttributes = new BaseAttributes();
	private BaseStatuses baseStatuses = new BaseStatuses();
	private BaseItems baseItems = new BaseItems();
	private BaseStorylines baseStorylines = new BaseStorylines();
	private BaseRelationships baseRelationships = new BaseRelationships();
	private List<IQuality> qualities = new List<IQuality>();
	private Clock clock;
	private Day day;
	private Week week;

	private Forest forest;
	private List<Trunk> availableTrunks;

	public Person()
	{
		bodyType = BodyType.female;
		foreach(IQuality attribute in baseAttributes.attributes)
		{
			qualities.Add (attribute);
		}

		foreach(IQuality status in baseStatuses.statuses)
		{
			qualities.Add (status);
		}

		foreach(IQuality item in baseItems.items)
		{
			qualities.Add (item);
		}

		foreach(IQuality storyline in baseStorylines.storylines)
		{
			qualities.Add (storyline);
		}

		foreach(IQuality relationship in baseRelationships.relationships)
		{
			qualities.Add (relationship);
		}

		clock = new Clock(14);
		qualities.Add (clock);

		day = new Day(6);
		qualities.Add (day);

		week = new Week(0);
		qualities.Add (week);

		forest = new Forest();
		availableTrunks = new List<Trunk>();
//		UpdateAvailableTrunkList();

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

	public List<IQuality> Qualities {
		get {
			return this.qualities;
		}
		set {
			qualities = value;
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

	public void UpdateAvailableTrunkList(List<Trunk> trunks)
	{
		availableTrunks.Clear();
		//availableTrunks = forest.FetchAvailableTrunks(this);
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
}

public enum BodyType
{
	male,
	female
}