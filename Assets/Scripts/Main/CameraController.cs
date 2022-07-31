using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : Singleton<CameraController>
{
    public static bool IsZoom = false;
    public Transform followTf;
    [Header("Controls")]
    public bool lockToHorizontalAxis;


    [Header("Smooth")]
    public bool isSmooth = false;
    public float smoothSpeed = 5;
    public float smoothTime = 1f;
    [Header("Shake")]
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.1f;
    [Header("Zoom")]
    public float zoomDuration = 1;
    public float zoomMagnitude = 10;
    Vector3 offset, deltaOffset;
    private Vector3 currentVelocity;

    float max = Mathf.Infinity;
    bool maxFound = false;
    void Start()
    {
        IsZoom = false;
        offset = transform.position - followTf.position;
        deltaOffset = Vector3.zero;
    }
    void LateUpdate()
    {
        if (IsPlaying && followTf)
        {
            if (isSmooth)
            {
                var target = offset + deltaOffset + followTf.position;
                if (lockToHorizontalAxis)
                    target.y = transform.position.y;


                var viewPort = Camera.main.WorldToViewportPoint(GrassBlockManager.currentlvlEndPoint);


                // if(viewPortx<1)
                target.x = Mathf.Clamp(target.x, -10, max);

                if (viewPort.x <= 1)
                {
                    if (!maxFound)
                    {

                        max = transform.position.x;
                        maxFound = true;
                    }
                }


                transform.position = Vector3.SmoothDamp(
                    transform.position,
                    target,
                    ref currentVelocity,
                    smoothTime
                );


            }
            else
            {
                transform.position = offset + deltaOffset + followTf.position;
            }
        }
    }
    public void Shake()
    {
        StartCoroutine(Shake(shakeDuration, shakeMagnitude));
    }
    IEnumerator Shake(float duration, float magnitude)
    {
        for (float t = 0; t < duration; t += DT)
        {
            A.Cam.transform.localPosition = transform.TransformDirection(new Vector3(Rnd.Val1, Rnd.Val1, 0) * magnitude);
            yield return null;
        }
        A.Cam.transform.localPosition = Vector3.zero;
    }
    public void OffsetZoom(Vector3 pos)
    {
        StartCoroutine(OffsetZoom(pos, Vector3.Distance(transform.position, pos) / zoomMagnitude * zoomDuration));
    }
    IEnumerator OffsetZoom(Vector3 pos, float duration)
    {
        Vector3 deltaOffsetEnd = transform.position - (offset + followTf.position);
        for (float t = 0; t < duration; t += DT)
        {
            deltaOffset = Vector3.Lerp(deltaOffset, deltaOffsetEnd, t / duration);
            yield return null;
        }
        transform.position = pos;
    }
    public void Zoom(Vector3 pos)
    {
        StartCoroutine(Zoom(pos, Vector3.Distance(transform.position, pos) / zoomMagnitude * zoomDuration));
    }
    IEnumerator Zoom(Vector3 pos, float duration)
    {
        if (!IsZoom)
        {
            IsZoom = true;
            Vector3 startPos = transform.position;
            for (float t = 0; t < duration; t += DT)
            {
                transform.position = Vector3.Lerp(startPos, pos, t / duration);
                yield return null;
            }
            transform.position = pos;
            IsZoom = false;
        }
    }
}