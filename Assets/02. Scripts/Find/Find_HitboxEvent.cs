using System;
using Photon.Pun;
using UnityEngine;

public class Find_HitboxEvent : MonoBehaviour
{
    private PhotonView myPv;

    void Awake()
    {
        myPv = transform.root.GetComponent<PhotonView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            other.GetComponent<Find_AgentController>().GetHit();
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<Find_PlayerController>().GetHit();

            if (myPv.IsMine)
            {
                bool isWinner = Find_GameManager.Instance.SetScore();

                if (isWinner)
                {
                    string nickName = myPv.Owner.NickName;
                    myPv.RPC("Winner", RpcTarget.AllBuffered, nickName);
                }
            }
        }
    }
}