using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum Gender
{
	Male,
	Female

}
[Serializable]
public class PortraitsCollection
{
	public Texture2D normal;
	public Texture2D surprised;

}
[CreateAssetMenu(menuName = "Data/NPC Character")]
public class NPCDefinition : ScriptableObject
{
	public string Name = "Nameless";
	public Gender gender = Gender.Male;
}
