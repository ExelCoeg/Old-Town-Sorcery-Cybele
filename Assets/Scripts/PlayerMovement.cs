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
        if(!GetComponent<PlayerPause>().pause){
            float direction = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            if(direction< 0){
                transform.eulerAngles = Vector2.up * -180;
                isFacingRight = false;
            }
            else{
                transform.eulerAngles = Vector2.zero;
                isFacingRight  = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!GetComponent<PlayerPause>().pause){
            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
            rb.velocity = playerSpeed * move;

            speed = Vector3.SqrMagnitude(rb.velocity);
            anim.SetFloat("speed", speed);
        }
    }


   
}
