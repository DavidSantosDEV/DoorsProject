using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleAnimationAdder : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabObject;
    [SerializeField]
    private float sizeMultiplier=1;

    private List<GameObject> objects= new List<GameObject>();

    private ParticleSystem m_ParticleSystem;
    private ParticleSystem.Particle[] m_Particles;

    void Start()
    {
        m_ParticleSystem = GetComponent<ParticleSystem>();
        m_Particles = new ParticleSystem.Particle[m_ParticleSystem.main.maxParticles];
        InstantiateParticles(m_ParticleSystem.GetParticles(m_Particles));
    }


    private void InstantiateParticles(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newObject = Instantiate(prefabObject.gameObject, transform);
            objects.Add(newObject);
        }
    }
    void LateUpdate()
    {
        int count = m_ParticleSystem.GetParticles(m_Particles);

        for (int i = 0; i < objects.Count; i++)
        {
            if (i < count)
            {
                if (m_ParticleSystem.main.simulationSpace == ParticleSystemSimulationSpace.World)
                {
                    objects[i].transform.position = m_Particles[i].position;
                }
                else
                {
                    objects[i].transform.localPosition = m_Particles[i].position;
                }
                objects[i].SetActive(true);
                float size = sizeMultiplier * m_Particles[i].GetCurrentSize(m_ParticleSystem);
                objects[i].transform.localScale = new Vector3(size,size,size);
                //ParticlesAndComponents[i].component.color = m_Particles[i].GetCurrentColor(m_ParticleSystem);
            }
            else
            {
                objects[i].SetActive(false);
            }
        }
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }
}
