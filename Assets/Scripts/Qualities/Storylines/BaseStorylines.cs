﻿using System;

[Serializable]
/// <summary>
/// Base storylines. To use a new storyline, create a new Storyline class and make sure its name matches the XML tag you use.
/// Add the new Storyline to storylines and the Person class will handle the rest.
/// </summary>
public class BaseStorylines {
	
	public Storyline intro = new Storyline("Intro", "Rested and ready to go!", 0, 0, false);
	public Storyline chapterOne = new Storyline("Chapter 1", "Either I will find a way, or I will make a way.", 0, 0, false);
	public Storyline chapterTwo = new Storyline("Chapter 2", "You can do it!", 0, 0, false);
	public Storyline chapterThree = new Storyline("Chapter 3", "Aching head, scratchy throat. Today will be tough", 0, 0, false);
	public Storyline chapterFour = new Storyline("Chapter 4", "What matters anymore?", 0, 0, false);
	public Storyline chapterFive = new Storyline("Chapter 5", "How can I win when the rules have been written by my opponent?", 0, 0, false);
	public Storyline chapterSix = new Storyline("Chapter 6", "Your health might be compromised.", 0, 0, false);
	public Storyline chapterSeven = new Storyline("Chapter 7", "Doubt takes over as you begin questioning your ability to perform even simple tasks.", 0, 0, false);

	public Storyline party = new Storyline("Party", "Party time!", 0, 0, false);
    public Storyline basketballGame = new Storyline("Basketball Game", "Big ol' game", 0, 0, false);
    public Storyline bus = new Storyline("Bus", "Drama on the bus", 0, 0, false);
	public Storyline facebook = new Storyline("Facebook", "Drama on Facebook", 0, 0, false);

	public Storyline[] storylines;
	
	public BaseStorylines()
	{
		storylines = new Storyline[]{intro, chapterOne, chapterTwo, chapterThree, chapterFour, chapterFive, chapterSix, chapterSeven, party, basketballGame, bus, facebook};
	}
}
