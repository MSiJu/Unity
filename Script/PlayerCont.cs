using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float speed = 3f;

    private Vector3 moveVelocity;
    private Rigidbody rb;
    private bool win = false;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //à⁄ìÆÉxÉNÉgÉãÇÃê≥ãKâªÇ∆à⁄ìÆï˚å¸Ç÷ÇÃë¨ìxÇÃälìæ

        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.W)) vertical += 1f;
        if (Input.GetKey(KeyCode.S)) vertical -= 1f;
        if (Input.GetKey(KeyCode.D)) horizontal += 1f;
        if (Input.GetKey(KeyCode.A)) horizontal -= 1f;

        Vector3 moveDirection = (transform.forward * vertical + transform.right * horizontal);

        if (moveDirection.magnitude > 0.1f)
        {
            moveDirection.Normalize();
        }
        
        moveVelocity = moveDirection * speed;
    }

    void FixedUpdate()
    {
        //à⁄ìÆèàóùÇ∆ÉQÅ[ÉÄÉNÉäÉAéûÇÃëÄçÏí‚é~

        if (win == true)
        {
            return;
        }

        // ï®óùââéZÇÕFixedUpdateÇ≈çsÇ§
        if (moveVelocity.magnitude > 0)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
    }

    public void WinCount()
    {
        //èüóòîªíË
        win = true;
    }
}
