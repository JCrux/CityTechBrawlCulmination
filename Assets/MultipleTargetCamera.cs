using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform>targets;

    public Vector3 offset;
    public float smoothTime = .5f;

    public float minZoon = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    // for camera bounds
    public Vector3 minValues, maxValues;
    //

    private Vector3 velocity;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        
    }

    void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        Move();
        Zoom();

    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoon, GetGreatestDistance() /zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    void Move()// aka follow
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        //trying code for camera bound 
        Vector3 boundPosition = new Vector3(Mathf.Clamp(newPosition.x, minValues.x, maxValues.x),
                                            Mathf.Clamp(newPosition.y, minValues.y, maxValues.y),
                                            Mathf.Clamp(newPosition.z, minValues.z, maxValues.z)); //right above minZ change back to newPos

        transform.position = Vector3.SmoothDamp(transform.position, boundPosition, ref velocity, smoothTime); // not part of cam bound script
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }


    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

}
