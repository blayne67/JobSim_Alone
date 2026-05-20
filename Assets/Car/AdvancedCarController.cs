using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ZeroAccelCar : MonoBehaviour
{
    [Header("Wheels")]
    public WheelCollider frontLeft;
    public WheelCollider frontRight;
    public WheelCollider rearLeft;
    public WheelCollider rearRight;

    [Header("Engine")]
    public float motorPower = 14000f;
    public float brakePower = 6000f;
    public float maxSpeed = 220f;

    [Header("Steering")]
    public float steerAngle = 45f;

    Rigidbody rb;

    float throttle;
    float steer;
    float brake;

    float currentSteer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.mass = 1600f;
        rb.centerOfMass = new Vector3(0, -0.6f, 0);

        rb.linearDamping = 0.05f;          // 🔥 stronger natural stop
        rb.angularDamping = 0.4f;
    }

    void Update()
    {
        throttle = Input.GetAxis("Vertical");
        steer = Input.GetAxis("Horizontal");
        brake = Input.GetKey(KeyCode.Space) ? 1f : 0f;
    }

    void FixedUpdate()
    {
        float speed = rb.linearVelocity.magnitude * 3.6f;

        FULL_RESET();          // 🔥 KEY FIX
        ApplyDrive(speed);
        ApplySteering();
        ApplyBrakes();
        HARD_STOP_FIX();       // 🔥 ENSURES ZERO ACCEL WITHOUT INPUT
    }

    // ---------------- FULL RESET ----------------
    void FULL_RESET()
    {
        rearLeft.motorTorque = 0f;
        rearRight.motorTorque = 0f;

        frontLeft.brakeTorque = 0f;
        frontRight.brakeTorque = 0f;
        rearLeft.brakeTorque = 0f;
        rearRight.brakeTorque = 0f;

        frontLeft.steerAngle = 0f;
        frontRight.steerAngle = 0f;
    }

    // ---------------- DRIVE ----------------
    void ApplyDrive(float speed)
    {
        // 🔥 CRITICAL: NO INPUT = NO TORQUE AT ALL
        if (Mathf.Abs(throttle) < 0.1f)
            return;

        float torque = throttle * motorPower;

        float speedFactor = Mathf.Clamp01(speed / maxSpeed);
        torque *= (1f - speedFactor * 0.4f);

        rearLeft.motorTorque = torque;
        rearRight.motorTorque = torque;
    }

    // ---------------- STEERING ----------------
    void ApplySteering()
    {
        float target = steer * steerAngle;

        currentSteer = Mathf.Lerp(currentSteer, target, Time.deltaTime * 10f);

        frontLeft.steerAngle = currentSteer;
        frontRight.steerAngle = currentSteer;
    }

    // ---------------- BRAKES ----------------
    void ApplyBrakes()
    {
        float b = brake * brakePower;

        frontLeft.brakeTorque = b;
        frontRight.brakeTorque = b;
        rearLeft.brakeTorque = b;
        rearRight.brakeTorque = b;
    }

    // ---------------- HARD STOP SYSTEM ----------------
    void HARD_STOP_FIX()
    {
        if (Mathf.Abs(throttle) < 0.1f)
        {
            Vector3 v = rb.linearVelocity;

            // kill forward motion completely
            v *= 0.96f;

            rb.linearVelocity = v;

            // safety: remove any leftover wheel drive force
            rearLeft.motorTorque = 0f;
            rearRight.motorTorque = 0f;
        }
    }
}