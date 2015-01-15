using System;
using System.Collections;
using System.Collections.Generic;

public class Person {

	private BaseAttributes baseAttributes = new BaseAttributes();
	private Status[] statuses = new Status[8];
	private List<IQuality> qualities = new List<IQuality>();
	private Clock clock;

	public Person()
	{
		foreach(IQuality attribute in baseAttributes.attributes)
		{
			qualities.Add (attribute);
		}

		foreach(IQuality status in statuses)
		{
			qualities.Add (status);
		}

		clock = new Clock(8);
	}

	public BaseAttributes BaseAttributes {
		get {
			return this.baseAttributes;
		}
		set {
			baseAttributes = value;
		}
	}

	public Status[] Statuses {
		get {
			return this.statuses;
		}
		set {
			statuses = value;
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
}

public enum AttributeType
{
	intelligence,
	physical,
	social,
	mettle
};