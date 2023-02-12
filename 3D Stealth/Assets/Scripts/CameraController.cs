using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = .1f;
    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 TargetPostiion = target.position - offset;
        Vector3 SmoothFollow = Vector3.Lerp(transform.position, TargetPostiion, smoothSpeed);
        transform.position = SmoothFollow;
    }
}
