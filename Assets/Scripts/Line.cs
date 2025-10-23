using System.Collections.Generic;
using UnityEngine;


public class Line : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Serialized Fields:
    // ------------------
    //   _edgeCollider
    //   _lineRenderer
    // -------------------------------------------------------------------------

    #region .  Serialized Fields  .

    [SerializeField] private EdgeCollider2D _edgeCollider;
    [SerializeField] private LineRenderer   _lineRenderer;

    #endregion



    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   _points
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    private readonly List<Vector2> _points = new List<Vector2>();

    #endregion



    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   SetPosition()
    // -------------------------------------------------------------------------

    #region .  SetPosition  .
    // -------------------------------------------------------------------------
    //   Method.......:  SetPosition()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void SetPosition(Vector2 position)
    {
        if (!CanAppend(position)) return;

        _points.Add(position);

        int pointCount = _lineRenderer.positionCount;
        _lineRenderer.positionCount = pointCount + 1;
        _lineRenderer.SetPosition(pointCount, position);

        _edgeCollider.points = _points.ToArray();

    }   // SetPosition()
    #endregion



    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Start()
    //   CanAppend()
    // -------------------------------------------------------------------------

    #region .  CanAppend  .
    // -------------------------------------------------------------------------
    //   Method.......:  CanAppend()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private bool CanAppend(Vector2 position)
    {
        if (_lineRenderer.positionCount == 0) return true;

        Vector2 lastPosition = _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);
        float distance = Vector2.Distance(lastPosition, position);

        return (distance >= DrawManager.RESOLUTION);

    }   // CanAppend()
    #endregion


    #region .  Start  .
    // -------------------------------------------------------------------------
    //   Method.......:  Start()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Start()
    {
        _edgeCollider.transform.position -= this.transform.position;

    }   // Start()
    #endregion


}   // class Line
