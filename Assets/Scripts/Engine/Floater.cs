using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public float speed = 1f;
    public float height = 1f;

    private float startingHeight;

    // Start is called before the first frame update
    void Start()
    {
        startingHeight = transform.position.y;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        float newY = 1 + Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, (startingHeight + (newY * height)),  pos.z) ;
    }
}
