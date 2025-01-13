using UnityEngine;
using Pv.Unity;

public class WakeWordDetector : MonoBehaviour
{
    private Porcupine porcupine;
    private const string ACCESS_KEY = "YOUR_PICOVOICE_ACCESS_KEY";
    
    [SerializeField] private WakeWordManager wakeWordManager;
    [SerializeField] private bool autoStart = true;
    [SerializeField] private string wakeWord = "hey digi";

    private void Start()
    {
        InitializePorcupine();
        if (autoStart)
            StartDetection();
    }

    private void InitializePorcupine()
    {
        try
        {
            porcupine = Porcupine.FromKeyword(
                accessKey: ACCESS_KEY,
                keyword: wakeWord,
                modelPath: null
            );
        }
        catch (PorcupineException ex)
        {
            Debug.LogError($"Failed to initialize Porcupine: {ex.Message}");
        }
    }

    public void StartDetection()
    {
        if (porcupine != null)
        {
            porcupine.Start();
            wakeWordManager.StartListening();
        }
    }

    public void StopDetection()
    {
        if (porcupine != null && porcupine.IsListening)
        {
            porcupine.Stop();
            wakeWordManager.StopListening();
        }
    }

    private void Update()
    {
        if (porcupine != null && porcupine.IsListening)
        {
            bool detected = porcupine.Process();
            if (detected)
            {
                wakeWordManager.OnWakeWordDetected();
            }
        }
    }

    private void OnDestroy()
    {
        if (porcupine != null)
        {
            porcupine.Dispose();
        }
    }
}