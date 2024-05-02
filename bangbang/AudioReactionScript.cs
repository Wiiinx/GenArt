using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReactionScript : MonoBehaviour
{
    public AudioSource audioSource;
    
    public float multiplier = 2f;
    public GameObject[] visualObjects;

    private float[] spectrum = new float[256];

    public float damping = 0.5f;
    public float minScale = 0.6f;  // 60% scale
    public float maxScale = 1.7f;  // 130% scale

    // Start is called before the first frame update
    void Start()
    {
        if (audioSource != null)
        {
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    float MapIntensityToScale(float intensity) {
        return Mathf.Lerp(minScale, maxScale, intensity);
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource != null && visualObjects.Length > 0)
        {
            audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
            int delta = spectrum.Length / visualObjects.Length;

            for (int i = 0; i < visualObjects.Length; i++)
            {
                int index = i * delta + 1;
                if (index < spectrum.Length && visualObjects[i] != null)
                {
                    float intensity = spectrum[index];  // Assuming this is already normalized
                    float scale = MapIntensityToScale(intensity);

                    visualObjects[i].transform.localScale = new Vector3(scale, scale, scale);
                }
            }
        }
    }

}
