using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasureDuck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }
    }
}
