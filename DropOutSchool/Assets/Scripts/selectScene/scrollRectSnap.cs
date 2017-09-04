using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scrollRectSnap : MonoBehaviour {
    public RectTransform panel;
    public Button[] bttn;
    public RectTransform center;
    public int startButton = 1;
    public float[] distance;
    public float[] distReposition;

    private bool dragging = false;
    private int bttnDistance;
    private int minButtonNum;
    private int bttnLength;
    private bool messageSend = false;
    private float lerpSpeed = 5f;
    void Start()
    {
        bttnLength = bttn.Length;
        distance = new float [bttnLength];
        distReposition = new float[bttnLength];

        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
        panel.anchoredPosition = new Vector2((startButton - 1) * -300,0);
    }

    void Update()
    {
        for(int i = 0; i<bttn.Length; i++)
        {
            distReposition[i] = center.GetComponent<RectTransform>().position.x - bttn[i].GetComponent<RectTransform>().position.x;
            distance[i] = Mathf.Abs(distReposition[i]);

            if(distReposition[i] > 1700)
            {
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchoredPos = new Vector2(curX + (bttnLength * bttnDistance), curY);
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            }
            if(distReposition[i] < -1700)
            {
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchoredPos = new Vector2(curX - (bttnLength * bttnDistance), curY);
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            }
        }

        float minDistance = Mathf.Min(distance);

        for(int a=0; a<bttn.Length; a++)
        {
            if (minDistance == distance[a])
            {
                minButtonNum = a;
            }
        }
        if (!dragging)
        {
            LerpToBttn(-bttn[minButtonNum].GetComponent<RectTransform>().anchoredPosition.x);
        }
    }
    void LerpToBttn(float position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * lerpSpeed);
        if (Mathf.Abs(position - newX) < 3f)
            newX = position;

        if(Mathf.Abs(newX) >= Mathf.Abs(position) -1 && Mathf.Abs(newX) <= Mathf.Abs(position) + 1 && !messageSend)
        {
            messageSend = true;
            SendMessageFromButton(minButtonNum);
        }
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }
    void SendMessageFromButton(int bttnIndex)
    {
        if (bttnIndex - 1 == 3)
            Debug.Log("MESSAGE SEND");

    }
    public void StartDrag()
    {
        messageSend = false;
        lerpSpeed = 5f;
        dragging = true;
    }
    public void EndDrag()
    {
        dragging = false;
    }
}
