using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LetterAssignment : MonoBehaviour, IPointerDownHandler
{
    private string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public bool WordOne;
    public bool WordTwo;
    public bool WordThree;
    public bool isFinished = false;
    public bool isClicked = false;

    private TMP_Text letter;
    public Image Image;
    private PuzzleManager puzzleScript;

    private void Awake()
    {
        Image = GetComponent<Image>();
        puzzleScript = FindObjectOfType<PuzzleManager>();

        if (WordOne == false && WordTwo == false && WordThree == false)
        {
            letter = GetComponentInChildren<TMP_Text>();
            letter.text = alphabet[Random.Range(0, alphabet.Length)].ToString();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isClicked == true)
        {
            return;
        }

        if (WordOne == true)
        {
            Image.color = Color.green;
            puzzleScript.RightLetter(gameObject);
        }

        else if (WordTwo == true)
        {
            Image.color = Color.green;
            puzzleScript.RightLetter(gameObject);
        }

        else if (WordThree == true)
        {
            Image.color = Color.green;
            puzzleScript.RightLetter(gameObject);
        }

        else
        {
            Image.color = Color.red;
            puzzleScript.WrongLetter(gameObject);

            Invoke("Reset", 0.5f);
        }
    }

    private void Reset()
    {
        if (isFinished == false)
        {
            Image.color = Color.white;
        }

        puzzleScript.ResetLetters();
    }

    //public void NewRandom()
    //{
    //    if (WordOne == false && WordTwo == false && WordThree == false)
    //    {
    //        letter = GetComponentInChildren<TMP_Text>();
    //        letter.text = alphabet[Random.Range(0, alphabet.Length)].ToString();
    //    }
    //}
}
