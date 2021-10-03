using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSpawn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private string[] _sentences;

    private int _index;
    private float _dialogueSpeed = 0.05f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }
    }

    void NextSentence()
    {
        if(_index <= _sentences.Length - 1)
        {
            _dialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
    }

    IEnumerator WriteSentence()
    {
        foreach (char character in _sentences[_index].ToCharArray())
        {
            _dialogueText.text += character;
            yield return new WaitForSeconds(_dialogueSpeed);
        }
        _index++;
    }
}
