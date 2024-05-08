using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBackground : MonoBehaviour
{
	public void ToggleBackgroundButtonClicked()
	{
		gameObject.SetActive(!gameObject.activeSelf);
	}
}