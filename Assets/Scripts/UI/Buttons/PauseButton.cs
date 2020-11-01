using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
	private void Start() => 
		GetComponent<Button>().onClick.AddListener(() => GameStateHolder.IsPlaying = false);
}
