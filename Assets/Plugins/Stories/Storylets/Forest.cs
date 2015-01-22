using System.Collections;
using System.Collections.Generic;

public class Forest {

	private List<Trunk> trunks = new List<Trunk>();

	public Forest ()
	{
		for (int i = 0; i < 10; i++)
		{
			Trunk t = new Trunk();
			t.ButtonText = "Go";
			trunks.Add (t);
		}
		trunks[0].Requirements.Add(new Requirement(new Attribute("Intelligence"), 0, 6));
		trunks[1].Requirements.Add(new Requirement(new Attribute("Intelligence"), 6, 8));
		trunks[2].Requirements.Add(new Requirement(new Attribute("Intelligence"), 8, 10));
		trunks[2].Requirements.Add(new Requirement(new Attribute("Social"), 7, 10));
		trunks[3].Requirements.Add(new Requirement(new Attribute("Social"), 0, 6));
		trunks[4].Requirements.Add(new Requirement(new Attribute("Social"), 6, 7));
		trunks[5].Requirements.Add(new Requirement(new Attribute("Social"), 8, 11));
		trunks[6].Requirements.Add(new Requirement(new Attribute("Physical"), 0, 8));
		trunks[7].Requirements.Add(new Requirement(new Attribute("Physical"), 5, 10));
		trunks[8].Requirements.Add(new Requirement(new Attribute("Physical"), 8, 12));
		trunks[9].Requirements.Add(new Requirement(new Attribute("Mettle"), 0, 10));

		trunks[0].Branches.Add(new Branch());
		trunks[0].Title = "Study";
		trunks[0].Branches[0].DefaultResult = new Result("Oh yeah", "You done good", new Attribute("Intelligence"), 1);

		trunks[1].Branches.Add(new Branch());
		trunks[1].Title = "Homework Time";
		trunks[1].Branches[0].DefaultResult = new Result("Oh yeah", "You done good", new Attribute("Intelligence"), 1);
		trunks[1].Requirements.Add(new Requirement(new Clock(1), 15, 23));

		trunks[2].Branches.Add(new Branch());
		trunks[2].Title = "Group Study";
		trunks[2].Branches[0].DefaultResult = new Result("Oh yeah", "You done good", new Attribute("Intelligence"), 1);

		trunks[3].Branches.Add(new Branch());
		trunks[3].Title = "Strike up a conversation.";
		trunks[3].Branches[0].DefaultResult = new Result("Oh yeah", "You done good", new Attribute("Social"), 1);

		trunks[4].Branches.Add(new Branch());
		trunks[4].Title = "Text a friend.";
		trunks[4].Branches[0].DefaultResult = new Result("Oh yeah", "You done good", new Attribute("Social"), 1);

		trunks[5].Branches.Add(new Branch());
		trunks[5].Title = "Ask a friend about their goals.";
		trunks[5].Branches[0].DefaultResult = new Result("Oh yeah", "You done good", new Attribute("Social"), 1);

		trunks[6].Branches.Add(new Branch());
		trunks[6].Title = "Go jogging.";
		trunks[6].Branches[0].DefaultResult = new Result("Oh yeah", "You done good", new Attribute("Physical"), 1);

		trunks[7].Branches.Add(new Branch());
		trunks[7].Title = "Practice basketball.";
		trunks[7].Branches[0].DefaultResult = new Result("Oh yeah", "You done good", new Attribute("Physical"), 1);

		trunks[8].Branches.Add(new Branch());
		trunks[8].Title = "Team Practice";
		trunks[8].Branches[0].DefaultResult = new Result("Oh yeah", "You done good", new Attribute("Physical"), 1);

		trunks[9].Branches.Add(new Branch());
		trunks[9].Title = "Go for a quiet walk.";
		trunks[9].Branches[0].DefaultResult = new Result("Oh yeah", "You done good", new Attribute("Mettle"), 1);
	}

	#region Accessor Methods
//	public List<Trunk> Trunks {
//		get {
//			return this.trunks;
//		}
//		set {
//			trunks = value;
//		}
//	}
	#endregion

	public List<Trunk> FetchAvailableTrunks(Person person)
	{
		List<Trunk> availableTrunks = new List<Trunk>();
		foreach(Trunk trunk in trunks)
		{
			if(trunk.IsPlayableByPerson(person)){
				availableTrunks.Add(trunk);
			}
		}
		return availableTrunks;
	}


}
