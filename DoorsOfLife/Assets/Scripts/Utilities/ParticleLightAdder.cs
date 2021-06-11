using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleLightAdder : MonoBehaviour
{
    [SerializeField]
    private Light2D prefabLight;
    [SerializeField]
    private float lightmultiplier=1;

    struct LightAndComponent
    {
        public GameObject obj;
        public Light2D component;

        public LightAndComponent(GameObject obje,Light2D lightc)
        {
            obj = obje;
            component = lightc;
        }
    }

    private  List<LightAndComponent> LightsAndComponents= new List<LightAndComponent>();

    private ParticleSystem m_ParticleSystem;
    private ParticleSystem.Particle[] m_Particles;

    void Start()
    {
        m_ParticleSystem = GetComponent<ParticleSystem>();
        m_Particles = new ParticleSystem.Particle[m_ParticleSystem.main.maxParticles];
        InstantiateParticles();
    }


    private void InstantiateParticles()
    {
        for (int i=0;i< m_ParticleSystem.main.maxParticles; i++)
        {
            GameObject newObject = Instantiate(prefabLight.gameObject, transform);
            Light2D newLight = newObject.GetComponent<Light2D>();
            LightAndComponent add = new LightAndComponent(newObject, newLight);
            LightsAndComponents.Add(add);
        }
    }
    void LateUpdate()
    {
        int count = m_ParticleSystem.GetParticles(m_Particles);
        bool worldSpace = (m_ParticleSystem.main.simulationSpace == ParticleSystemSimulationSpace.World);
        for (int i = 0; i < LightsAndComponents.Count; i++)
        {
            if (i < count)
            {
                if (worldSpace)
                    LightsAndComponents[i].obj.transform.position = m_Particles[i].position;
                else
                    LightsAndComponents[i].obj.transform.localPosition = m_Particles[i].position;
                LightsAndComponents[i].obj.SetActive(true);
                LightsAndComponents[i].component.intensity =lightmultiplier * Mathf.Clamp(m_Particles[i].GetCurrentSize(m_ParticleSystem), 0, 1);
            }
            else
            {
                LightsAndComponents[i].obj.SetActive(false);
            }
        }
    }
}
