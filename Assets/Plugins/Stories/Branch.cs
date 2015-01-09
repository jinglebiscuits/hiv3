using System.Collections.Generic;
using System.Collections;

/// <summary>
/// A Branch represents a possible path from a Trunk. Branches need unique names within their story trees.
/// </summary>
public class Branch : Story {

	private Result defaultResult;
	private Result successResult;
	private Story linkedEvent;

	override public bool Requirements(Person person)
	{
		return true;
	}
}
