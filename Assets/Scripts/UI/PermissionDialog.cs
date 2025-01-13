using UnityEngine;
using TMPro;

public class PermissionDialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    
    private void Start()
    {
        messageText.text = "This app needs microphone permission to detect wake words. Please grant the permission to continue.";
    }
}