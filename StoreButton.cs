using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{
	[SerializeField] Image icon;
	[SerializeField] Text text;
	
	int myIndex;


	ItemPanel itemPanel;

	public void SetIndex(int index)
	{
		myIndex = index;
	}
	public void SetItemPanel(ItemPanel source)
	{
		itemPanel = source;
	}
	public void Set(Item item)
	{
		icon.gameObject.SetActive(true);
		icon.sprite = item.icon;
		if (item.stackable == true)
		{
			text.gameObject.SetActive(true);
			text.text = item.name.ToString();

		}
		else
		{
			text.gameObject.SetActive(false);
		}

	}

	public void Clean()
	{
		icon.sprite = null;
		icon.gameObject.SetActive(false);

		text.gameObject.SetActive(false);
	}

	public void OnPointerClick(PointerEventData eventData)
	{

		itemPanel.OnClick(myIndex);
	}



	
}
