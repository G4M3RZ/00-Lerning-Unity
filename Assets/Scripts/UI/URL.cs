using UnityEngine;

public class URL : MonoBehaviour
{
    public string _webUrl;
    public Texture _image;
    public bool _changeImage;
    
    private Material _mat;

    private void Start()
    {
        _mat = GetComponent<MeshRenderer>().material;
        _changeImage = true;
    }
    private void Update()
    {
        if (_changeImage)
        {
            _mat.SetTexture("_BaseMap", _image);
            _changeImage = false;
        }
    }
}