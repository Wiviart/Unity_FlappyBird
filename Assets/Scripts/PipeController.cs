using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float speed = 2f;
    public string DESTROYER_TAG = "Finish";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PipeMovement();
    }

    void PipeMovement()
    {
        Vector2 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }
    void OnTriggerEnter2D(Collider2D destroyer)
    {
        if (destroyer.CompareTag(DESTROYER_TAG)) Destroy(gameObject);
    }
}
