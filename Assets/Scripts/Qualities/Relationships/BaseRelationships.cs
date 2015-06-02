public class BaseRelationships {

	public Relationship auntieGina = new Relationship("Auntie Gina", "Everything is normal", 0, 0, 1, true);
	public Relationship uncleHarry = new Relationship("Uncle Harry", "Everything is normal", 0, 0, 1, true);
	public Relationship jimmy = new Relationship("Jimmy", "Everything is normal", 0, 0, 1, true);
	public Relationship jayJay = new Relationship("Jay Jay", "Everything is normal", 0, 0, 1, true);
	public Relationship tia = new Relationship("Tia", "Everything is normal", 0, 0, 1, true);
	public Relationship monique = new Relationship("Monique", "Everything is normal", 0, 0, 1, true);
	public Relationship mrsLake = new Relationship("Mrs. Lake", "Everything is normal", 0, 0, 1, true);
	public Relationship coachWoodfin = new Relationship("Coach Woodfin", "Everything is normal", 0, 0, 1, true);
	public Relationship nurseRoberts = new Relationship("Nurse Roberts", "Everything is normal", 0, 0, 1, true);

	public Relationship[] relationships;

	public BaseRelationships ()
	{
		relationships = new Relationship[]{auntieGina, uncleHarry, jimmy, jayJay, tia, monique, mrsLake, coachWoodfin, nurseRoberts};
	}
	
}
