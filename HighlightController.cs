using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
	[SerializeField] GameObject hightlighter;

	GameObject currentTarget;
	public void Highlight(GameObject target)
	{
		if(currentTarget == target)
		{
			return;
		}
		currentTarget = target;
		Vector3 position = target.transform.position + Vector3.up * 0.7f;
		Highlight(position);
	}
	public void Highlight(Vector3 position)
	{
		hightlighter.SetActive(true);
		hightlighter.transform.position = position;
	}

	public void Hide()
	{
		currentTarget = null;
		hightlighter.SetActive(false);
	}

}
