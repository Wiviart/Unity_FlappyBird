using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public string POINT_TAG = "Point";
    public string PIPE_TAG = "Enemy";
    private Rigidbody2D myBody;
    public bool isAlive;
    public bool doFlap;
    [SerializeField] private float boundForce;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip fly, ping, dead;
    void Awake()
    {
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
    }
    //Nhung gi dung "Cơ chế vật lý" thi dung FixedUpdate
    void FixedUpdate()
    {
        BirdMovement();
    }
    void BirdMovement()
    {
        if (isAlive)
        {
            if (doFlap)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, boundForce);
                doFlap = false;
                if (audioSource != null)
                {
                    audioSource.PlayOneShot(fly);
                }
            }
            if (myBody.velocity.y > 0)
            {
                float angle = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else if (myBody.velocity.y == 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (myBody.velocity.y < 0)
            {
                float angle = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
    public void FlapButton()
    {
        doFlap = true;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(POINT_TAG))
        {
            FindObjectOfType<Score>().ScoreCount();

            audioSource.PlayOneShot(ping);

        }
        if (collider.CompareTag(PIPE_TAG))
        {
            isAlive = false;

            audioSource.PlayOneShot(dead);

        }
    }
}
