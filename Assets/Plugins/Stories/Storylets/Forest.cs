using System.Collections;
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

		trunks[0].Branches.Add(new Branch());
		trunks[0].Title = "First Mission!";
		trunks[0].Branches[0].DefaultResult = new Result("Oh yeah", "You done good", new Attribute("Intelligence"), 1);

		trunks[1].Branches.Add(new Branch());
		trunks[1].Title = "Second Mission!";
		trunks[1].Branches[0].DefaultResult = new Result("Oh yeah", "You done good", new Attribute("Intelligence"), 1);

		trunks[2].Branches.Add(new Branch());
		trunks[2].Title = "Third Mission!";
		trunks[2].Branches[0].DefaultResult = new Result("Oh yeah", "You done good", new Attribute("Intelligence"), 1);

		trunks[3].Branches.Add(new Branch());
		trunks[3].Title = "Fourth Mission!";
		trunks[3].Branches[0].DefaultResult = new Result("Oh yeah", "You done good", new Attribute("Social"), 1);
	}
	
}
