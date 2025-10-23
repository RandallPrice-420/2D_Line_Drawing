using UnityEngine;


public class DrawManager : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Public Properties:
    // ------------------
    //   RESOLUTION
    // -------------------------------------------------------------------------

    #region .  Public Properties  .

    public const float RESOLUTION = 0.1f;

    #endregion


    [SerializeField] private Line _linePrefab;


    private Camera _camera;
    private Line   _currentLine;



    private void Start()
    {
        _camera = Camera.main;

    }   // Start()


    private void Update()
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            _currentLine = Instantiate(_linePrefab, mousePosition, Quaternion.identity);
        }

        if (Input.GetMouseButton(0))
        {
             _currentLine.SetPosition(mousePosition);
        }

    }   // Update()


}   // class DrawManager
