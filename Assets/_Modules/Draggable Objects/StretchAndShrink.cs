using System.Threading.Tasks;
using UnityEngine;

public class StretchAndShrink : MonoBehaviour
{
    [SerializeField] private float stretchDuration = 0.5f; // Thời gian kéo giãn
    [SerializeField] private float shrinkDuration = 0.5f;  // Thời gian thu nhỏ
    [SerializeField] private Vector3 stretchScale = new Vector3(1f, 2f, 1f); // Scale khi kéo giãn

    private Vector3 originalScale;
    public bool isInteracted;

    private void Start()
    {
        isInteracted = false;
        originalScale = transform.localScale;
    }

    public async Task StartStretchAndShrink()
    {
        // Kéo giãn
        await StretchObject();

        // Thu nhỏ
        await ShrinkObject();
    }

    private async Task StretchObject()
    {
        float elapsedTime = 0f;

        while (elapsedTime < stretchDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, stretchScale, elapsedTime / stretchDuration);
            elapsedTime += Time.deltaTime;
            await Task.Yield(); // Chờ đến khung hình tiếp theo
        }

        transform.localScale = stretchScale;
    }

    private async Task ShrinkObject()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shrinkDuration)
        {
            transform.localScale = Vector3.Lerp(stretchScale, Vector3.zero, elapsedTime / shrinkDuration);
            elapsedTime += Time.deltaTime;
            await Task.Yield(); // Chờ đến khung hình tiếp theo
        }

        transform.localScale = Vector3.zero;
    }
}
