using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainerInterectController : MonoBehaviour
{
    ItemContainer targetItemContainer;
	InventoryControler inventoryControler;
	[SerializeField] ItemContainerPanel itemContainerPanel;
	Transform openedChest;
	[SerializeField] float maxDistance = 0.8f;
	private void Awake()
	{
		inventoryControler = GetComponent<InventoryControler>();
	}

	private void Update()
	{
		if(openedChest != null)
		{
			float distance = Vector2.Distance(openedChest.position, transform.position);
			if(distance > maxDistance)
			{
				openedChest.GetComponent <LootContainerInteract>().Close(GetComponent<Character>());
			}
		}
	}
	public void Open(ItemContainer itemContainer , Transform _openedChest)
	{
		targetItemContainer = itemContainer;
		itemContainerPanel.inventory = targetItemContainer;
		inventoryControler.Open();
		itemContainerPanel.gameObject.SetActive(true);
		openedChest = _openedChest;
	}

	public void Close()
	{
		inventoryControler.Close();
		itemContainerPanel.gameObject.SetActive(false);
		openedChest = null;
	}
}
