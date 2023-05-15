using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TalkInteract : Interactable
{
	[SerializeField] DialogueContainer dialogue;
	
	public override void Interact(Character character)
	{
		GameManager.instance.dialogueSystem.Initialize(dialogue);
		
	}
}
