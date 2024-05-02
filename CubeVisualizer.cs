using UnityEngine;

public class CubeVisualizer : MonoBehaviour
{
    public float maxHeight = 5.0f; // max height
    public float changeSpeed = 0.5f; // speed of change

    private Vector3 originalScale;

     void Start()
    {
        originalScale = transform.localScale;
        
        // Random initial color 
        float noise = Mathf.PerlinNoise(Random.value * changeSpeed, Random.value);
        Color newColor = Color.Lerp(Color.red, Color.blue, noise);
        GetComponent<Renderer>().material.color = newColor;
        
        // Random initial height
        float initialHeight = Random.Range(originalScale.y, maxHeight);
        transform.localScale = new Vector3(originalScale.x, initialHeight, originalScale.z);
    }


    void Update()
    {

        float newHeight = Random.Range(0, maxHeight);
        transform.localScale = new Vector3(originalScale.x, newHeight, originalScale.z);
        transform.localPosition = new Vector3(transform.localPosition.x, newHeight, transform.localPosition.z); // Adjust position so it grows upwards
        float noise = Mathf.PerlinNoise(Time.time * changeSpeed * 10, Random.value);
        Color newColor = Color.Lerp(Color.red, Color.blue, noise);
        GetComponent<Renderer>().material.color = newColor;
    }
}
