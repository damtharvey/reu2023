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
        classifier.MakeLinearlySeparableInstance(100, -30, 30, 0);
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
                      + $"Loss: {classifier.previousLoss}\n"
                      + $"Best accuracy: {classifier.bestAccuracy}\n"
                      + $"Best loss: {classifier.bestLoss}";
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
                classifier.MakeLinearlySeparableInstance(100, -30, 30, 5);
                instructions.text =
                    "Find a line that best separates the red and blue dots. Bright dots are misclassified.\n"
                    + "This instance has some noise. You probably can't classify them all correctly.";
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
        else if (state == State.Fuzzy && classifier.previousAccuracy >= 0.85)
        {
            instructions.text =
                "Find a line that best separates the red and blue dots. Bright dots are misclassified.\n"
                + "This instance has some noise. You probably can't classify them all correctly.\n"
                + "Close enough. Press Space to continue.";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                state = State.Xor;
                classifier.previousAccuracy = 0;
                classifier.MakeXorInstance(100, -30, 30, 5);
                instructions.text =
                    "Here is the (trivial in hindsight) XOR problem.\n"
                    + "What's your best accuracy?\n\n"
                    + "Press Escape when you're sick of this.";
            }
            
        }
        else if (state == State.Fuzzy && classifier.previousAccuracy < 0.85)
        {
            instructions.text =
                "Find a line that best separates the red and blue dots. Bright dots are misclassified.\n"
                + "This instance has some noise. You probably can't classify them all correctly.";
        }
        // else // state == State.Xor
        // {
        //     
        // }
    }
}
