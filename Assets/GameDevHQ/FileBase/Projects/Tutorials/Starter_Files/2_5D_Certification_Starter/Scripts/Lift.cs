using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField]
    Transform _pointA, _pointB;
    [SerializeField]
    float _speed = 2.0f;
    [SerializeField]
    float downDistance = 0.1f;
    [SerializeField]
    Vector3 gotoPos;
    bool isPointA,callElevator;
    void Start()
    {
        StartCoroutine(LiftRoutine());
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(Mathf.Abs(transform.position.y) - Mathf.Abs(gotoPos.y)) < 0.05)
        {
            callElevator = false;

            if (isPointA)
            {
                isPointA = false;
            }
            else
            {
                isPointA = true;
            }
        }
        else
        {
            callElevator = true;
        }

        if (callElevator==true)
        {
            if (isPointA == false)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - downDistance, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + downDistance, transform.position.z);
            }
        }
    }
    IEnumerator LiftRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(6.0f);
            if(isPointA)
            {
                gotoPos.y = _pointB.position.y;
            }
            else
            {
                gotoPos.y = _pointA.position.y;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            other.gameObject.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            other.gameObject.transform.parent = null;
        }
    }
}
