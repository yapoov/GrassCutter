using UnityEngine;

public class Follow : MB {
    public Transform followTf;
    private void Update () {
        if (followTf.NotNull ())
            transform.position = followTf.position;
    }
}