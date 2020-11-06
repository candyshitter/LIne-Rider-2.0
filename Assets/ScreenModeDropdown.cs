using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Dropdown))]
public class ScreenModeDropdown : MonoBehaviour
{
	private void Start()
	{
		GetComponent<TMP_Dropdown>().onValueChanged.AddListener(
			index => Screen.SetResolution(
				Screen.resolutions[index].width, 
				Screen.resolutions[index].height, 
				Screen.fullScreenMode));
	}
}
