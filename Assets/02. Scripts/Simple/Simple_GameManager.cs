using System;
using System.Collections;
using Photon.Pun;
using UnityEngine;

public class Simple_GameManager : MonoBehaviourPun
{
    private IEnumerator Start()
    {
        yield return null;
        PhotonNetwork.Instantiate("Character", Vector3.zero, Quaternion.identity);
    }
}