using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LessonPlan : MonoBehaviour
{
    /// <summary>
    /// Classifier the player can interact with
    /// </summary>
    public Classifier classifier;

    /// <summary>
    /// Instructions shown on the upper left of the screen.
    /// </summary>
    public TextMeshProUGUI instructions;
    
    /// <summary>
    /// UI element displaying weight, bias, accuracy, and loss
    /// </summary>
    public TextMeshProUGUI uiText;

    /// <summary>
    /// Parts in the lesson
    /// </summary>
    public enum State
    {
        Sharp,
        Fuzzy,
        Xor
    }

    /// <summary>
    /// Current part of the lesson
    /// </summary>
    public State state;
    
    // Start is called before the first frame update
    void Start()
    {
        state = State.Sharp;
        classifier.Instantiate(100, -30, 30, 0);
        instructions.text =
            "Find a line that best separates the red and blue dots. Bright dots are misclassified.\n"
            + "Controls:\n"
            + "Press A or D to decrease or increase weight.\n"
            + "Press S or W to decrease or increase bias.";
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = $"Weight: {classifier.weight:0.###}\n"
                      + $"Bias: {classifier.bias:0.###}\n"
                      + $"Accuracy: {classifier.previousAccuracy:0.###}\n"
                      + $"Loss: {classifier.previousLoss}";
        if (state == State.Sharp && classifier.previousAccuracy >= 0.98)
        {
            instructions.text =
                "Find a line that best separates the red and blue dots. Bright dots are misclassified.\n\n"
                + "Close enough. Press Space to continue.";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                state = State.Fuzzy;
                classifier.previousLoss = float.PositiveInfinity;
                classifier.previousAccuracy = 0;
                classifier.Instantiate(100, -30, 30, 10);
                instructions.text =
                    "Find a line that best separates the red and blue dots. Bright dots are misclassified.\n"
                    + "Controls:\n"
                    + "Press A or D to decrease or increase weight.\n"
                    + "Press S or W to decrease or increase bias.";
            }
        }
        else if (state == State.Sharp && classifier.previousAccuracy < 0.98)
        {
            instructions.text =
                "Find a line that best separates the red and blue dots. Bright dots are misclassified.\n"
                + "Controls:\n"
                + "Press A or D to decrease or increase weight.\n"
                + "Press S or W to decrease or increase bias.";
        }
        else if (state == State.Fuzzy && classifier.previousAccuracy >= 0.8)
        {
            instructions.text =
                "Find a line that best separates the red and blue dots. Bright dots are misclassified.\n\n"
                + "Close enough. Press Space to continue.";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                state = State.Xor;
                // classifier.Instantiate(100, -30, 30, 15);
                instructions.text =
                    "Hold on. Haven't written this part yet.\n";
            }
            
        }
        else if (state == State.Fuzzy && classifier.previousAccuracy < 0.8)
        {
            instructions.text =
                "Find a line that best separates the red and blue dots. Bright dots are misclassified.\n"
                + "Controls:\n"
                + "Press A or D to decrease or increase weight.\n"
                + "Press S or W to decrease or increase bias.";
        }
    }
}
