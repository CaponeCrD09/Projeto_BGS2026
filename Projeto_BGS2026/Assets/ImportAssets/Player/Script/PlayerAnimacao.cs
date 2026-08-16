using UnityEngine;

public class PlayerAnimacao : MonoBehaviour
{
    public Animator anim;
    public int transition;
    public Rigidbody rig;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<PlayerJump>().isGrounded && (this.GetComponent<PlayerMove>().v != 0 || this.GetComponent<PlayerMove>().h != 0))
        {
            transition = 1; // Corrida
            anim.SetInteger("transition", transition);

        }
        else if (this.GetComponent<PlayerJump>().isGrounded && (this.GetComponent<PlayerMove>().v == 0 && this.GetComponent<PlayerMove>().h == 0))
        {
            transition = 0; // Idle
            anim.SetInteger("transition", transition);
        }
        else if(rig.linearVelocity.y > 0.1f && !this.GetComponent<PlayerJump>().isGrounded)
        {
            transition = 2; // Rolamento
            anim.SetInteger("transition", transition);
        }
        else if (rig.linearVelocity.y < -0.1f && !this.GetComponent<PlayerJump>().isGrounded)
        {
            transition = 3; // Queda
            anim.SetInteger("transition", transition);
        }
        //else if (!this.GetComponent<PlayerJump>().isGrounded)
        //{
        //    transition = 2; // Pulo
        //    anim.SetInteger("transition", transition);
        //}
    }
}
