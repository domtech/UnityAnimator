using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIK : MonoBehaviour
{
    public Transform targetTransform;

    public Animator animator;

    Camera Cam;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        var horizontal = Input.GetAxis("Horizontal");

        var vertical = Input.GetAxis("Vertical");


        targetTransform.position += (horizontal * Vector3.right + vertical * Vector3.forward) * Time.deltaTime;

    }

    private void OnAnimatorIK(int layerIndex)
    {
        //Debug.Log(layerIndex);
        if (layerIndex == 0)
            return;
        // Weapon Aim at Target IK
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        animator.SetIKPosition(AvatarIKGoal.RightHand, targetTransform.position);

        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, targetTransform.position);

        // Look at target IK
        animator.SetLookAtWeight(1);
        animator.SetLookAtPosition(targetTransform.position);

    }

}
