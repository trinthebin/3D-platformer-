using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDoor : MonoBehaviour
{
    public bool isOpen = false;

    public Transform door;
    public Transform startingPoint;
    public Transform endPoint;

    private void Start()
    {
        door.position = startingPoint.position;
    }

    private void Update()
    {
        if (isOpen == true)
        {
            door.position = Vector3.MoveTowards(door.position, endPoint.position, Time.deltaTime);
        }
        
    }
}
