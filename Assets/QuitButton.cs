using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuitButton : MonoBehaviour
{
    private void Start() => 
        GetComponent<Button>().onClick.AddListener(
            () => Application.Quit(0));
}
