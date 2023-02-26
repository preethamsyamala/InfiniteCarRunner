using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTile : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform leftPos;
    public Transform rightPos;

    void Awake(){
        if (startPos == null){
            startPos = gameObject.transform.Find("Start Point");
        }
        if (endPos == null){
            endPos = gameObject.transform.Find("End Point");
        }
        if (leftPos == null){
            leftPos = gameObject.transform.Find("Left Point");
        }
        if (rightPos == null){
            rightPos = gameObject.transform.Find("Right Point");
        }
    }
}
