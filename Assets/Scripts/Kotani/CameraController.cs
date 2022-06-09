using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    private Vector3 cameraVec;
    private Vector3 playercamera;
    void Start()
    {
        playercamera.x = player.transform.position.x;
        cameraVec.z = -15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        cameraVec.x = player.transform.position.x;
        cameraVec.y = player.transform.position.y;
        this.transform.position  = cameraVec;
        //cameraVec.y = player.transform.position.y; 
    }
}
