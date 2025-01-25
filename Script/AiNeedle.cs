using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints; // Array waypoint untuk patroli
    public float moveSpeed = 2f;     // Kecepatan gerak musuh
    public float waitTime = 1f;      // Waktu menunggu di tiap waypoint
    public bool loop = true;         // Apakah patroli mengulang (loop)

    private int currentPointIndex = 0; // Indeks waypoint saat ini
    private bool isWaiting = false;    // Apakah musuh sedang menunggu
    private float waitTimer = 0f;      // Timer untuk menunggu

    void Update()
    {
        if (!isWaiting)
        {
            Patrol();
        }
        else
        {
            HandleWait();
        }
    }

    void Patrol()
    {
        // Dapatkan posisi waypoint saat ini
        Transform targetPoint = patrolPoints[currentPointIndex];

        // Gerakkan musuh ke arah waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        // Rotasikan musuh menghadap ke waypoint
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        // Jika sudah sampai di waypoint, tunggu sebelum lanjut
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            isWaiting = true;
            waitTimer = waitTime;

            // Update indeks waypoint
            currentPointIndex++;

            // Jika sudah sampai di akhir waypoint
            if (currentPointIndex >= patrolPoints.Length)
            {
                if (loop)
                {
                    currentPointIndex = 0; // Ulangi dari awal
                }
                else
                {
                    currentPointIndex = patrolPoints.Length - 1; // Tetap di titik terakhir
                }
            }
        }
    }

    void HandleWait()
    {
        // Hitung waktu tunggu
        waitTimer -= Time.deltaTime;
        if (waitTimer <= 0f)
        {
            isWaiting = false; // Lanjut patroli
        }
    }

    private void OnDrawGizmos()
    {
        // Gambar garis antara patrol points di editor
        Gizmos.color = Color.green;

        if (patrolPoints != null && patrolPoints.Length > 1)
        {
            for (int i = 0; i < patrolPoints.Length; i++)
            {
                Transform currentPoint = patrolPoints[i];
                Transform nextPoint = patrolPoints[(i + 1) % patrolPoints.Length];

                if (currentPoint != null && nextPoint != null)
                {
                    Gizmos.DrawLine(currentPoint.position, nextPoint.position);
                    Gizmos.DrawSphere(currentPoint.position, 0.3f);
                }
            }
        }
    }
}
