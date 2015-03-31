﻿public class BaseStatuses {

	public Status wellRested = new Status("Well Rested", "Rested and ready to go!", 0, 0, 1, false);
	public Status motivated = new Status("Motivated", "Either I will find a way, or I will make a way.", 0, 0, 1, false);
	public Status confident = new Status("Confident", "You can do it!", 0, 0, 1, false);
	public Status sick = new Status("Sick", "Aching head, scratchy throat. Today will be tough", 0, 0, 1, false);
	public Status heartbroken = new Status("Heartbroken", "What matters anymore?", 0, 0, 1, false);
	public Status angry = new Status("Angry", "How can I win when the rules have been written by my opponent?", 0, 0, 1, false);
	public Status atRisk = new Status("At Risk", "Your health might be compromised.", 0, 0, 1, false);
	public Status insecure = new Status("Insecure", "Doubt takes over as you begin questioning your ability to perform even simple tasks.", 0, 0, 1, false);
	public Status introComplete = new Status("Intro Complete", "You're on your way!", 0, 0, 1, false);

	public Status[] statuses;

	public BaseStatuses()
	{
		statuses = new Status[]{wellRested, motivated, confident, sick, heartbroken, angry, atRisk, insecure, introComplete};
	}
}