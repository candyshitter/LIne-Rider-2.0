using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Dropdown))]
public class ResolutionDropdown : MonoBehaviour
{
	private void Start()
	{
		var dropdown = GetComponent<TMP_Dropdown>();
		SetDropDownValues(dropdown);
		dropdown.onValueChanged.AddListener(
			index => Screen.SetResolution(
				Screen.resolutions[index].width, 
				Screen.resolutions[index].height, 
				Screen.fullScreenMode));
	}

	private void SetDropDownValues(TMP_Dropdown dropdown)
	{
		dropdown.ClearOptions();
		var options = new List<string>();
		var currentIndex = AddOptions(Screen.resolutions, options);

		dropdown.AddOptions(options);
		dropdown.value = currentIndex;
		dropdown.RefreshShownValue();
	}

	private static int AddOptions(Resolution[] resolutions, ICollection<string> options)
	{
		var index = 0;
		for (var i = 0; i < resolutions.Length; i++)
		{
			var option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);

			if (resolutions[i].width == Screen.currentResolution.width &&
			    resolutions[i].height == Screen.currentResolution.height)
				index = i;
		}
		return index;
	}
}
