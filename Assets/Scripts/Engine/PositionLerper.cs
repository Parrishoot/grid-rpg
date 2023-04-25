using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLerper : MonoBehaviour
{
    public float totalLerpTime = .5f;

    public bool smoothFollow = false;

    public float smoothFollowSpeed = .1f;

    private float remainingLerpTime = 0f;

    private Vector3 targetPos;

    private Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!smoothFollow) {
            if(remainingLerpTime > 0) {
                transform.position = Vector3.Lerp(startingPos, targetPos, Mathf.SmoothStep(0, 1, (totalLerpTime - remainingLerpTime) / totalLerpTime));
                remainingLerpTime -= Time.deltaTime;
            }
            else if(remainingLerpTime <= 0 && transform.position != targetPos) {
                remainingLerpTime = 0;
                transform.position = targetPos;
            }
        }
        else {
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothFollowSpeed * Time.deltaTime);
        }

    }

    public void SetSnapTarget(Vector3 newTargetPos) {
        smoothFollow = false;
        if(targetPos != newTargetPos) {
            remainingLerpTime = totalLerpTime;
            targetPos = newTargetPos;
            startingPos = transform.position;
        }
    }

    public void SetSmoothFollowTarget(Vector3 newTargetPos) {
        smoothFollow = true;
        remainingLerpTime = 0f;
        targetPos = newTargetPos;
    }

    public bool IsAtTarget() {
        return transform.position == targetPos;
    }
}
