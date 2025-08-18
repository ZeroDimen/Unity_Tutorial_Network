using System;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Simple_PlayerController : MonoBehaviourPun
{
    private CharacterController cc;
    
    [SerializeField] private TextMeshPro nickName;
    [SerializeField] private GameObject hat;

    private Vector3 moveInput;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float turnSpeed = 10f;

    private void Start()
    {
        cc = GetComponent<CharacterController>();

        if (photonView.IsMine) // 플레이어 화면 기준 캐릭터 닉네임설정
        {
            nickName.text = PhotonNetwork.NickName;
            nickName.color = Color.green;
        }
        else
        {
            nickName.text = photonView.Owner.NickName;
            nickName.color = Color.red;
        }
    }


    private void Update()
    {
        if (photonView.IsMine)
        {
            Move();
            Turn();
        }
    }

    private void Move()
    {
        cc.Move(moveInput * (moveSpeed * Time.deltaTime));
    }

    private void OnMove(InputValue value)
    {
        var moveValue = value.Get<Vector2>();
        moveInput = new Vector3(moveValue.x, 0, moveValue.y);
    }

    private void Turn()
    {
        if (moveInput == Vector3.zero)
        {
            return;
        }
        Quaternion targetRot = Quaternion.LookRotation(moveInput);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * turnSpeed);
    }

    private void OnHatOn()
    {
        if (photonView.IsMine)
        {
            photonView.RPC("Hat", RpcTarget.All, true); // Hat 함수를 다른 플레이어도 확인하는 함수
        }
    }
    
    private void OnHatOff()
    {
        if (photonView.IsMine)
        {
            photonView.RPC("Hat", RpcTarget.All,false); // Hat 함수를 다른 플레이어도 확인하는 함수
        }
    }

    [PunRPC]
    public void Hat(bool isOn)
    {
        hat.SetActive(isOn);
    }
    
}