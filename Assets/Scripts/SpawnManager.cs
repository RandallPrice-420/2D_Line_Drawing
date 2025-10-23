using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject    _ballPrefab;     // Prefab to instantiate
    [SerializeField] private RectTransform _panel;          // Reference to the panel
    [SerializeField] private Canvas        _canvas;         // Reference to the canvas


    private Camera _camera;


    public void SpawnBall()
    {
        // Instantiate the object.
        GameObject ball = Instantiate(_ballPrefab, _canvas.transform);

        RectTransform rectTransform = ball.GetComponent<RectTransform>();
        Vector2       mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3       panelPosition = _panel.position;

        // Adjust Z to ensure it's in frontof the panel.
        rectTransform.position = panelPosition + new Vector3(0f, 0f, -1f);

        // Optionally, adjust size and alignment.
        rectTransform.sizeDelta  = new Vector2(100f, 100f);
        rectTransform.localScale = Vector3.one;

    }   // SpawnBall()


    private void Start()
    {
        _camera = Camera.main;

    }   // Start()


    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SpawnBall();
        }

    }   // Update()


}   // class SpawnManager
