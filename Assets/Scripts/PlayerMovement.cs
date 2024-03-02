using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    Vector3 move;

    [SerializeField] float playerSpeed;
    float speed;

    public bool isFacingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (move.x < 0 && isFacingRight)
        {
            transform.eulerAngles = Vector2.up * 180;
            isFacingRight = false;
        }

        if (move.x > 0 && !isFacingRight)
        {
            transform.eulerAngles = Vector2.zero;
            isFacingRight = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        rb.velocity = playerSpeed * move;

        speed = Vector3.SqrMagnitude(rb.velocity);
        anim.SetFloat("speed", speed);
    }
}
