using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBillboard : MonoBehaviour
{
    private Canvas canvas;

	private Transform camTransform;

    private float scaleCoefficient;

	Quaternion originalRotation;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;

        camTransform = Camera.main.transform;
        originalRotation = transform.rotation;

        scaleCoefficient = GetDistanceToCamera();
    }

    void Update()
    {
     	transform.rotation = camTransform.rotation * originalRotation;
   
        float distance = GetDistanceToCamera();
        float scale = (scaleCoefficient + (distance - scaleCoefficient)) / scaleCoefficient;
        transform.localScale = new Vector3(scale,
                                           scale,
                                           1f);
    }

    private float GetDistanceToCamera() {
        return Vector3.Distance(camTransform.transform.position, transform.position);
    }
}
