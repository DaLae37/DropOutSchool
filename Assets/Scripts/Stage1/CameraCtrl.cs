using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {
    public static CameraCtrl instance;
    public Transform PlayerPos;
    public float turnAmount = 90;
    public float turnSpeed = 100;
    public bool cameraRot;
    public bool left;
	// Use this for initialization
	void Start () {
        cameraRot = false;
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (cameraRot)
        {
            float turnDig = turnSpeed * Time.deltaTime;
            turnAmount -= turnDig;
            transform.Rotate(new Vector3(0, 0, turnDig));
            if ((turnAmount <= 0 && !left) || (turnAmount >= 0 && left))
            {
                cameraRot = false;
                transform.Rotate(new Vector3(0, 0, turnAmount));
            }
        }
	}
    private void FixedUpdate()
    {
        transform.position = new Vector3(PlayerPos.position.x, PlayerPos.position.y, -10);
    }
}
