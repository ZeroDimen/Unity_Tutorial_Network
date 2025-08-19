using System.Collections;
using Photon.Pun;
using UnityEngine;

public class Fight_GameManager : Singleton<Fight_GameManager>
{
    [SerializeField] private GameObject diedUI;
    private IEnumerator Start()
    {
        yield return null;
        var randomPos = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        PhotonNetwork.Instantiate("Fight_Character", randomPos, Quaternion.identity);
    }

    public void EndGame()
    {
        Fade.onFadeAction(3f, Color.black, true, () => diedUI.SetActive(true));
    }
}
