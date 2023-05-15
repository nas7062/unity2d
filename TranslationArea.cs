using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationArea : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.transform.CompareTag("Player"))
		{
			transform.parent.GetComponent<Traslation>().InitiateTransition(collision.transform);
		}
	}
}
