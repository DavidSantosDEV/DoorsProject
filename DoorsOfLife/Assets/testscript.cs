using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    [SerializeField]
    private Grid deleteme;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(deleteme);
        Destroy(gameObject);

        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        GameManager.Instance.ChangeToMenu();
    }
}
