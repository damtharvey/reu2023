using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


public class Classifier : MonoBehaviour
{
    /// <summary>
    /// Sphere generator
    /// </summary>
    public SphereGenerator generator;

    /// <summary>
    /// Line for visualization
    /// </summary>
    public GameObject decisionLine;
    
    /// <summary>
    /// Linear classifier weight
    /// </summary>
    public float weight = 0;

    /// <summary>
    /// Linear classifier bias
    /// </summary>
    public float bias = 0;
    
    public float weightSensitivity = 1;
    
    public float biasSensitivity = 10;

    public float previousAccuracy;

    public float previousLoss;

    public float bestLoss;

    public float bestAccuracy;
    
    List<GameObject> _dataset;

    public void MakeLinearlySeparableInstance(int numberOfSpheres, float low, float high, float noise)
    {
        if (_dataset is not null)
        {
            foreach (var sphere in _dataset)
            {
                Destroy(sphere);
            }
        }
        weight = 0f;
        bias = 0f;
        _dataset = generator.GenerateLinearlySeparableSpheres(numberOfSpheres, low, high, noise);
        bestLoss = Mathf.Infinity;
        bestAccuracy = 0f;
    }
    
    public void MakeXorInstance(int numberOfSpheres, float low, float high, float noise)
    {
        if (_dataset is not null)
        {
            foreach (var sphere in _dataset)
            {
                Destroy(sphere);
            }
        }
        weight = 0f;
        bias = 0f;
        _dataset = generator.GenerateXorSpheres(numberOfSpheres, low, high, noise);
        bestLoss = Mathf.Infinity;
        bestAccuracy = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_dataset is null) return;
        
        if (Input.GetKey(KeyCode.A))
        {
            weight -= weightSensitivity * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            weight += weightSensitivity * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            bias -= biasSensitivity * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            bias += biasSensitivity * Time.deltaTime;
        }
        
        UpdateLine();

        var correct = 0;
        var loss = 0f;
        foreach (var sphere in _dataset)
        {
            var position = sphere.transform.position;
            var prediction = weight * position.x + bias < position.y;
            var label = sphere.CompareTag("class 1");
            if (prediction == label)
            {
                correct++; 
                sphere.GetComponent<ColorChanger>().SetColor(ColorChanger.Color.CorrectlyClassified);
            }
            else
            {
                sphere.GetComponent<ColorChanger>().SetColor(ColorChanger.Color.Misclassified);
            }
            
            var predictionFloat = Convert.ToSingle(prediction);
            var labelFloat = Convert.ToSingle(label);
            loss -= labelFloat * SafeLog(predictionFloat) + (1f - labelFloat) * SafeLog(1f - predictionFloat);
        }
        previousAccuracy = Convert.ToSingle(correct) / _dataset.Count;
        bestAccuracy = Mathf.Max(bestAccuracy, previousAccuracy);
        previousLoss = loss / _dataset.Count;
        bestLoss = Mathf.Min(bestLoss, previousLoss);
    }

    void UpdateLine()
    {
        decisionLine.transform.SetPositionAndRotation(new Vector3(0, bias, 0),
                                                       Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan(weight)));
    }

    /// <summary>
    /// Like the log inside PyTorch's BCELoss.
    /// </summary>
    /// <param name="x"></param>
    /// <returns>the clamped log of x</returns>
    static float SafeLog(float x)
    {
        if (x <= 0f)
        {
            return -100f;
        }
        return Mathf.Log(x);
    }
    

}
