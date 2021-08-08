using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField]
    Transform exitPos;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            Player player = other.GetComponent<Player>();
            if(player!=null)
            {
                if(Input.GetKeyDown(KeyCode.Q))
                {
                    player.LadderClimb(exitPos);
                }
                
            }
        }
    }
}
