using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    //Variablen festlegen
    [SerializeField] private bool audioIsOn;
    [SerializeField] private AudioListener audioListener;
    [SerializeField] private GameObject XImage;

    private void Awake()
    {
        //Findingcall
        audioListener = FindObjectOfType<AudioListener>();
    }

    public void SoundButton()
    {
        //Audiolistener deaktivieren/aktivieren
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
        //Scene neu laden
        SceneManager.LoadScene(0);
    }
}
