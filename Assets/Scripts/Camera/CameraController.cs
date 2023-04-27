using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : Singleton<CameraController>
{

    public GameObject cameraObject;

    public Vector2 zoomBounds = new Vector2(5, 20);

    public float rotateSensitivity = 10f;

    public float zoomSensitivity = .5f;

    public float snapToObjectSpeed = .1f;

    public float translateSpeed = 10f;

    private Vector2 prevMousePos;

    // Start is called before the first frame update
    void Start()
    {
        prevMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentMousePos = Input.mousePosition;

        if(Input.GetMouseButton(2)) {
            transform.Rotate(new Vector3(0, (currentMousePos.x - prevMousePos.x) * rotateSensitivity * Time.deltaTime, 0));
        }

        float scrollAmount = Input.mouseScrollDelta.y * Time.deltaTime * zoomSensitivity;
        float clampedY = Mathf.Clamp(cameraObject.transform.localPosition.y - scrollAmount, zoomBounds.x, zoomBounds.y);
        float clampedZ = -Mathf.Clamp(-cameraObject.transform.localPosition.z - scrollAmount, zoomBounds.x, zoomBounds.y);

        cameraObject.transform.localPosition = new Vector3(cameraObject.transform.localPosition.x, clampedY, clampedZ);

        prevMousePos = currentMousePos;

        float verticalTranslation = Input.GetAxis("Vertical") * translateSpeed * Time.deltaTime;
        float horizontalTranslation = Input.GetAxis("Horizontal") * translateSpeed * Time.deltaTime;

        transform.Translate(new Vector3(horizontalTranslation, 0, verticalTranslation));
    }

    public void SetTarget(GameObject targetObject) {
        SetTarget(targetObject.transform.position);
    }

     public void SetTarget(Vector3 targetPosition) {
        transform.DOMove(new Vector3(targetPosition.x, transform.position.y, targetPosition.z), snapToObjectSpeed).SetEase(Ease.InOutSine);
    }
}
