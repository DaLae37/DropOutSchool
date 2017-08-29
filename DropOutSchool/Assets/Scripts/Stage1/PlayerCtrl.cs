using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    private Vector2 touchPosition;
    private float swipeResistance = 200.0f;
    public float Speed = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            touchPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            float swipeForceX = touchPosition.x - Input.mousePosition.x;
            float swipeForceY = touchPosition.y - Input.mousePosition.y;
            if (Mathf.Abs(swipeForceX) >= swipeResistance && Mathf.Abs(swipeForceX) >= Mathf.Abs(swipeForceY))
            {
                if(swipeForceX < 0)
                    Turn(-90);
                else
                    Turn(90);
            }
            else if(Mathf.Abs(swipeForceY) >= swipeResistance && Mathf.Abs(swipeForceX) <= Mathf.Abs(swipeForceY))
            {
                if(swipeForceY < 0)
                {
                    TurnTime();
                }
            }
        }
    }
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, Speed, 0) * Time.smoothDeltaTime);
    }
    public void Turn(int amount)
    {
        if (!CameraCtrl.instance.cameraRot)
        {
            transform.Rotate(new Vector3(0, 0, amount));
            if (amount < 0)
                CameraCtrl.instance.left = true;
            else
                CameraCtrl.instance.left = false;
            CameraCtrl.instance.cameraRot = true;
            CameraCtrl.instance.turnAmount = amount;
            CameraCtrl.instance.turnSpeed = amount;
        }
    }
    public void TurnTime()
    {

    }
}
