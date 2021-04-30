using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRave : MonoBehaviour
{
    public float speed=2;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        StartCoroutine(nameof(colorrave));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator colorrave()
    {
        while (isActiveAndEnabled)
        {
            Color col = Color.white;
            int rnd = Random.Range(0, 8);
            switch (rnd)
            {
                case 0:
                    col = Color.green;
                    break;
                case 1:
                    col = Color.blue;
                    break;
                case 2:
                    col = Color.black;
                    break;
                case 3:
                    col = Color.white;
                    break;
                case 4:
                    col = Color.grey;
                    break;
                case 5:
                    col = Color.magenta;
                    break;
                case 6:
                    col = Color.cyan;
                    break;
                case 7:
                    col = Color.yellow;
                    break;
                case 8:
                    col = Color.red;
                    break;


            }

            cam.backgroundColor = col;
            yield return new WaitForSeconds(1 / speed);
        }
        
    }
}
