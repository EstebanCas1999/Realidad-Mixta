using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.Serialization;

public class HandInteractionTouchRotate : HandInteractionTouch, IMixedRealityTouchHandler
{
    [SerializeField]
    [FormerlySerializedAs("TargetObjectTransform")]
    private Transform targetObjectTransform = null;

    [SerializeField]
    private float rotateSpeed = 300.0f;

    void IMixedRealityTouchHandler.OnTouchUpdated(HandTrackingInputEventData eventData)
    {
        if (targetObjectTransform != null)
        {
            targetObjectTransform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime));
        }
    }
}
