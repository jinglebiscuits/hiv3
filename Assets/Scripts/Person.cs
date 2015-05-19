﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Person : MonoBehaviour{

	private string name;
	private string area;
	private BodyType bodyType;

	private BaseAttributes baseAttributes = new BaseAttributes();
	private BaseStatuses baseStatuses = new BaseStatuses();
	private BaseItems baseItems = new BaseItems();
	private BaseStorylines baseStorylines = new BaseStorylines();
	private BaseRelationships baseRelationships = new BaseRelationships();
	private Dictionary<string, IQuality> qualitiesDict = new Dictionary<string, IQuality>();
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
			qualitiesDict.Add(attribute.Name, attribute);
		}

		foreach(IQuality status in baseStatuses.statuses)
		{
			qualitiesDict.Add(status.Name, status);
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

		clock = new Clock(14);
		qualitiesDict.Add(clock.Name, clock);

		day = new Day(6);
		qualitiesDict.Add(day.Name, day);

		week = new Week(0);
		qualitiesDict.Add(week.Name, week);

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

//	public List<IQuality> Qualities {
//		get {
//			return this.qualities;
//		}
//		set {
//			qualities = value;
//		}
//	}

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

	public void UpdateStatus(string statusName, int? setLevel=null, int? levelChange=null)
	{
		Status statusToUpdate = (Status) qualitiesDict[statusName];
		if(setLevel != null)
			statusToUpdate.Level = (int) setLevel;
		else if(levelChange != null)
			statusToUpdate.Level += (int) levelChange;
	}

//	public void UpdateStatuses()
//	{
//		foreach(IQuality quality in qualities)
//		{
//			if(quality.Tag == "Status")
//			{
//				Status status = (Status) quality;
//
//			}
//		}
//	}
}

public enum BodyType
{
	male,
	female
}