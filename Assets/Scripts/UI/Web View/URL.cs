using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class URL : MonoBehaviour
{
    public string _webUrl, _imageURL;
    public bool _changeImage;
    private bool _getTexture;

    [HideInInspector]
    public Texture _image;
    private Material _mat;

    private void Start()
    {
        _mat = GetComponent<MeshRenderer>().material;
        StartCoroutine(DownloadImage(_imageURL));
    }
    private void Update()
    {
        if (_changeImage)
            StartCoroutine(DownloadImage(_imageURL));
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        _changeImage = _getTexture = false;

        while (!_getTexture)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);

            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
                Debug.Log(request.error);
            else
            {
                _image = ((DownloadHandlerTexture)request.downloadHandler).texture;
                _mat.SetTexture("_BaseMap", _image);
                _getTexture = true;
            }
        }
    }
}