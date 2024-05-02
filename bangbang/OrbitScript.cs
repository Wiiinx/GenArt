using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSplitter : MonoBehaviour
{
    public GameObject prefab;
    public float orbitRadius = 5f;
    public float orbitPeriod = 2f;
    private List<GameObject> splitObjects = new List<GameObject>();
    private bool hasSplit = false;


    void Start()
    {
        Invoke("SplitIntoOrbit", 10f); 
    }

    void Update()
    {
        if (hasSplit)
        {
            for (int i = 0; i < splitObjects.Count; i++)
            {
                GameObject obj = splitObjects[i];
                // Calculate orbit position
                float angle = Time.time * Mathf.PI * 2 / orbitPeriod + Mathf.PI * 2 * i / splitObjects.Count;
                Vector3 orbitPosition = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * orbitRadius;
                obj.transform.localPosition = transform.position + orbitPosition;

                // Randomly change scale
                float scale = Random.Range(0.2f, 0.6f); // Change height randomly between 60% to 130%
                obj.transform.localScale = new Vector3(obj.transform.localScale.x, scale, obj.transform.localScale.z);
            }
        }
    }

    void SplitIntoOrbit()
    {
        if (!hasSplit)
        {
            Vector3 originalPosition = transform.position; 
            for (int i = 0; i < 5; i++) // Split into 5 
            {
                // Create the clone at the same height as the original
                Vector3 clonePosition = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z);
                GameObject obj = Instantiate(prefab, clonePosition, Quaternion.identity);
                splitObjects.Add(obj);
            }
            hasSplit = true;
        }
    }

}
