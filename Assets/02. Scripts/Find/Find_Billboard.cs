using UnityEngine;

public class Find_Billboard : MonoBehaviour
{
    public Transform mainCamera;

    void Awake()
    {
        mainCamera = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}