using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;
using TMPro;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{
    
    private int trollCount = 0;

    public TextMeshProUGUI quitText;
    public AudioSource pipe;

    public void troll()
    {
        string[] quitMsg = {
            "Lmao, Nice Try!", "Get trolled nerd!", "Need a hint?", "Too bad", "L + Ratio", "Okay, I'll confess.", "It's me!", "Click me!",
        "Why are you still here?", "Go away", "Touch some grass", "THAT HURTS!", "STOP!!!", "I swear to god...", "if you click that button...", "one more time...", "AAaaAAAaaaaaHH!", "*dies*", "..." };

        quitText.text = quitMsg[trollCount];

        if (trollCount == quitMsg.Length - 1)
        {
            trollCount = 0;
        }

        else if (trollCount == quitMsg.Length - 2)
        {
            pipe.Play();
        }

        else
        {
            trollCount++;
        }
    
     }
}

