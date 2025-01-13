using UnityEngine;
using TMPro;

public class DemoManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private TextMeshProUGUI detectionText;
    
    private void Start()
    {
        WakeWordManager.Instance.onWakeWordDetected.AddListener(OnWakeWordDetected);
        UpdateStatus();
    }

    private void Update()
    {
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        statusText.text = WakeWordManager.Instance.IsListening ? 
            "Status: Listening for wake word..." : 
            "Status: Not listening";
    }

    private void OnWakeWordDetected()
    {
        detectionText.text = $"Wake word detected at: {System.DateTime.Now.ToString("HH:mm:ss")}";
    }
}