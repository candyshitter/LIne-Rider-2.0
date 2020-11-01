using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[AddComponentMenu("UI/Radio Group", 32), DisallowMultipleComponent]
public class RadioGroup : ToggleGroup
{
	public new void EnsureValidState()
	{
		Debug.Log("pp");
	}

}