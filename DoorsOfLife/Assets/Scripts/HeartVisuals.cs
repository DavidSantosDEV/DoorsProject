using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeartVisuals : MonoBehaviour
{
    [SerializeField]
    private Sprite heartSprite,halfHeartSprite;

    List<Sprite> hearts = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Image CreateHeartImage()
    {
        Image img=null;
        return img;
    }
}
