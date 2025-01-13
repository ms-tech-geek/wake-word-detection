using UnityEngine;
using System.Collections;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class AudioPermissionManager : MonoBehaviour
{
    [SerializeField] private GameObject permissionDialogPrefab;
    private GameObject dialogInstance;

    private void Start()
    {
        StartCoroutine(RequestMicrophonePermission());
    }

    private IEnumerator RequestMicrophonePermission()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
            dialogInstance = Instantiate(permissionDialogPrefab);
            yield return new WaitUntil(() => Permission.HasUserAuthorizedPermission(Permission.Microphone));
            if (dialogInstance != null)
                Destroy(dialogInstance);
        }
#endif
        yield return null;
    }
}