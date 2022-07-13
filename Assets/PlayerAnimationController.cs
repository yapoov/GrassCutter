using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    Animator _animator;
    public Transform leftHandTarget, rightHandTarget, lookAt;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnAnimatorIK(int layerIndex)
    {
        //lhand
        _animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
        _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
        _animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
        _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);

        //rhand
        _animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);

        _animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);
        _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);


        _animator.SetLookAtPosition(lookAt.position);
        _animator.SetLookAtWeight(1f);
    }
}
