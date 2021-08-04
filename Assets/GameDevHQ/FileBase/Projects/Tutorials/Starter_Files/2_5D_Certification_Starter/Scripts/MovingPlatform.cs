using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    Transform pointA, pointB;
    Vector3 destination;
    [SerializeField]
    float _speed;
   
    void Update()
    {
        GetDestination();
        transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
    }

    void GetDestination()
    {
        if(transform.position==pointA.position)
        {
            destination = pointB.position;
        }
        else if(transform.position==pointB.position)
        {
            destination = pointA.position;
        }
    }
}
