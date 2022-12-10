using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public Transform leftWheelTransform;
    public Transform rightWheelTransform;
    public bool motor;
    public bool steering;
}
public class CarMovement : MonoBehaviour
{
    public VariableJoystick joystick;
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float brakeForce;


    public float Speed;
    Player player;
    private void Start()
    {
        TryGetComponent<Player>(out player);
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        transform.position = position;
        transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        //if (!player.IsPlayerMove())
        //    return;

        float isMoving = (Input.GetMouseButton(0) == true) || Input.touchCount != 0 ? 1 : 0;
        float steering = maxSteeringAngle * joystick.Horizontal;
        float motor = maxMotorTorque * Speed * isMoving;
        float currentBrake = (isMoving == 0) ? brakeForce : 0f;

        Move(motor, steering, currentBrake);

    }
    void Move(float motor, float steering, float brake)
    {
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyBraking(brake);
            ApplyLocalPositionToVisuals(axleInfo.leftWheel, axleInfo.leftWheelTransform);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel, axleInfo.rightWheelTransform);

        }
    }
    void ApplyBraking(float brake)
    {
        foreach (AxleInfo axleInfo in axleInfos)
        {
            axleInfo.rightWheel.brakeTorque = brake;
            axleInfo.leftWheel.brakeTorque = brake;

        }
    }
}
