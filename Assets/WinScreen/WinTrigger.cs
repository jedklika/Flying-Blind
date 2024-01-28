using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class WinTrigger : MonoBehaviour
{
    public UnityEvent OnWin;
    private BoxCollider2D _boxColld;

    private void Awake()
    {
        _boxColld = GetComponent<BoxCollider2D>();
        _boxColld.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnWin?.Invoke();
            if (collision.gameObject.TryGetComponent<Playermove>(out Playermove player))
            {
                player.gameWon = true;
            }
        }
    }
}
