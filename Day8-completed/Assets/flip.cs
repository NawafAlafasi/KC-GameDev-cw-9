using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flip : MonoBehaviour
{
    SpriteRenderer sprite;
    bool faceRight = true;
    public GameObject bullet;
    GameObject bulletClone;
    public float speed;
    public Transform leftSpawn;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
        fire();
    }

    void FlipPlayer()
    {
        if (Input.GetKeyDown(KeyCode.D) && faceRight == false)
        {
            sprite.flipX = false;
            faceRight = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) && faceRight == true)
        {
            sprite.flipX = true;
            faceRight = false;
        }
    }

    void fire()
    {
        if (Input.GetMouseButtonDown(0) && faceRight)
        {
            bulletClone = Instantiate(bullet, transform.position, transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            Destroy(bulletClone, 1.5f);
        }
        else if (Input.GetMouseButtonDown(0) && !faceRight)
        {
            bulletClone = Instantiate(bullet, leftSpawn.position, leftSpawn.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * -speed;
            Destroy(bulletClone, 1.5f);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy") 
        {
            SceneManager.LoadScene(0);
        }
    }
}
