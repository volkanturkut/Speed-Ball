using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    public float pushforce = 1000f;
    public float movement;

    [SerializeField]
    private float speed = 5f;
    private GameManager gameManager;
    public Vector3 respawnPoint;
    public AudioSource crashSound;

    private void Start()
    {
        respawnPoint = this.transform.position;
        rb = GetComponent<Rigidbody>();
        gameManager = Object.FindAnyObjectByType<GameManager>();
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, pushforce * Time.fixedDeltaTime);
        rb.linearVelocity = new Vector3(movement * speed, rb.linearVelocity.y, rb.linearVelocity.z);
        FallDetector();
    }

    private void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Brick"))
        {
            gameManager.RespawnPlayer();
            crashSound.Play();
        }
    }

    private void FallDetector()
    {
        if (rb.position.y < -2f)
        {
            gameManager.RespawnPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            Debug.Log("End trigger hit by player");
            gameManager.LevelUp();
        }
    }
}