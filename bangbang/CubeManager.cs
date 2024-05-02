using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfCubes = 10;
    public float spacing = 2.0f;
    public float zPosition = 0.0f; 

    void Start()
    {
        // Calculate the start position so that cubes are centered around the origin
        float startPosition = -(numberOfCubes / 2 * spacing) + spacing / 2;

        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 position = new Vector3(startPosition + i * spacing, 0, zPosition);
            GameObject newCube = Instantiate(cubePrefab, position, Quaternion.identity);
            newCube.transform.parent = this.transform; 
        }
    }
}
