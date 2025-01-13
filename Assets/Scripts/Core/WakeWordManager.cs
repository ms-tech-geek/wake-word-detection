using UnityEngine;
using UnityEngine.Events;

public class WakeWordManager : MonoBehaviour
{
    public static WakeWordManager Instance { get; private set; }
    
    [SerializeField] private bool debugMode = true;
    
    public UnityEvent onWakeWordDetected;
    public bool IsListening { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnWakeWordDetected()
    {
        if (debugMode)
            Debug.Log("Wake word detected!");
            
        onWakeWordDetected?.Invoke();
    }

    public void StartListening()
    {
        IsListening = true;
        if (debugMode)
            Debug.Log("Started listening for wake word");
    }

    public void StopListening()
    {
        IsListening = false;
        if (debugMode)
            Debug.Log("Stopped listening for wake word");
    }
}