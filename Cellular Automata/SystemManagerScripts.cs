using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManagerScript : MonoBehaviour
{
    public GameObject prefabCell;
    const int wCells = 100;
    Vector2 startPosition = new Vector2(-5, -5);
    CellScript[,] cells = new CellScript[wCells, wCells];

    public float updateInterval = 0.5f;  // Time in seconds between automatic updates
    private float nextUpdateTime = 0;    // Time at which the next update will occur

    // Start is called before the first frame update
    void Start()
{
    for (int x = 0; x < wCells; x++)
    {
        for (int y = 0; y < wCells; y++)
        {
            Vector2 cellLocation = new Vector2(x, y) + startPosition;
            GameObject go = Instantiate(prefabCell, cellLocation, Quaternion.identity);
            cells[x, y] = go.GetComponent<CellScript>();
            cells[x, y].state = Random.Range(0, 2); // Assign a random state 0 or 1
        }
    }
    updateCells(); // Update cells state only once after all are initialized
}


    // Wrap function to keep the range of numbers between xCells
    int w(int n) {
        if (n<0) { n += wCells; }
        if (n>=wCells) { n -= wCells; }
        return n;
    }

    void updateCells()
    {
        // A loop that will have all the cells update nextState with rules based on
        //   neighbors
        for (int x = 0; x < wCells; x++)
        {
            for (int y = 0; y < wCells; y++)
            {
                cells[x, y].evaluateNeighbors(
                    cells[w(x - 1), w(y + 1)], cells[x, w(y + 1)], cells[w(x + 1), w(y + 1)],
                    cells[w(x - 1), y], cells[w(x + 1), y],
                    cells[w(x - 1), w(y - 1)], cells[x, w(y - 1)], cells[w(x + 1), w(y - 1)]
                );
            }
        }

        // A loop that will update the state to the nextState
        //   
        for (int x = 0; x < wCells; x++)
        {
            for (int y = 0; y < wCells; y++)
            {
                cells[x, y].updateState();
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            updateCells();
        }

    }
}
