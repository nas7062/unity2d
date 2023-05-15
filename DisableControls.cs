using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableControls : MonoBehaviour
{
    CharacterController2D characterController;
	ToolCharacterMovement toolCharacter;
	InventoryControler inventoryControler;
	ToolbarController toolbarController;
	ItemContainerInterectController itemContainerInterectController;
	private void Awake()
	{
		characterController = GetComponent<CharacterController2D>();
		toolCharacter = GetComponent<ToolCharacterMovement>();
		inventoryControler = GetComponent<InventoryControler>();
		toolbarController = GetComponent<ToolbarController>();
		itemContainerInterectController = GetComponent<ItemContainerInterectController>();
	}

	public void DisableControl()
	{
		characterController.enabled = false;
		toolCharacter.enabled = false;
		inventoryControler.enabled = false;
		toolbarController.enabled = false;
		itemContainerInterectController.enabled = false;
	}
	public void EnableControl()
	{
		characterController.enabled = true;
		toolCharacter.enabled = true;
		inventoryControler.enabled = true;
		toolbarController.enabled = true;
		itemContainerInterectController.enabled = true;
	}
}
