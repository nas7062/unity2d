using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class ItemSlot 
{
	public Item item;
	public int count;
	
	public void Copy(ItemSlot slot)
	{
		item = slot.item;
		count = slot.count;
		
	}

	public void Set(Item item, int count)
	{
		this.item = item;
		this.count = count;
		
	}

	public void Clear()
	{
		item = null;
		count = 0;
	}
}

[CreateAssetMenu(menuName ="Data/Item Container")]
public class ItemContainer : ScriptableObject
{
	public List<ItemSlot> slots;
	public bool isDirty;

	internal void Init()
	{
		slots = new List<ItemSlot>();
		for(int i=0;i <33;i++)
		{
			slots.Add(new ItemSlot());
		}
	}
	public void Add(Item item, int count =1)
	{
		isDirty = true;
		if(item.stackable == true)
		{
			ItemSlot itemSlot = slots.Find(x => x.item == item);
			if(itemSlot != null)
			{
				itemSlot.count += count;
			}
			else
			{
				itemSlot = slots.Find(x => x.item == null);
				if(itemSlot != null)
				{
					itemSlot.item = item;
					itemSlot.count = count;
				}
			}
		}
		else
		{ 
			ItemSlot itemSlot =	slots.Find(x => x.item == null);
			if(itemSlot != null)
			{
				itemSlot.item = item;
			}
		}
	}
	public void Remove(Item itemToRemove, int count = 1)
	{
		isDirty = true;
		if (itemToRemove.stackable)
		{
			ItemSlot itemslot = slots.Find(x => x.item == itemToRemove);

			if(itemslot ==null) { return; }
			itemslot.count -= count;
			if(itemslot.count <= 0)
			{
				itemslot.Clear();
			}
		}
		else
		{
			while(count >0)
			{
				count -= 1;

				ItemSlot itemslot = slots.Find(x => x.item == itemToRemove);
				if(itemslot  == null) { break; }

				itemslot.Clear();
			}
		}
	}

	
}
