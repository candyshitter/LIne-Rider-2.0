using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
	private void Start() => 
		GetComponent<Button>().onClick.AddListener(FindObjectOfType<Player>().ResetPosition);
}
