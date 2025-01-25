using UnityEngine;

public class CameraLockOnTarget : MonoBehaviour
{
    public Transform target; // Objek target yang akan dikunci
    public Vector3 offset = new Vector3(0, 5, 0); // Jarak kamera dari target
    public float smoothSpeed = 0.125f; // Kecepatan smoothing kamera

    void LateUpdate()
    {
        if (target != null)
        {
            // Tentukan posisi kamera berdasarkan posisi target dan offset
            Vector3 desiredPosition = target.position + offset;

            // Lerp untuk smoothing posisi kamera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Atur posisi kamera
            transform.position = smoothedPosition;
        }
    }
}
