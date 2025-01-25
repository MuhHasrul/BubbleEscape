using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public GameObject explosionEffect; // Prefab efek ledakan
    public GameObject PanelWin;
    public GameObject PanelLose;
    public float destroyDelay = 2f;
    public float moveSpeed = 5f;
    public AudioSource runSound;
    public AudioSource audioWin;
    public AudioSource audioLose;
    public AudioSource audioTouch;
    public AudioSource audioSource;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 movePosition = transform.position;
    }
    void Awake()
    {
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (moveX != 0 || moveY != 0)
        {
            // Jika belum bergerak, mulai memutar suara berjalan (loop)
            if (!isMoving)
            {
                // moveSound.Stop();
                runSound.loop = true;
                runSound.Play();
                isMoving = true;
            }
        }
        else
        {
            // Hentikan suara jika tidak ada input
            if (isMoving)
            {
                runSound.loop = false;
                runSound.Stop();
                isMoving = false;
            }
        }
        
        Vector3 move = new Vector3(moveX*(-1), 0, moveY*(-1));
        transform.position += move * moveSpeed * Time.deltaTime;
    }

        void OnCollisionEnter(Collision collision)
    {
        // Cek apakah karakter bersentuhan dengan GameObject ber-tag "Jarum"
        if (collision.gameObject.CompareTag("Jarum"))
        {
            Explode();
            audioTouch.Play();
            audioSource.Stop();  
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            PanelWin.SetActive(true);
            audioWin.Play();
            audioSource.Stop(); 

        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            audioTouch.Play();
        }
    }

    void Explode()
    {
        // Tampilkan efek ledakan
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        // Hancurkan karakter setelah beberapa detik
        Destroy(gameObject, destroyDelay);

        PanelLose.SetActive(true);
        audioLose.Play();
    }

}

