using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    public Animator anim;
    public float Speed;
    public float BounceForce;
    public float BounceCooldown;
    public PlayJumpSound playJumpSoundScript;

    public int NumFeathers { get; set; }

    private Rigidbody2D rb;
    public bool bounceCooldownActive = false;
    public GameObject featherParticleObject;
    private GameObject clone;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playJumpSoundScript = this.GetComponent<PlayJumpSound>();
    }

    public void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * Speed, rb.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Cloud") && !bounceCooldownActive)
        {
            rb.AddForce(Vector2.up * BounceForce, ForceMode2D.Impulse);
            StartCoroutine(WaitForJumpCooldown());
            playJumpSoundScript.PlayRandomJumpSound();

            anim.SetTrigger("PlayerHitsObject");

            

            clone = Instantiate(featherParticleObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            Destroy(clone, 2f);

            //  collision.gameObject.GetComponent<AnimationCloud>().anim.SetTrigger("PigeonHitsCloud");
        }
       
    }

    public IEnumerator WaitForJumpCooldown()
    {
        bounceCooldownActive = true;
        yield return new WaitForSeconds(BounceCooldown);
        bounceCooldownActive = false;
    }
}
