using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextSpawn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private string[] _sentences;

    private float _distance = 280f;
    private float _duration = 1f;

    private int _index;
    private float _dialogueSpeed = 0.05f;
    private bool _isTyping = false;

    private void Start()
    {
        transform.DOMove(new Vector3(transform.position.x, transform.position.y + _distance), _duration);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }
    }

    void NextSentence()
    {
        if (_index <= _sentences.Length - 1)
        {
            if (!_isTyping)
            {
                _dialogueText.text = "";
                _isTyping = true;
                StartCoroutine(WriteSentence());
            }
        }
        else
        {
            transform.DOMove(new Vector3(transform.position.x, transform.position.y - _distance), _duration);
            Time.timeScale = 1f;
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
        _isTyping = false;
    }
}
