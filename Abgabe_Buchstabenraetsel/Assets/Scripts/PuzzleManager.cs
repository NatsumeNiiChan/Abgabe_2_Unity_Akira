using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    private AudioSource rightSound;
    private AudioSource wrongSound;

    private int letterOne;
    private int letterTwo;
    private int letterThree;
    [SerializeField] private int words;

    private LetterAssignment letterScript;

    [SerializeField] private List<GameObject> wordOne;
    [SerializeField] private List<GameObject> wordTwo;
    [SerializeField] private List<GameObject> wordThree;

    private GameObject winScreen;

    private float timer;

    private void Awake()
    {
        rightSound = GameObject.Find("AudioManager W").GetComponent<AudioSource>();
        wrongSound = GameObject.Find("AudioManager R").GetComponent<AudioSource>();

        winScreen = GameObject.Find("Winscreen");
        winScreen.SetActive(false);
    }

    private void Update()
    {
        if (words < 3)
        {
            timer += Time.deltaTime;
        }

        else if (words >= 3)
        {
            HasWon();
        }
    }

    public void RightLetter(GameObject Letter)
    {
        letterScript = Letter.GetComponent<LetterAssignment>();

        rightSound.Play();
        letterScript.isClicked = true;

        if (letterScript.WordOne == true)
        {
            letterOne++;

            wordOne.Add(Letter);

            if (letterOne >= 3)
            {
                words++;

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

        
    }
}
