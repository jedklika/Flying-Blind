using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector), typeof(Animator))]
public class DialogueBox : MonoBehaviour
{
    private PlayableDirector _director;
    private TextMeshProUGUI _dialogue;

    private void Awake()
    {
        _director = GetComponent<PlayableDirector>();
        _dialogue = GetComponentInChildren<TextMeshProUGUI>(true);
    }

    public void PlayDialogue(string text)
    {
        _dialogue.text = text;
        _director.Play();
    }
    
}
