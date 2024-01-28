using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

[RequireComponent(typeof(Collider2D))]  
public class DialogueTrigger : MonoBehaviour
{
    private BoxCollider2D _boxCollid;
    [TextArea(3, 5)]
    [SerializeField] private string textToPlay;
    private DialogueBox _dialogueBox;

    private void Awake()
    {
        _boxCollid = GetComponent<BoxCollider2D>();
        _boxCollid.isTrigger = true;

        if (!GameObject.FindGameObjectWithTag("DialogueBox").TryGetComponent<DialogueBox>(out _dialogueBox)) Debug.LogError("Either no GameObject with \"DialogueBox\" tag or this GameObject does not have a DialogueBox script attached to it.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _dialogueBox.PlayDialogue(textToPlay);
            Destroy(this.gameObject);
        }
    }
}