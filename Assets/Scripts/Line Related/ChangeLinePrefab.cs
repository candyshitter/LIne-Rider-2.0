using UnityEngine;
using UnityEngine.UI;

public class ChangeLinePrefab : MonoBehaviour
{
	[SerializeField] private Line linePrefab;
	
	private void Start()
	{
		Toggle toggle;
	 	(toggle = GetComponent<Toggle>()).onValueChanged.AddListener(
			(state) => LineManager.SetLinePrefab(linePrefab));
		
		if(toggle.isOn)
			LineManager.SetLinePrefab(linePrefab);
	}
}