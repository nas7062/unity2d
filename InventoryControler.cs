using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControler : MonoBehaviour
{
	[SerializeField] GameObject panel;
	[SerializeField] GameObject toolbarPanel;
	[SerializeField] GameObject additionalPanel;
	[SerializeField] GameObject storePanel;
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
		if(panel.activeInHierarchy ==false)
			{
				Open();
			}
			else
			{
				Close();
			}
		}
	}
	public void Open()
	{
		panel.SetActive(true);
		toolbarPanel.SetActive(false);
		storePanel.SetActive(false);
	}
	public void Close()
	{
		panel.SetActive(false);
		toolbarPanel.SetActive(true);
		additionalPanel.SetActive(false);
		storePanel.SetActive(false);
	}
}
 