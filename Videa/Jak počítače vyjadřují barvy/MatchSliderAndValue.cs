using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MatchSliderAndValue : MonoBehaviour
{
	private Slider slider;
	[SerializeField]
	private TMP_InputField inputField;
	[SerializeField]
	private int minimumValue;
	[SerializeField]
	private int maximumValue;
	[SerializeField]
	private int defaultInputValue;

	void Start()
	{
		slider = GetComponent<Slider>();
	}

	public void SliderValueChanged()
	{
		inputField.text = slider.value.ToString();
	}

	public void InputFieldValueChanged()
	{
		int num = defaultInputValue;
		if (int.TryParse(inputField.text, out num))
		{
			if (num < minimumValue) num = minimumValue;
			if (num > maximumValue) num = maximumValue;
		}
		inputField.text = num.ToString();
		slider.value = num;
	}
}
