using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trimmer : MonoBehaviour
{
    public float rotSpeed;
    public Transform fan;
    public Transform rod;
    public Transform extension;



    private GameObject _currentMask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!A.IsPlaying) return;

        fan.rotation = Quaternion.Euler(0, 0, -rotSpeed * Time.deltaTime) * fan.rotation;


    }


    public void MoveAt(Vector3 position)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-Vector3.forward, transform.position - position), Time.deltaTime * 5);
        var fanOffset = rod.position - fan.position;
        var targetLoc = rod.localPosition;
        float sign = Mathf.Sign(rod.InverseTransformPoint(position).y);
        targetLoc.y = sign * rod.InverseTransformPoint(position).magnitude;

        rod.localPosition = Vector3.Lerp(rod.localPosition, targetLoc, Time.deltaTime * 10);

        var targetScale = extension.localScale;
        targetScale.y = (rod.position - extension.position).magnitude * 5;
        extension.localScale = targetScale;

    }

    public Vector3 GetFanPos()
    {
        return fan.position;
    }
}
