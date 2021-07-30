using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Vector3 _destination;
    void Start()
    {
        StartCoroutine(CoinAnimRoutine());
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position , _destination, 2 * Time.deltaTime);
    }


    IEnumerator CoinAnimRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.3f);
            _destination = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            yield return new WaitForSeconds(1.3f);
            _destination = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Destroy(this.gameObject);
        }
    }
}
