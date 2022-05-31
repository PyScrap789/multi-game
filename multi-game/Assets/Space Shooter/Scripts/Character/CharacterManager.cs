using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
	public CharacterDatabase characterDatabase;

	public TMP_Text nameText;
	public SpriteRenderer artworkSprite;

	int selectedOption = 0;

	private void Start()
	{
		if (!PlayerPrefs.HasKey("selectedOption"))
		{
			selectedOption = 0;
		}
		else
		{
			Load();
		}
	}

	public void NextOption()
	{
		selectedOption++;

		if(selectedOption >= characterDatabase.CharacterCount)
		{
			selectedOption = 0;
		}

		UpdateCharacter(selectedOption);
		Save();
	}

	public void PreviousOption()
	{
		selectedOption--;

		if(selectedOption < 0)
		{
			selectedOption = characterDatabase.CharacterCount - 1;
		}

		UpdateCharacter(selectedOption);
		Save();
	}

	private void UpdateCharacter(int selectedOption)
	{
		Character character = characterDatabase.GetCharacter(selectedOption);
		artworkSprite.sprite = character.characterSprite.GetComponent<SpriteRenderer>().sprite;
		nameText.text = character.characterName;
	}

	private void Load()
	{
		selectedOption = PlayerPrefs.GetInt("selectedOption");
	}

	private void Save()
	{
		PlayerPrefs.SetInt("selectedOption", selectedOption);
	}
}
