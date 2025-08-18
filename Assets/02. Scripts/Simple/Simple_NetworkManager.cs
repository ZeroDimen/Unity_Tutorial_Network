using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Simple_NetworkManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "'1'";

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, false); // 해상도 설정
        PhotonNetwork.SendRate = 60; // 서버 전송률
        PhotonNetwork.SerializationRate = 30; // 전송률
        PhotonNetwork. GameVersion = gameVersion;
    }

    private void Start()
    {
        Connect();
    }

    private void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("서버 접속");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 20 }, null);
        Debug.Log("서버 접속 완료");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("방 입장");
        PhotonNetwork.Instantiate("Character", Vector3.zero, Quaternion.identity); // Resources 폴더에 있는 Character이름의 오브젝트 생성
    }
}
