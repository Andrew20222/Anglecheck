using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    private const string horizontal_name = "Horizontal";

    [SerializeField] private PhysicsMovement physicsMovement;
    [SerializeField] private SkeletonAnimation skeletonAnimation;
    private float _timeToRotate = 5f;
    private string _currentAnimation = "";
    private Quaternion _goalRotation = Quaternion.identity;

    private void Update()
    {
        float horizontal = Input.GetAxis(horizontal_name);
        if(horizontal < 0)
        {
            _goalRotation = Quaternion.Euler(0, 180, 0);
            SetAnimation("run", true);
        }
        else if(horizontal > 0)
        {
            _goalRotation = Quaternion.Euler(0, 0, 0);
            SetAnimation("run", true);
        }
        else
        {
            SetAnimation("idle", true);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _goalRotation, _timeToRotate * Time.deltaTime);

        physicsMovement.Move(new Vector3(horizontal, 0));
    }

    private void SetAnimation(string name, bool loop)
    {
        if (name == _currentAnimation) return;
        skeletonAnimation.state.SetAnimation(0, name, loop);
        _currentAnimation = name;
    }
}
