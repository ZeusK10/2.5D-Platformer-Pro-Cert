using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeCheck : MonoBehaviour
{
    [SerializeField]
    Transform playerGrabPos, climbedPos;

    Vector3 _playerGrabPos,_climbedPos;

    private void Start()
    {
        _playerGrabPos = playerGrabPos.position;
        _climbedPos = climbedPos.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Ledge_Checker")
        {
            Player player = other.gameObject.GetComponentInParent<Player>();
            if(player!=null)
            {
                player.PlayLedgeGrabAnimation(_playerGrabPos,this);
            }
        }
    }

    public Vector3 ClimbedPos()
    {
        return _climbedPos;
    }
}
