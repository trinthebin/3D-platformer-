using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loops : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 1; x < 101; x++)
        {
            Debug.Log(x);
        }


        for (int x = 2; x < 101; x = x + 2)
        {
            Debug.Log(x);
        }


        for (int x = 0; x < -1001; x--)
        {
            Debug.Log(x);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
