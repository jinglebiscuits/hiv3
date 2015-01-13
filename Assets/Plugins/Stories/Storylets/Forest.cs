﻿using System.Collections;
using System.Collections.Generic;

public class Forest {

	public List<Trunk> trunks = new List<Trunk>();

	public Forest ()
	{
		for (int i = 0; i < 10; i++)
		{
			trunks.Add (new Trunk());
		}
		trunks[0].Requirements.Add(new Requirement(new Attribute("Intelligence"), 0, 6));
		trunks[1].Requirements.Add(new Requirement(new Attribute("Intelligence"), 6, 8));
		trunks[2].Requirements.Add(new Requirement(new Attribute("Intelligence"), 8, 10));
		trunks[3].Requirements.Add(new Requirement(new Attribute("Social"), 0, 6));
		trunks[4].Requirements.Add(new Requirement(new Attribute("Social"), 6, 7));
		trunks[5].Requirements.Add(new Requirement(new Attribute("Social"), 8, 11));
		trunks[6].Requirements.Add(new Requirement(new Attribute("Physical"), 0, 8));
		trunks[7].Requirements.Add(new Requirement(new Attribute("Physical"), 5, 10));
		trunks[8].Requirements.Add(new Requirement(new Attribute("Physical"), 8, 12));
		trunks[9].Requirements.Add(new Requirement(new Attribute("Mettle"), 0, 10));
	}
	
}
