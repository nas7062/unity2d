using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class ToolCharacterMovement : MonoBehaviour
{

	CharacterController2D charactercontroller;
	Character character;
	Rigidbody2D rigidbody2d;
	ToolbarController toolbarController;
	Animator animator;
	[SerializeField] float offsetDistance = 1.0f;
	[SerializeField] public float sizeOfInteractableArea;
	[SerializeField] MarkerManager markerManager;
	[SerializeField] TileMapReadController tileMapReadController;
	[SerializeField] float maxDistance = 1.65f;
	[SerializeField] ToolAction onTilePickUp;
	[SerializeField] IconHighlight iconHighlight;
	AttackController attackController;
	[SerializeField] int weaponEnergyCost = 3;
	Vector3Int selectedTilePosition;
	bool selectable;

	private void Awake()
	{
		character = FindObjectOfType<Character>();
		charactercontroller = GetComponent<CharacterController2D>();
		rigidbody2d = GetComponent<Rigidbody2D>();
		toolbarController = GetComponent<ToolbarController>();
		animator = GetComponent<Animator>();
		attackController = GetComponent<AttackController>();
	}
	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			WeaponAction();
		}

		SelectTile();
		CanSelectCheck();
		Marker();
		if(Input.GetMouseButtonDown(0))
		{
			if(UseToolWorld() ==true)
			{
				return;
			}
			UseToolGrid();
		}
	}

	private void WeaponAction()
	{
		Item item = toolbarController.GetItem; 
		if (item == null) { return; }
		if(item.isWeapon == false) { return; }

		EnergyCost(weaponEnergyCost);

		Vector2 position = rigidbody2d.position + charactercontroller.lastMotionVector * offsetDistance;
		attackController.Attack(item.damage, charactercontroller.lastMotionVector);
	}

	private void EnergyCost(int energyCost)
	{
		character.GetTired(energyCost);


	}

	private void SelectTile()
	{
		selectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
	}
	private void Marker()
	{
		markerManager.markedCellPosition = selectedTilePosition;
		iconHighlight.cellPosition = selectedTilePosition;
	}

	void CanSelectCheck()
	{
		Vector2 characterPosition = transform.position;
		Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
		markerManager.Show(selectable);
		iconHighlight.CanSelect = selectable;
	}
	private bool UseToolWorld()
	{
		Vector2 position = rigidbody2d.position + charactercontroller.lastMotionVector * offsetDistance;

		Item item = toolbarController.GetItem;
		if(item == null) { return false; }
		if(item.onAction == null) { return false; }

		EnergyCost(item.onAction.energyCost);
		animator.SetTrigger("act");
		bool complete=	item.onAction.OnApply(position);

		if (complete == true)
		{
			if (item.onItemUsed != null)
			{
				item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
			}

		}
		return complete;
	}

	private void UseToolGrid()
	{
		if(selectable == true)
		{
			Item item = toolbarController.GetItem;
			if(item == null) 
			{
				PickUpTile();
				return; 
			}
			if(item.onTileMapAction ==null) { return; }
			EnergyCost(item.onTileMapAction.energyCost);

			animator.SetTrigger("act");
			bool complete = item.onTileMapAction.OnApplyToTileMap(selectedTilePosition,tileMapReadController,item);	

			if(complete == true)
			{
				if(item.onItemUsed != null)
				{
					item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
				}
				
			}
		}
	}

	private void PickUpTile()
	{
		if(onTilePickUp == null) { return;}

		onTilePickUp.OnApplyToTileMap(selectedTilePosition, tileMapReadController, null);
	}
}
