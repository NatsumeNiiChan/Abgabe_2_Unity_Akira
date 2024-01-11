using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    private AudioSource rightSound;
    private AudioSource wrongSound;

    public int letterOne;
    public int letterTwo;
    public int letterThree;
    [SerializeField] private int words;

    private LetterAssignment letterScript;

    [SerializeField] private List<GameObject> wordOne;
    [SerializeField] private List<GameObject> wordTwo;
    [SerializeField] private List<GameObject> wordThree;

    private void Awake()
    {
        rightSound = GameObject.Find("AudioManager W").GetComponent<AudioSource>();
        wrongSound = GameObject.Find("AudioManager R").GetComponent<AudioSource>();
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
                letter.GetComponent<Image>().color = Color.white;
                letter.GetComponent<LetterAssignment>().isClicked = false;
                letterOne--;

                wordOne.Remove(letter);
            }
        }

        foreach (GameObject letter in wordTwo)
        {
            if (letter.GetComponent<LetterAssignment>().isFinished == false)
            {
                letter.GetComponent<Image>().color = Color.white;
                letter.GetComponent<LetterAssignment>().isClicked = false;
                letterTwo--;

                wordOne.Remove(letter);
            }
        }

        foreach (GameObject letter in wordThree)
        {
            if (letter.GetComponent<LetterAssignment>().isFinished == false)
            {
                letter.GetComponent<Image>().color = Color.white;
                letter.GetComponent<LetterAssignment>().isClicked = false;
                letterThree--;

                wordOne.Remove(letter);
            }
        }
    }
}
