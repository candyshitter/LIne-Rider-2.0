using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
	private void Start() =>
		GetComponent<Button>().onClick
			.AddListener(() => GameStateHolder.IsPlaying = true);
}