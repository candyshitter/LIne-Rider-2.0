using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLinePrefab : MonoBehaviour
{
	[SerializeField] private Line linePrefab;
	[SerializeField] private bool startsSelected;
	
	private void Start()
	{
		GetComponent<Button>().onClick.AddListener(
			() => LineManager.SetLinePrefab(linePrefab));
		
		if(startsSelected)
			LineManager.SetLinePrefab(linePrefab);
	}
}