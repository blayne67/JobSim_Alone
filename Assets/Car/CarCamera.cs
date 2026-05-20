using UnityEngine;

public class CarCameraLean : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0, 3, -6);
    public float followSpeed = 6f;

    [Header("Lean")]
    public float maxLean = 5f;
    public float leanSmooth = 5f;

    private float currentLean;

    void LateUpdate()
    {
        float steer = Input.GetAxis("Horizontal");

        Vector3 desiredPos =
            target.position +
            target.TransformDirection(offset);

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPos,
            followSpeed * Time.deltaTime
        );

        // CAMERA LEAN (THIS IS THE FORZA FEEL)
        float targetLean = -steer * maxLean;

        currentLean = Mathf.Lerp(currentLean, targetLean, Time.deltaTime * leanSmooth);

        transform.rotation = Quaternion.Euler(
            10f,
            target.eulerAngles.y,
            currentLean
        );
    }
}