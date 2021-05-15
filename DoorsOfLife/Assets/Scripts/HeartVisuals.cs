using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum HeartTerms
{
    Full,
    Half,
    Empty
}

public class HeartsAndLife
{
    public Sprite image;
    public HeartTerms state;
}

public class HeartVisuals : MonoBehaviour
{
    [SerializeField]
    private Transform anchorHearts;

    [SerializeField]
    private Sprite heartSprite,halfHeartSprite,emptyHeart;

    List<HeartsAndLife> hearts = new List<HeartsAndLife>();
    private int currentheartIndex;
    // Start is called before the first frame update
    void Start()
    {

        currentheartIndex = hearts.Count;
    }

    public void OnDamageTaken(float dmg)
    {
        double dam = System.Math.Round(dmg, 2);
        if (hearts.Count - dmg <= 0)
        {
            foreach(HeartsAndLife heart in hearts)
            {
                heart.state = HeartTerms.Empty;
                heart.image = emptyHeart;
            }
        }

    }

    public Image CreateHeartImage(Vector2 Anchoredposition)
    {
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));
        heartGameObject.transform.parent = anchorHearts;
        heartGameObject.transform.localPosition = Vector3.zero;

        Image img=null;
        return img;
    }
}
