using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private void Awake() => pausePanel.SetActive(false);

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            pausePanel.SetActive(!pausePanel.activeSelf);
    }
}
