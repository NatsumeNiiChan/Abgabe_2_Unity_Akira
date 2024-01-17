using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LetterAssignment : MonoBehaviour, IPointerDownHandler
{
    //Variablen festlegen
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
        //Findingcalls
        Image = GetComponent<Image>();
        puzzleScript = FindObjectOfType<PuzzleManager>();

        //Buchstaben ohne zugehörigkeit random generieren
        if (WordOne == false && WordTwo == false && WordThree == false)
        {
            letter = GetComponentInChildren<TMP_Text>();
            letter.text = alphabet[Random.Range(0, alphabet.Length)].ToString();
        }
    }

    //Maus Event
    public void OnPointerDown(PointerEventData eventData)
    {
        //Frage ob ein Buchstabe schon angeklickt ist
        if (isClicked == true)
        {
            return;
        }

        //Abfrage ob der Buchstabe einem Wort angehört - die Methode im Puzzlescript wird aufgerufen
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

        //Ist der Buchstabe falsch, wird die Puzzlescript Methode aufgerufen und gewartet, dann resettet
        else
        {
            Image.color = Color.red;
            puzzleScript.WrongLetter(gameObject);

            Invoke("Reset", 0.5f);
        }
    }

    //Farbe auf weiss - Resetfunktion des Puzzlescript wird genutzt
    private void Reset()
    {
        if (isFinished == false)
        {
            Image.color = Color.white;
        }

        puzzleScript.ResetLetters();
    }
}
