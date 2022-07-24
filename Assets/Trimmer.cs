using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trimmer : MonoBehaviour
{
    [Header("Trimmer Stats")]
    public float moveSpeed;
    public float rotSpeed;
    public float sharpness;
    [Header("Parts")]
    public Transform fan;
    public Transform rod;
    public Transform extension;
    [Header("ParticleSystem")]
    public ParticleSystem grassCutMasPS;

    float maxSlowness = 2f;
    // private bool[,] visited = new bool[100, 100];
    float slowness;
    float slowRate = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!A.IsPlaying) return;

        fan.rotation = Quaternion.Euler(0, 0, -rotSpeed * (1 - slowRate * 0.9f) * Time.deltaTime) * fan.rotation;

        grassCutMasPS.transform.position = fan.transform.position;


        float hardness = 0;
        RaycastHit hit;
        if (Physics.Raycast(fan.position, Vector3.forward, out hit, 10, 1 << 4))
        {
            hardness = hit.collider.Gc<GrassPlane>().hardness;
        }
        var mainStartColor = grassCutMasPS.startColor;
        mainStartColor.a = 1 - slowRate;
        grassCutMasPS.startColor = mainStartColor;
        slowRate = Mathf.Lerp(slowRate, Mathf.Clamp01(Mathf.Clamp(hardness - sharpness, 0, Mathf.Infinity) / maxSlowness), Time.deltaTime * 5);


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
        var targetRotation = Quaternion.LookRotation(-Vector3.forward, transform.position - position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 - Mathf.Pow(slowRate, Time.deltaTime));
        // fan.position = position;
        // rod.up = fan.position -
        position.z = rod.position.z;
        var targetPos = position + rod.up * 2.189f;
        Vector3 dir = (targetPos - rod.position);
        if (dir.magnitude > 1)
            dir = dir.normalized;




        var displacement = dir * Time.deltaTime * moveSpeed;
        displacement -= displacement * slowRate * 0.9f;
        rod.position += displacement;


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
