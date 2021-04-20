using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;


public class PauseActivator : MonoBehaviour
{
    [SerializeField] private ColorTranslationEffect fogEffect;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Color fogEffectColor;
    [SerializeField] private Color startingFogEffectColor;

    private void OnPauseChange(object sender, bool pauseValue) {
        if (pauseValue) ActivatePause();
        else ExitPause();

    }

    private void ExitPause() {
        pauseMenu.SetActive(false);
        fogEffect.gameObject.SetActive(false);
    }
    private void ActivatePause() {
        fogEffect.gameObject.SetActive(true);
        fogEffect.SetStartingColor(startingFogEffectColor);
        fogEffect.TranslateToColor(fogEffectColor);
        pauseMenu.SetActive(true);
    }
    private void Start() {
        PauseManager.OnPauseChange += OnPauseChange;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) {
            PauseManager.Pause = !PauseManager.Pause;
        }
    }
}
