using UnityEngine;
using Pv.Unity;

public class WakeWordDetector : MonoBehaviour
{
    private Porcupine porcupine;
    private const string ACCESS_KEY = "YOUR_PICOVOICE_ACCESS_KEY"; // You'll need to get this from Picovoice Console

    void Start()
    {
        try
        {
            // Initialize Porcupine with the custom wake word
            porcupine = Porcupine.FromKeyword(
                accessKey: ACCESS_KEY,
                keyword: "hey digi",
                modelPath: null
            );

            // Start listening
            porcupine.Start();
        }
        catch (PorcupineException ex)
        {
            Debug.LogError($"Failed to initialize Porcupine: {ex.Message}");
        }
    }

    void Update()
    {
        if (porcupine != null && porcupine.IsListening)
        {
            bool detected = porcupine.Process();
            if (detected)
            {
                OnWakeWordDetected();
            }
        }
    }

    private void OnWakeWordDetected()
    {
        Debug.Log("Wake word 'Hey Digi' detected!");
        // Add your wake word response logic here
    }

    void OnDestroy()
    {
        if (porcupine != null)
        {
            porcupine.Dispose();
        }
    }
}