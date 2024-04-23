using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public int state;
    private int _nextState;

    private SpriteRenderer _sr;

    // Start is called before the first frame update
     void Awake()
    {
        // Ensure there is a box collider 2d
        if (!GetComponent<Collider2D>()) {
            gameObject.AddComponent<BoxCollider2D>();
        }
        _sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        UpdateColor(); // Set the color based on the initial state
    }

    public void evaluateNeighbors(CellScript nw, CellScript n, CellScript ne,
        CellScript w, CellScript e, CellScript sw, CellScript s, CellScript se)
    {
        int numNeighbors;
        numNeighbors = nw.state + n.state + ne.state + w.state + e.state + sw.state + s.state + se.state;
        if (numNeighbors<2) {
            _nextState = 0;
        } else if (numNeighbors>3) {
            _nextState = 0;
        } else if (state==1 && ((numNeighbors==2)|(numNeighbors==3))) {
            _nextState = 1;
        } else if ((state == 0) && (numNeighbors == 3)){
            _nextState = 1;
        }
    }

    private void OnMouseDown()
    {
        state = 1 - state;

    }

    public void updateState()
    {
        if (_nextState != state) {
            state = _nextState;
            UpdateColor();
        }
    }
    // Update is called once per frame
    void UpdateColor()
    {
        if (state==0)
        {
            _sr.color = Color.black;
        } else
        {
            _sr.color = Color.green;
        }
    }

    private void OnMouseEnter()
    {
        state = 1 - state; 
        UpdateColor(); // Update the color immediately to reflect the new state
    }
}
