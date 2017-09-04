using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    private Animator anim;
    private Vector2 touchPosition;
    private float swipeResistance = 200.0f;
    private bool isStarted;
    public float Speed = 5.0f;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        isStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!Stage1Mgr.instance.isGameOver)
        {
            if (isStarted)
            {
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
                        if (swipeForceX < 0)
                            Turn(-90);
                        else
                            Turn(90);
                    }
                    else if (Mathf.Abs(swipeForceY) >= swipeResistance && Mathf.Abs(swipeForceX) <= Mathf.Abs(swipeForceY))
                    {
                        if (swipeForceY < 0)
                        {
                            TurnTime();
                        }
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Start Game");
                    anim.SetBool("isStarted", true);
                    isStarted = true;
                }
            }
        }
    }
    void PlayerClear()
    {
        Stage1Mgr.instance.isGameOver = true;
        Stage1Mgr.instance.unHideClearPoP();
        anim.SetBool("isGameOver", true);
    }
    void PlayerOff()
    {
        Stage1Mgr.instance.isGameOver = true;
        Stage1Mgr.instance.unHideGameOverPoP();
        anim.SetBool("isGameOver", true);
    }
    void FixedUpdate()
    {
        if(isStarted && !Stage1Mgr.instance.isGameOver)
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
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall")
            PlayerOff();
    }
}
