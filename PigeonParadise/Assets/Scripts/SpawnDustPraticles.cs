using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDustPraticles : MonoBehaviour {

    public GameObject dustObject;
    public Pigeon pigeonScript;
   
    void Start() {

        GameObject thePigeon = GameObject.Find("Pigeon");
        pigeonScript = thePigeon.GetComponent<Pigeon>();
       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Cloud") && pigeonScript.bounceCooldownActive)
        {
            Vector2 position = new Vector2(this.transform.position.x - 0, this.transform.position.y-0.5f);
            GameObject dustPuff = Instantiate(dustObject, position, this.transform.rotation);
       

            Destroy(dustPuff, 1.0f);
        }
    
    }

}
