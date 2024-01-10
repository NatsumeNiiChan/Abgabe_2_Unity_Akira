using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterAssignment : MonoBehaviour
{
    private TMP_Text letter;

    private void Awake()
    {
        letter = GetComponent<TMP_Text>();
        letter.text = Random.Range(0, 25);
    }
}
