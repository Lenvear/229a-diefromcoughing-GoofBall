using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rigidbody2;
    [SerializeField] private Transform Start_Point;
    [SerializeField] private LineRenderer Line;
    
    [SerializeField] private float Timestep = 0.05f;
    [SerializeField] private int Stepcount = 15;

    private Vector2 Velocity, Startmouse_Pos, Currentmouse_Pos;
// Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rigidbody2.AddTorque(0.02f);
        }
        if(Input.GetKey(KeyCode.D))
        {
            rigidbody2.AddTorque(-0.02f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Startmouse_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
        if (Input.GetMouseButton(0))
        {
            Currentmouse_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Velocity = (Startmouse_Pos - Currentmouse_Pos) * 0.5f * Mathf.Abs(Physics2D.gravity.y);
            Draw_Line();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Prone();
        }
    }

    void Draw_Line()
    {
        Vector3[] positions = new Vector3[Stepcount];
        for (int i = 0; i < Stepcount; i++)
        {
            float t = i * Timestep;
            Vector3 pos = (Vector2)Start_Point.position + Velocity * t + 0.5f * Physics2D.gravity * t * t;

            positions[i] = pos;

        }

        Line.positionCount = Stepcount;
        Line.SetPositions(positions);
    }

    void Prone()
    { 
        rigidbody2.velocity = (Velocity);
    }
}
