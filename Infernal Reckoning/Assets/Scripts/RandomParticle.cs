using UnityEngine;

public class RandomParticle : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public int framesPerRandomization = 30;
    private int currentFrame = 0;

    private void Start()
    {
        

        if (particleSystem == null)
        {
            particleSystem = GetComponent<ParticleSystem>();
            RandomizeColor();
        }
    }

    private void Update()
    {
        currentFrame++;
        if (currentFrame >= framesPerRandomization)
        {
            currentFrame = 0;
            RandomizeColor();
        }
    }

    private void RandomizeColor()
    {
        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startColor = new ParticleSystem.MinMaxGradient(Random.ColorHSV());
    }
}
