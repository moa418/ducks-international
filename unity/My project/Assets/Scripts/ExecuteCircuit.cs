using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class ExecuteCircuit : MonoBehaviour
{
    // Start is called before the first frame update
    public int state = 0;
    void Start()
    {
        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            state = Execute();
            UpdateColor();
        }
    }

    private int Execute()
    {
        ItemCollector ICRef = GetComponent<ItemCollector>();
        if (ICRef.gateCount > 0)
        {
            List<string> gates = ICRef.duckGates;
            ICRef.duckGates = new List<string> {};
            ICRef.gateCount = 0;
            ICRef.EmptyCircuit();

            System.Random random = new System.Random();
            int randomValue = random.Next(2);
            return randomValue;
        }
        
        return state;

    }

    private void UpdateColor()
    {   
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (state == 0)
        {
            sr.color = Color.red;
        }
        else if (state == 1)
        {
            sr.color = Color.blue;
        }
    }
}
