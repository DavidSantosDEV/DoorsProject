using System.Collections;
using System.Collections.Generic;
using UnityEngine.U2D;
using UnityEngine;

public class CameraShaderAdder : MonoBehaviour
{
    [SerializeField]
    private Shader shader;

    [SerializeField]
    private PixelPerfectCamera cam;
    private Camera test;

    private void Awake()
    {
        test = GetComponent<Camera>();
        test.enabled = false;
        //cam = GetComponent<PixelPerfectCamera>();
        //cam.enabled = false;
    }

    private void Update()
    {
        test.RenderWithShader(shader, "RenderedByMain");
    }
}
