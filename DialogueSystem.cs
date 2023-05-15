using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueSystem : MonoBehaviour
{
	[SerializeField] Text targetText;
	[SerializeField] Text nameText;
	[SerializeField] Image portrait;

	DialogueContainer currentDialouge;
	int currentTextLine;

	[Range(0.0f,1.0f)]
	[SerializeField] float visibleTextPercent;
	[SerializeField] float timePerLetter = 0.05f;
	float totalTimeToType, currentTime;
	string lineToShow;
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			PushText();
		}

		TypeOutText();
	}

	private void TypeOutText()
	{
		if(visibleTextPercent >= 1f) { return; }
		currentTime += Time.deltaTime;
		visibleTextPercent = currentTime / totalTimeToType;
		visibleTextPercent = Mathf.Clamp(visibleTextPercent, 0, 1f);
		UpdateText();
	}

	 void UpdateText()
	{
		int letterCount = (int)(lineToShow.Length * visibleTextPercent);
		targetText.text = lineToShow.Substring(0, letterCount);
	}

	private void PushText()
	{
		if(visibleTextPercent <1f)
		{
			visibleTextPercent = 1f;
			UpdateText();
			return;
		}
		
		if (currentTextLine >= currentDialouge.line.Count)
		{
			Conclude();

		}
		else
		{
			CycleLine();
		}
	}

	void CycleLine()
	{
		lineToShow = currentDialouge.line[currentTextLine];
		totalTimeToType = lineToShow.Length * timePerLetter;
		currentTime = 0f;
		visibleTextPercent = 0f;
		targetText.text = "";

		currentTextLine += 1;
	}
	public void Initialize(DialogueContainer dialogueContainer)
	{
		Show(true);
		currentDialouge = dialogueContainer;
		currentTextLine = 0;
		CycleLine();
		UpdatePortrait();
	}

	private void UpdatePortrait()
	{
		portrait.sprite = currentDialouge.actor.portrait;
		nameText.text = currentDialouge.actor.name;
	}

	private void Show(bool v)
	{
		gameObject.SetActive(v);
	}

	private void Conclude()
	{
		Show(false);
	}
}
