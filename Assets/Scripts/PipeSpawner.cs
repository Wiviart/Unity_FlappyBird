using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    [SerializeField] private float SECOND;
    // Start is called before the first frame update
    void Start()
    {
        SECOND = 2f;
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.FindObjectOfType<Score>().score >= 150) SECOND = 1.25f;
        else if (Score.FindObjectOfType<Score>().score >= 100) SECOND = 1.5f;
        else if (Score.FindObjectOfType<Score>().score >= 50) SECOND = 1.75f;
    }

    IEnumerator Spawner()
    {
        Debug.Log(SECOND);
        yield return new WaitForSeconds(SECOND);
        Vector3 temp = pipe.transform.position;
        temp.y = Random.Range(-2.5f, 2.5f);
        Instantiate(pipe, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }
}
