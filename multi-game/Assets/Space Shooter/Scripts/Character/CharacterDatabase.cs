using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Database")]
public class CharacterDatabase : ScriptableObject
{
	public List<Character> Characters = new List<Character>();

	public int CharacterCount
	{
		get
		{
			return Characters.Count;
		}
	}

	public Character GetCharacter(int index)
	{
		return Characters[index];
	}
}
