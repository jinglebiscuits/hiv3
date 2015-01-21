using System;
using System.Collections;
using System.Collections.Generic;

public class Person {

	private BaseAttributes baseAttributes = new BaseAttributes();
	private BaseStatuses baseStatuses = new BaseStatuses();
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

		clock = new Clock(8);
		qualities.Add (clock);

		forest = new Forest();
		availableTrunks = new List<Trunk>();
		UpdateAvailableTrunkList();
	}

	#region Accessor Methods
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

	public void UpdateAvailableTrunkList()
	{
		availableTrunks.Clear();
		availableTrunks = forest.FetchAvailableTrunks(this);
	}
}