using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trimmer : MonoBehaviour
{
    public float moveSpeed;
    public float rotSpeed;
    public Transform fan;
    public Transform rod;
    public Transform extension;

    public ParticleSystem grassCutMasPS;
    private GameObject _currentMask;

    private bool[,] visited = new bool[100, 100];

    public Transform gridOrigin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!A.IsPlaying) return;

        fan.rotation = Quaternion.Euler(0, 0, -rotSpeed * Time.deltaTime) * fan.rotation;

        grassCutMasPS.transform.position = fan.transform.position;

        // if (!visited[Mathf.RoundToInt(fan.position.x - gridOrigin.position.x), Mathf.RoundToInt(fan.position.y - gridOrigin.position.y)])
        // {
        //     grassParticles.Play();
        //     grassCutMasPS.Play();
        //     visited[Mathf.RoundToInt(fan.position.x - gridOrigin.position.x), Mathf.RoundToInt(fan.position.y - gridOrigin.position.y)] = true;
        // }
    }


    public void MoveAt(Vector3 position)
    {
        // fan.position = position;
        transform.rotation = Quaternion.LookRotation(-Vector3.forward, transform.position - position);
        // fan.position = position;
        // rod.up = fan.position -
        position.z = rod.position.z;
        var targetPos = position + rod.up * 2.189f;
        Vector3 dir = (targetPos - rod.position);
        if (dir.magnitude > 1)
            dir = dir.normalized;
        rod.position += dir * Time.deltaTime * moveSpeed;
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-Vector3.forward, transform.position - position), Time.deltaTime * 5);
        // var fanOffset = rod.position - fan.position;
        // var targetLoc = rod.localPosition;
        // float sign = Mathf.Sign(rod.InverseTransformPoint(position).y);
        // targetLoc.y = sign * rod.InverseTransformPoint(position).magnitude * 2f;

        // rod.localPosition = Vector3.Lerp(rod.localPosition, targetLoc, Time.deltaTime * 10);

        var targetScale = extension.localScale;
        targetScale.y = Mathf.Clamp((extension.localPosition - rod.localPosition).y * 5, 0, Mathf.Infinity);
        extension.localScale = targetScale;

    }

    public Vector3 GetFanPos()
    {
        return fan.position;
    }
}
