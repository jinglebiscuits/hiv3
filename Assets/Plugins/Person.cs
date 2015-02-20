using System;
using System.Collections;
using System.Collections.Generic;

public class Person {

	private string name;

	private BaseAttributes baseAttributes = new BaseAttributes();
	private BaseStatuses baseStatuses = new BaseStatuses();
	private BaseItems baseItems = new BaseItems();
	private List<IQuality> qualities = new List<IQuality>();
	private Clock clock;

	private Forest forest;
	private List<Trunk> availableTrunks;

	public Person()
	{
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

		clock = new Clock(8);
		qualities.Add (clock);

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