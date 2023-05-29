using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SphereGenerator : MonoBehaviour
{
    public float maxWeightMagnitude = 3f;

    public float minWeightMagnitude = 0.5f;

    /// <summary>
    /// class 0 sphere prefab to clone
    /// </summary>
    public GameObject redSphere;

    /// <summary>
    /// class 1 sphere prefab to clone
    /// </summary>
    public GameObject blueSphere;

    /// <summary>
    /// Weight from the previous time GenerateSpheres was called.
    /// </summary>
    public float previousWeight;

    /// <summary>
    /// Bias from the previous time GenerateSpheres was called.
    /// </summary>
    public float previousBias;


    public List<GameObject> GenerateLinearlySeparableSpheres(int number, float low, float high, float noise)
    {
        previousWeight = Random.value * (maxWeightMagnitude - minWeightMagnitude) + minWeightMagnitude;
        if (Random.value < 0.5)
        {
            previousWeight = -previousWeight;
        }
        previousBias = (Random.value * (high - low) + low) / 2;

        var dataset = new List<GameObject>();

        for (var i = 0; i < number; i++)
        {
            var x = Random.value * (high - low) + low;
            var y = Random.value * (high - low) + low;
            var position = new Vector3(x, y, 0f);
            if (previousWeight * x + previousBias < y)
            {
                dataset.Add(Instantiate(blueSphere,
                    position + noise * new Vector3(Normal(), Normal(), 0f),
                    Quaternion.identity,
                    transform.parent));
            }
            else
            {
                dataset.Add(Instantiate(redSphere,
                    position + noise * new Vector3(Normal(), Normal(), 0f),
                    Quaternion.identity,
                    transform.parent));
            }
        }

        return dataset;
    }

    public List<GameObject> GenerateXorSpheres(int number, float low, float high, float noise)
    {
        var dataset = new List<GameObject>();

        for (var i = 0; i < number; i++)
        {
            var x = Random.value * (high - low) + low;
            var y = Random.value * (high - low) + low;
            var position = new Vector3(x, y, 0f);

            if (position.x * position.y > 0)
            {
                dataset.Add(Instantiate(blueSphere,
                    position + noise * new Vector3(Normal(), Normal(), 0f),
                    Quaternion.identity,
                    transform.parent));
            }
            else
            {
                dataset.Add(Instantiate(redSphere,
                    position + noise * new Vector3(Normal(), Normal(), 0f),
                    Quaternion.identity,
                    transform.parent));
            }
        }

        return dataset;
    }

    static float Normal(float mean = 0f, float standardDeviation = 1f)
    {
        return mean + standardDeviation * Mathf.Sqrt(-2f * Mathf.Log(Random.value))
                                        * Mathf.Sin(2f * Mathf.PI * Random.value);
    }
}
