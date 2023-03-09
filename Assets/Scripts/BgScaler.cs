using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScaler : MonoBehaviour
{
    void Start()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float height = Camera.main.orthographicSize * 2f;
        float width = height * screenWidth / screenHeight;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float imageWidth = sr.bounds.size.x;
        float imageHeight = sr.bounds.size.y;

        float widthScaler = width / imageWidth;
        float heightScaler = height / imageHeight;

        transform.localScale = new Vector3(widthScaler, heightScaler, 0);
    }
}
