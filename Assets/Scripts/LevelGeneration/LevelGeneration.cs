using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviourSingleton<LevelGeneration>
{
    [SerializeField] private List<GameObject> chunks;
    private int currindex = 1;
    [SerializeField] private Vector3 leftOffset;
    [SerializeField] private Vector3 rightOffset;
    [SerializeField] private Vector3 topOffset;
    [SerializeField] private Vector3 bottomOffset;

    public void Generate(Vector3 velocity)
    {

        if (Mathf.Abs(velocity.x) - Mathf.Abs(velocity.z) > 0)
        {
            if(velocity.x < 0)
            {
                int prevIndexBot = currindex % 3 == 2 ? 0 : currindex % 3 + 1;
                int prevIndexTop = prevIndexBot + 3;
                Debug.Log("left" + prevIndexBot + prevIndexTop);
                
                // currentindex >= 3 ? 0 1 2 : 3 4 5
                // currentindex % 3 == 2 ? 5 2 : 3 0 4 1
                chunks[prevIndexBot].transform.position += leftOffset * 3;
                chunks[prevIndexTop].transform.position += leftOffset * 3;

            }
            else
            {
                int prevIndexBot = currindex % 3 == 0 ? 2 : currindex % 3 - 1;
                int prevIndexTop = prevIndexBot + 3;
                Debug.Log("right" + prevIndexBot + prevIndexTop);

                chunks[prevIndexBot].transform.position += rightOffset * 3;
                chunks[prevIndexTop].transform.position += rightOffset * 3;


            }
        }
        else
        {
            int prevIndexLeft = currindex < 3 ? 0 : 3;
            int prevIndexMiddle = currindex < 3 ? 1 : 4;
            int prevIndexRight = currindex < 3 ? 2 : 5;
            if (velocity.z > 0)
            {
                
                Debug.Log("up" + prevIndexLeft + prevIndexMiddle + prevIndexRight);
                chunks[prevIndexLeft].transform.position += topOffset * 2;
                chunks[prevIndexMiddle].transform.position += topOffset * 2;
                chunks[prevIndexRight].transform.position += topOffset * 2;
            }
            else
            {
                Debug.Log("down" + prevIndexLeft + prevIndexMiddle + prevIndexRight);
                chunks[prevIndexLeft].transform.position += bottomOffset * 2;
                chunks[prevIndexMiddle].transform.position += bottomOffset * 2;
                chunks[prevIndexRight].transform.position += bottomOffset * 2;


            }
        }
    }

    internal void SetCurrent(string name)
    {
        currindex = name[0] - 48; // char ascii manipulation
    }
}
