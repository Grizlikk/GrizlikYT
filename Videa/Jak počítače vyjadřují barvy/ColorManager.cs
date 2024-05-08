using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ColorManager : MonoBehaviour
{
	[Serializable]
	private struct RGBFields
	{
		public TMP_InputField Red;
		public TMP_InputField Green;
		public TMP_InputField Blue;
	}
	[Serializable]
	private struct CMYKFields
	{
		public TMP_InputField Cyan;
		public TMP_InputField Magenta;
		public TMP_InputField Yellow;
		public TMP_InputField Key;
	}
	[Serializable]
	private struct HSVFields
	{
		public TMP_InputField Hue;
		public TMP_InputField Saturation;
		public TMP_InputField Value;
	}
	private enum UpdateFromFormat
	{
		RGB, CMYK, HSV
	}


	[SerializeField]
	private GameObject displayPlane;
	private Renderer displayPlaneRenderer;

	private bool colorSet = true;

	[SerializeField]
	private RGBFields rgbFields;
	[SerializeField]
	private CMYKFields cmykFields;
	[SerializeField]
	private HSVFields hsvFields;

	void Start()
	{
		displayPlaneRenderer = displayPlane.GetComponent<Renderer>();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape)) Application.Quit();
	}

	public void UpdateColorFromRGB()
	{
		if (!colorSet) return;
		colorSet = false;
		byte red = byte.Parse(rgbFields.Red.text);
		byte green = byte.Parse(rgbFields.Green.text);
		byte blue = byte.Parse(rgbFields.Blue.text);

		Color color = new Color32(red, green, blue, 255);
		DisplayColor(color);
		UpdateColorSliders(color, UpdateFromFormat.RGB);

		colorSet = true;
	}
	public void UpdateColorFromCMYK()
	{
		if (!colorSet) return;
		colorSet = false;
		float cyan = float.Parse(cmykFields.Cyan.text) / 100;
		float magenta = float.Parse(cmykFields.Magenta.text) / 100;
		float yellow = float.Parse(cmykFields.Yellow.text) / 100;
		float key = float.Parse(cmykFields.Key.text) / 100;

		float red = (1 - cyan) * (1 - key);
		float green = (1 - magenta) * (1 - key);
		float blue = (1 - yellow) * (1 - key);

		Color color = new Color(red, green, blue);
		DisplayColor(color);
		UpdateColorSliders(color, UpdateFromFormat.CMYK);

		colorSet = true;
	}
	public void UpdateColorFromHSV()
	{
		if (!colorSet) return;
		colorSet = false;

		float hue = float.Parse(hsvFields.Hue.text) / 360;
		float saturation = float.Parse(hsvFields.Saturation.text) / 100;
		float value = float.Parse(hsvFields.Value.text) / 100;

		Color color = Color.HSVToRGB(hue, saturation, value);
		DisplayColor(color);
		UpdateColorSliders(color, UpdateFromFormat.HSV);

		colorSet = true;
	}

	private void DisplayColor(Color32 color)
	{
		print($"Red: {color.r}\tGreen: {color.g}\tBlue: {color.b}");
		displayPlaneRenderer.material.color = color;
	}

	private void UpdateColorSliders(Color color, UpdateFromFormat fromFormat)
	{
		// Pokud čtete tento text, tak jste si pozastavili video, abyste si tento kód prohlédli. Noice :D
		if (fromFormat != UpdateFromFormat.RGB)
		{
			rgbFields.Red.text = Math.Round(color.r * 255).ToString();
			rgbFields.Green.text = Math.Round(color.g * 255).ToString();
			rgbFields.Blue.text = Math.Round(color.b * 255).ToString();
		}

		if (fromFormat != UpdateFromFormat.CMYK)
		{
			float key = 1 - Math.Max(color.r, Math.Max(color.g, color.b));
			cmykFields.Cyan.text = Math.Round((1 - color.r - key) / (1 - key) * 100).ToString();
			cmykFields.Magenta.text = Math.Round((1 - color.g - key) / (1 - key) * 100).ToString();
			cmykFields.Yellow.text = Math.Round((1 - color.b - key) / (1 - key) * 100).ToString();
			cmykFields.Key.text = Math.Round(key * 100).ToString();
		}

		if (fromFormat != UpdateFromFormat.HSV)
		{
			Color.RGBToHSV(color, out float hue, out float saturation, out float value);
			hsvFields.Hue.text = Math.Round(hue * 360).ToString();
			hsvFields.Saturation.text = Math.Round(saturation * 100).ToString();
			hsvFields.Value.text = Math.Round(value * 100).ToString();
		}
	}
}