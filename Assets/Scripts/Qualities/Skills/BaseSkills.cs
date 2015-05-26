public class BaseSkills {
    
    public Skill welding = new Skill("Welding", "That's the ticket", 0, 0, true);
    public Skill electrician = new Skill("Electrician", "That's the ticket", 0, 0, true);
    public Skill carpentry = new Skill("Carpentry", "That's the ticket", 0, 0, true);
    public Skill autoMechanic = new Skill("Auto Mechanic", "That's the ticket", 0, 0, true);
    public Skill hairDresser = new Skill("Hair Dresser", "That's the ticket", 0, 0, true);
    public Skill cosmetology = new Skill("Cosmetology", "That's the ticket", 0, 0, true);
    public Skill manicurist = new Skill("Manicurist", "That's the ticket", 0, 0, true);
    public Skill babysitting = new Skill("Babysitting", "That's the ticket", 0, 0, true);
    public Skill chess = new Skill("Chess", "That's the ticket", 0, 0, true);
    public Skill art = new Skill("Art", "That's the ticket", 0, 0, true);
    public Skill music = new Skill("Music", "That's the ticket", 0, 0, true);
    public Skill basketball = new Skill("Basketball", "That's the ticket", 0, 0, true);
    public Skill football = new Skill("Football", "That's the ticket", 0, 0, true);
    
    public Skill[] skills;
    
    public BaseSkills()
    {
        skills = new Skill[]{welding, electrician, carpentry, autoMechanic, hairDresser, cosmetology, manicurist, babysitting, chess, art, music, basketball, football};
    }
}
