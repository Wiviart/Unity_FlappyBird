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
        SECOND = 1.7f;
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(SECOND);
        Vector3 temp = pipe.transform.position;
        temp.y = Random.Range(-2.5f, 2.5f);
        Instantiate(pipe, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }
}
