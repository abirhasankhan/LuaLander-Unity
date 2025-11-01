using System;
using UnityEngine;

public class LanderVisuals : MonoBehaviour
{
    [SerializeField] private ParticleSystem leftThrusterParticleSystem;
    [SerializeField] private ParticleSystem middleThrusterParticleSystem;
    [SerializeField] private ParticleSystem rightThrusterParticleSystem;

    private Lander lander;


    private void Awake()
    {
        lander = GetComponent<Lander>();

        lander.OnUpForce += Lander_OnUpForce;
        lander.OnLeftForce += Lander_OnLeftForce;
        lander.OnRightForce += Lander_OnRightForce;
        lander.OnBeforeForce += Lander_OnBeforeForce;


        SetEnableThrusterParticleSystem(leftThrusterParticleSystem, false);
        SetEnableThrusterParticleSystem(middleThrusterParticleSystem, false);
        SetEnableThrusterParticleSystem(rightThrusterParticleSystem, false);
    }

    private void Lander_OnBeforeForce(object sender, System.EventArgs e)
    {
        SetEnableThrusterParticleSystem(leftThrusterParticleSystem, false);
        SetEnableThrusterParticleSystem(middleThrusterParticleSystem, false);
        SetEnableThrusterParticleSystem(rightThrusterParticleSystem, false);

    }

    private void Lander_OnRightForce(object sender, System.EventArgs e)
    {
        SetEnableThrusterParticleSystem(leftThrusterParticleSystem, true);
    }

    private void Lander_OnLeftForce(object sender, System.EventArgs e)
    {
        SetEnableThrusterParticleSystem(rightThrusterParticleSystem, true);
    }

    private void Lander_OnUpForce(object sender, System.EventArgs e)
    {
        SetEnableThrusterParticleSystem(leftThrusterParticleSystem, true);
        SetEnableThrusterParticleSystem(middleThrusterParticleSystem, true);
        SetEnableThrusterParticleSystem(rightThrusterParticleSystem, true);

    }

    private void SetEnableThrusterParticleSystem(ParticleSystem particleSystem, bool enabled)
    {
        ParticleSystem.EmissionModule emissionModule = particleSystem.emission;
        emissionModule.enabled = enabled;
    }

}
