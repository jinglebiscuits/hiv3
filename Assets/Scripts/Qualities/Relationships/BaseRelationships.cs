public class BaseRelationships {

	public Relationship auntKelly = new Relationship("Auntie Gina", "Everything is normal", 0, 0, 1, true);
	public Relationship uncleRicky = new Relationship("Uncle Harry", "Everything is normal", 0, 0, 1, true);
	public Relationship james = new Relationship("Jimmy", "Everything is normal", 0, 0, 1, true);
	public Relationship joseph = new Relationship("Jay Jay", "Everything is normal", 0, 0, 1, true);
	public Relationship jayne = new Relationship("Tia", "Everything is normal", 0, 0, 1, true);
	public Relationship catherine = new Relationship("Monique", "Everything is normal", 0, 0, 1, true);
	public Relationship mrsLake = new Relationship("Mrs. Lake", "Everything is normal", 0, 0, 1, true);
	public Relationship coachWoodfin = new Relationship("Coach Woodfin", "Everything is normal", 0, 0, 1, true);
	public Relationship nurseRoberts = new Relationship("Nurse Roberts", "Everything is normal", 0, 0, 1, true);

	public Relationship[] relationships;

	public BaseRelationships ()
	{
		relationships = new Relationship[]{auntKelly, uncleRicky, james, joseph, jayne, catherine, mrsLake, coachWoodfin, nurseRoberts};
	}
	
}
