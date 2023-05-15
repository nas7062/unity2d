using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class ToolTipController : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
	public ToolTip tooltip;




	public void OnPointerEnter(PointerEventData eventData)
	{
		Item item = GetComponent<ItemSlot>().item;

		if (item != null)
		{
			tooltip.gameObject.SetActive(true);
			
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.gameObject.SetActive(false);
	}
}
