using UnityEngine;
using UnityEngine.UI;

public class EraseAller : MonoBehaviour
{
	public void Start()
	{
		GetComponent<Button>().onClick.AddListener(LineManager.DestroyLines);
	}
}
