using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveImage : MonoBehaviour
{
    private RectTransform rt;
    private RawImage image;
    private float width;
    private int count = 6;//一行总共有几个image
    private int space = 50;//image之间的间隔
    private float speed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        rt = this.GetComponent<RectTransform>();
        image = this.GetComponent<RawImage>();
        width = rt.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (rt.anchoredPosition.x < -width)
        {
            rt.anchoredPosition = new Vector2((count-1)*(width)+count*space, rt.anchoredPosition.y);
            image.texture = LoopUIManager.Instance.GetTexture();
        }
    }
    
    
}
