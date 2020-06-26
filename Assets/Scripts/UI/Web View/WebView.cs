using UnityEngine;
using UnityEngine.UI;

public class WebView : MonoBehaviour
{
    [Range(0,20)]
    public float _rayDistance, _speed;
    public LayerMask _panelWeb;
    private bool _select;
    
    private URL _url;
    private Image _ui;
    private Material _webView;
    private float _alpha;

    public GameObject[] _uiButtons;

    private void Start()
    {
        _ui = GameObject.FindGameObjectWithTag("UI").transform.GetChild(0).GetComponent<Image>();
        _webView = _ui.material;
        _webView.color = new Color(1, 1, 1, 0);
    }
    private void Update()
    {
        Ray(transform.position);
        ShowUIPanel();
    }
    void Ray(Vector3 cam)
    {
        Ray hit = new Ray(cam, transform.forward * _rayDistance);
        RaycastHit hitInfo;
        Debug.DrawLine(hit.origin, hit.origin + hit.direction * _rayDistance, Color.green);
        if (Physics.Raycast(hit, out hitInfo, _rayDistance, _panelWeb) && Input.GetKeyDown(KeyCode.F))
        {
            _url = hitInfo.collider.GetComponent<URL>();
            _webView.SetTexture("_MainTex", _url._image);
            _select = true;
        }
    }
    void ShowUIPanel()
    {
        _ui.enabled = (_alpha == 0) ? _ui.enabled = false : _ui.enabled = true;
        _webView.color = new Color(1, 1, 1, _alpha);

        for (int i = 0; i < _uiButtons.Length; i++)
            _uiButtons[i].SetActive(_select);

        if (_select)
            _alpha = (_alpha < 1) ? _alpha += Time.deltaTime * _speed : _alpha = 1;
        else
            _alpha = (_alpha > 0) ? _alpha -= Time.deltaTime * _speed : _alpha = 0;
    }
    public void CloseWindow()
    {
        _select = false;
    }
    public void VisitWeb()
    {
        Application.OpenURL(_url._webUrl);
    }
}