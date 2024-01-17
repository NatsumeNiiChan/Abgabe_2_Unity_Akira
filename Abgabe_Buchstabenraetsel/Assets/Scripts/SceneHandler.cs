using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private bool audioIsOn;
    [SerializeField] private AudioListener audioListener;
    [SerializeField] private GameObject XImage;

    private void Awake()
    {
        audioListener = FindObjectOfType<AudioListener>();
    }

    public void SoundButton()
    {
        if (audioIsOn == true)
        {
            audioListener.enabled = false;
            audioIsOn = false;
            XImage.SetActive(true);
        }

        else
        {
            audioListener.enabled = true;
            audioIsOn = true;
            XImage.SetActive(false);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
