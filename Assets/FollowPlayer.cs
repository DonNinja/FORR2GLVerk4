using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public Transform Player;

    public Vector3 cameraOffset;
    
    private readonly float smoothFactor = 1f;

    public float rotationSpeedHor = 5f;
    //public float rotationSpeedVert = 5f;

    // Use this for initialization
    void Start () {
        cameraOffset = transform.position - Player.position;
	}

    void LateUpdate () {

        Quaternion camTurnAngleHor = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeedHor, Vector3.up);
        cameraOffset = camTurnAngleHor * cameraOffset;

        //Quaternion camTurnAngleVert = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotationSpeedVert, Vector3.left);
        //cameraOffset = camTurnAngleVert * cameraOffset;

        Vector3 newPos = Player.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        transform.LookAt(Player);
	}
}
