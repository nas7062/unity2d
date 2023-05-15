using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAction : ScriptableObject
{
	public int energyCost = 0;
    public virtual bool OnApply(Vector2 worldPoint)
	{
		
		return true;
	}

	public virtual bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController ,Item item)
	{

		return true;
	}

	public virtual void OnItemUsed(Item usedItem, ItemContainer inventory)
	{
		
	}
}
