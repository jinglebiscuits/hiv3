public class BaseAttributes {

	public Attribute intelligence = new Attribute("Intelligence", "You've got a brain!", 1, 0, true);
	public Attribute physical = new Attribute("Physical", "If you don't take care of your body, where are you going to live?", 1, 0, true);
	public Attribute social = new Attribute("Social", "Make some friends!", 1, 0, true);
	public Attribute mettle = new Attribute("Mettle", "When the going gets tough, the tough get going.", 1, 0, true);

	public Attribute[] attributes;

	public BaseAttributes()
	{
		attributes = new Attribute[]{intelligence, physical, social, mettle};
	}
}
