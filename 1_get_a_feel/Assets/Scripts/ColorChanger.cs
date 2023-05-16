using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    /// <summary>
    /// Enum corresponding to colors
    /// </summary>
    public enum Color
    {
        Misclassified,
        CorrectlyClassified
    }
    
    /// <summary>
    /// Materials. The first should be "bright". The second should be "dark".
    /// </summary>
    public Material[] colors;
    
    Renderer _modelRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _modelRenderer = gameObject.GetComponent<Renderer>();
    }
    
    /// <summary>
    /// Assign a color to the stripes (the second material) of the agent model.
    /// </summary>
    /// <param name="color">new color</param>
    public void SetColor(Color color)
    {
        if (_modelRenderer is null) return;
        
        var materials = _modelRenderer.materials;
        materials[0] = colors[(int)color];
        _modelRenderer.materials = materials;
    }
}
