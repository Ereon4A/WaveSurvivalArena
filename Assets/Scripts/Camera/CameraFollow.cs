using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 10f, -6f);
    [SerializeField] private float smoothSpeed = 10f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPisition = target.position - offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPisition,
            smoothSpeed * Time.deltaTime
        );
    }
}
