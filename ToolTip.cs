using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI value;
    
    public void SetUpTooltip(string name ,string des, int val)
	{
        nameText.text = name;
        descriptionText.text = des;
        value.text = val.ToString();
    }

    float halfwidth;
    RectTransform rt;
	private void Start()
	{
      //  halfwidth =   GetComponentInParent<CanvasScaler>().referenceResolution.x * 0.5f;
      //  rt = GetComponent<RectTransform>();
	}
	private void Update()
	{
        transform.position = Input.mousePosition;

       // if (rt.anchoredPosition.x + rt.sizeDelta.x > halfwidth)
       //     rt.pivot = new Vector2(1, 1);
       // else
        //   rt.pivot = new Vector2(0, 1);
	}
}
