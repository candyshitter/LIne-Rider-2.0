using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private void Awake() => pausePanel.SetActive(false);

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if(!pausePanel.activeSelf)
            PauseGame();
        else
            PlayGame();
    }

    //Called by onClick continue button
    public void PlayGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
