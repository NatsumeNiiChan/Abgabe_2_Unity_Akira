using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    private AudioSource rightSound;
    private AudioSource wrongSound;
    private AudioSource winSound;

    private int letterOne;
    private int letterTwo;
    private int letterThree;
    [SerializeField] private int words;

    private LetterAssignment letterScript;

    [SerializeField] private List<GameObject> wordOne;
    [SerializeField] private List<GameObject> wordTwo;
    [SerializeField] private List<GameObject> wordThree;

    private GameObject winScreen;
    private TMP_Text timerText;
    private TMP_Text highScore;

    private float timer;

    private void Awake()
    {
        rightSound = GameObject.Find("AudioManager W").GetComponent<AudioSource>();
        wrongSound = GameObject.Find("AudioManager R").GetComponent<AudioSource>();
        winSound = GameObject.Find("AudioManager Win").GetComponent<AudioSource>();

        timerText = GameObject.Find("Time").GetComponent<TMP_Text>();
        highScore = GameObject.Find("Points").GetComponent<TMP_Text>();

        winScreen = GameObject.Find("Winscreen");
        winScreen.SetActive(false);

        if (PlayerPrefs.GetFloat("highscore") == 0)
        {
            PlayerPrefs.SetFloat("highscore", 100);
        }
    }

    private void Update()
    {
        if (words <= 2)
        {
            timer += Time.deltaTime;

            timerText.text = timer.ToString();
        }

        else if (words == 3)
        {
            HasWon();

            words = 5;

            if (timer < PlayerPrefs.GetFloat("highscore"))
            {
                PlayerPrefs.SetFloat("highscore", timer);
            }
            
            highScore.text = PlayerPrefs.GetFloat("highscore").ToString();
        }
    }

    public void RightLetter(GameObject Letter)
    {
        letterScript = Letter.GetComponent<LetterAssignment>();

        letterScript.isClicked = true;

        if (letterScript.WordOne == true)
        {
            letterOne++;

            wordOne.Add(Letter);

            if (letterOne >= 3)
            {
                words++;

                rightSound.Play();

                foreach (GameObject letter in wordOne)
                {
                    letter.GetComponent<LetterAssignment>().isFinished = true;
                }
            }
        }

        if (letterScript.WordTwo == true)
        {
            letterTwo++;

            wordTwo.Add(Letter);

            if (letterTwo >= 4)
            {
                words++;

                rightSound.Play();

                foreach (GameObject letter in wordTwo)
                {
                    letter.GetComponent<LetterAssignment>().isFinished = true;
                }
            }
        }

        if (letterScript.WordThree == true)
        {
            letterThree++;

            wordThree.Add(Letter);

            if (letterThree >= 5)
            {
                words++;

                rightSound.Play();

                foreach (GameObject letter in wordThree)
                {
                    letter.GetComponent<LetterAssignment>().isFinished = true;
                }
            }
        }

    }

    public void WrongLetter(GameObject Letter)
    {
        letterScript = Letter.GetComponent<LetterAssignment>();

        wrongSound.Play();
    }

    public void ResetLetters()
    {
        foreach (GameObject letter in wordOne)
        {
            if (letter.GetComponent<LetterAssignment>().isFinished == false)
            {
                Debug.Log("Hi");
                letter.GetComponent<Image>().color = Color.white;
                letter.GetComponent<LetterAssignment>().isClicked = false;
                letterOne--;
            }
        }

        wordOne.Clear();

        foreach (GameObject letter in wordTwo)
        {
            if (letter.GetComponent<LetterAssignment>().isFinished == false)
            {
                letter.GetComponent<Image>().color = Color.white;
                letter.GetComponent<LetterAssignment>().isClicked = false;
                letterTwo--;
            }
        }
        
        wordTwo.Clear();

        foreach (GameObject letter in wordThree)
        {
            if (letter.GetComponent<LetterAssignment>().isFinished == false)
            {
                letter.GetComponent<Image>().color = Color.white;
                letter.GetComponent<LetterAssignment>().isClicked = false;
                letterThree--;
            }
        }
        
        wordThree.Clear();
    }

    public void HasWon()
    {
        winScreen.SetActive(true);

        winSound.Play();
    }
}
