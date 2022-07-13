using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Trimmer trimmer;
    Plane plane = new Plane(-Vector3.forward, Vector3.zero);
    Vector3 _mp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!A.IsPlaying) return;

        if (Input.GetMouseButton(0))
        {

            float dist;
            // var dir = Input.mousePosition - _mp;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            plane.Raycast(ray, out dist);
            // if (Vector3.Distance(trimmer.GetFanPos(), ray.GetPoint(dist)) > 1f)
            trimmer.MoveAt(ray.GetPoint(dist));
            // cutter.position = Vector3.Lerp(cutter.position, cutter.position + dir, Time.deltaTime * 5);

        }

        _mp = Input.mousePosition;

    }
}
