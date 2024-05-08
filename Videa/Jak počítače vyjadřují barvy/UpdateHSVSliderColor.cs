using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHSVSliderColor : MonoBehaviour
{
	[System.Serializable]
	private enum SliderType
	{
		H, S, V
	}

	private const float fillAreaTransparency = 160f / 256;

	[SerializeField]
	private SliderType sliderType;

	private Image fillAreaImage;
	private Image sliderHandleImage;

	private Slider slider;

	void Start()
	{
		fillAreaImage = transform.Find("Fill Area/Fill").GetComponent<Image>();
		sliderHandleImage = transform.Find("Handle Slide Area/Handle").GetComponent<Image>();
		slider = GetComponent<Slider>();
	}

	void Update()
	{
		float input = slider.value;
		Color newColor = new Color();
		switch (sliderType)
		{
			case SliderType.H: newColor = Color.HSVToRGB(input / 360, 1, 1); break;
			case SliderType.S: newColor = Color.HSVToRGB(0, 0, 1 - input / 100); break;
			case SliderType.V: newColor = Color.HSVToRGB(0, 0, input / 100); break;
			default: Debug.LogError("Slider Type not recognized"); break;
		}

		sliderHandleImage.color = newColor;
		newColor.a = fillAreaTransparency;
		fillAreaImage.color = newColor;
	}
}
