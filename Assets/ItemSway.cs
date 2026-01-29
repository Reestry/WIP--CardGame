using System;
using UnityEngine;

public class ItemSway : MonoBehaviour
{
    private Quaternion _targetRotation;
    [SerializeField] private float _swaymult = 5;

    private void Update()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation,
            new Quaternion( _targetRotation.x,  _targetRotation.y, 0, transform.localRotation.w),
            Time.deltaTime * 1.2f);
    }

    public void Sway(Vector2 angle)
    {
        angle *= _swaymult;
        var rotationx = Quaternion.AngleAxis(-angle.x, Vector3.up);
        var rotationy = Quaternion.AngleAxis(angle.y, Vector3.right);

        _targetRotation = rotationx * rotationy;
    }

    public void ResetSway()
    {
        _targetRotation = new Quaternion(0, 0, 0, 0);
    }
}