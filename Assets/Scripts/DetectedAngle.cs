using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedAngle : MonoBehaviour
{
    [SerializeField] private float range = 5f;
    [SerializeField] private SkeletonAnimation skeletonAnimation;
    [SerializeField] private Material enemy;
    private string _currentAnimation = "";
    private float _angle = 35f;

    private void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit, range);

        if (Vector3.Angle(Vector3.up, hit.normal) >= _angle) 
        {
            SetAnimation("idle", true);
            enemy.color = Color.red;
        }
        else
        {
            SetAnimation("run", true);
            enemy.color = Color.white;
        }
    }

    private void SetAnimation(string name, bool loop)
    {
        if (name == _currentAnimation) return;
        skeletonAnimation.state.SetAnimation(0, name, loop);
        _currentAnimation = name;
    }
}
