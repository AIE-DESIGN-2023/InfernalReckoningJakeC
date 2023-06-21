using UnityEngine;

public class RandomLight : MonoBehaviour
{
    public int framesToChange = 30;  // Number of frames to wait before changing color
    private int currentFrame = 0;   // Current frame counter
    private Light areaLight;        // Reference to the Area Light component

    private void Start()
    
    
    {
        areaLight = GetComponent<Light>();
    }

    private void Update()
    {
        // Increment the frame counter
        currentFrame++;

        // Check if it's time to change the color
        if (currentFrame >= framesToChange)
        {
            // Generate a random color
            Color randomColor = new Color(Random.value, Random.value, Random.value);

            // Apply the random color to the Area Light
            areaLight.color = randomColor;

            // Reset the frame counter
            currentFrame = 0;
        }
    }
}
