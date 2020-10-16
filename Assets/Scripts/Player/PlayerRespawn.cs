using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform Player;
    public Transform RespawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        print("Y U BILLI CUKA BLYAT");
        Player.transform.position = RespawnPoint.transform.position;
    }
}
