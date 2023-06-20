
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopUIManager : MonoBehaviour
{
    public static LoopUIManager Instance;
    private List<Texture2D> spritesList;
    private int index = 0;

    private void Awake()
    {
        if(Instance==null)
            Instance = this;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        var sp = Resources.LoadAll<Texture2D>("texture");
        spritesList = new List<Texture2D>(sp);
        for (int i = 0; i < transform.childCount; i++)
        {
            index = i;
            if (index < spritesList.Count)
            {
                transform.GetChild(i).GetComponent<RawImage>().texture = spritesList[index];
            }
            
        }
    }

    public Texture2D GetTexture()
    {
        index++;
        if (index >= spritesList.Count)
            index = 0;
        return spritesList[index];
    }
    
}
