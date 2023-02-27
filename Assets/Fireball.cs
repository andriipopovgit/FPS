using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        if (transform.position.y > 30)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        ReactiveTarget target = other.GetComponent<ReactiveTarget>();
        if (player != null)
        {
            Debug.Log("Player hit");
            player.Hurt(damage);
        }
        else if (target != null)
        {
            target.ReactToHit();
        }
        Destroy(this.gameObject);
    }
}
