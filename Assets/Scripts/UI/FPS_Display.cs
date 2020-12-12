using UnityEngine;
using TMPro;

public class FPS_Display : MonoBehaviour
{
    float deltaTime = 0.0f;

    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }
    private void OnGUI()
    {
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        gameObject.GetComponent<TextMeshProUGUI>().text = text;
    }
}