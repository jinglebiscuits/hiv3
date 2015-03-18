using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	private Person focusedPerson;
	public AvatarView avatarView;

	public static Player player;

	void Awake ()
	{
		if(player == null)
		{
			DontDestroyOnLoad(gameObject);
			player = this;
		}
		else if(player != this)
		{
			Destroy(gameObject);
		}

		if(focusedPerson == null)
		{
			DefaultSetup();
		}
	}

	public Person FocusedPerson {
		get {
			return this.focusedPerson;
		}
		set {
			focusedPerson = value;
		}
	}

	public void DefaultSetup()
	{
		Person scott = new Person();
		focusedPerson = scott;
	}

	public void ChangeGender(Toggle maleToggle)
	{
		if(focusedPerson.BodyType == BodyType.male && !maleToggle.isOn)
		{
			focusedPerson.BodyType = BodyType.female;
		}
		else
			focusedPerson.BodyType = BodyType.male;

		print(focusedPerson.BodyType);
		avatarView.DisplayAppropriateBody(focusedPerson.BodyType);
	}


}
