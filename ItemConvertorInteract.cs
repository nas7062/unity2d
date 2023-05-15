using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemConvertorData
{
	public ItemSlot itemslot;
	public int timer;

	public ItemConvertorData()
	{
		itemslot = new ItemSlot();
	}
}
[RequireComponent(typeof(TimeAgent))]
public class ItemConvertorInteract : Interactable,IPersistant
{
    [SerializeField] Item convertableItem;
    [SerializeField] Item producedItem;
	[SerializeField] int producedItemCount = 1;
	[SerializeField] AudioClip onOpenAudio;

	ItemConvertorData data;

	[SerializeField] int timeToProcess = 5;
	

	private void Start()
	{
		TimeAgent timeAgent = GetComponent<TimeAgent>();
		timeAgent.onTimeTick += ItemConvertProcess;

		if(data ==null)
		{
			data = new ItemConvertorData();
		}
		
		
	}

	private void ItemConvertProcess()
	{
		if (data.itemslot == null) { return; }
		if (data.timer > 0)
		{
			data.timer -= 1;
			if (data.timer <= 0)
			{
				CompleteItemConversion();
			}
		}
	}

	public override void Interact(Character character)
	{
		if(data.itemslot.item ==null)
		{
			if (GameManager.instance.dragAndDropController.Check(convertableItem))
			{
				StartItemProcessing(GameManager.instance.dragAndDropController.itemSlot);
				return;
			}
			ToolbarController toolbarController = character.GetComponent<ToolbarController>();
			if(toolbarController ==null) { return; }

			ItemSlot itemSlot = toolbarController.GetItemSlot;

			if(itemSlot.item == convertableItem)
			{
				StartItemProcessing(itemSlot);
				return;
			}
		}
		if(data.itemslot.item != null && data.timer <= 0)
		{
			GameManager.instance.inventoryContainer.Add(data.itemslot.item, data.itemslot.count);
			data.itemslot.Clear();
		}
	}

	private void StartItemProcessing(ItemSlot toProcess)
	{

		data.itemslot.Copy(GameManager.instance.dragAndDropController.itemSlot);
		data.itemslot.count = 1;
		if(toProcess.item.stackable )
		{
			toProcess.count -= 1;
			if(toProcess.count < 0)
			{
				toProcess.Clear();
			}
		}
		else
		{
			toProcess.Clear();
		}
		

		AudioManager.instance.Play(onOpenAudio);
		data.timer = timeToProcess;
	}
	private void Update()
	{
		
	}

	private void CompleteItemConversion()
	{
		data.itemslot.Clear();
		data.itemslot.Set(producedItem, producedItemCount);
	}

	public string Read()
	{
		return JsonUtility.ToJson(data);
	}

	public void Load(string jsonString)
	{
		data = JsonUtility.FromJson<ItemConvertorData>(jsonString);
	}
}
