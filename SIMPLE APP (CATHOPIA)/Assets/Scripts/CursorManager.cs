using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D defaultCursorTexture;
    [SerializeField] private Texture2D clickedCursorTexture;

    private Vector2 defaultCursorHotspot;
    private Vector2 clickedCursorHotspot;

    void Start()
    {
        defaultCursorHotspot = new Vector2(defaultCursorTexture.width / 2, defaultCursorTexture.height / 2);
        clickedCursorHotspot = new Vector2(clickedCursorTexture.width / 2, clickedCursorTexture.height / 2);

        Cursor.SetCursor(defaultCursorTexture, defaultCursorHotspot, CursorMode.Auto);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(clickedCursorTexture, clickedCursorHotspot, CursorMode.Auto);
            Invoke("ResetCursorTexture", 0.2f);
        }
    }

    void ResetCursorTexture()
    {
        Cursor.SetCursor(defaultCursorTexture, defaultCursorHotspot, CursorMode.Auto);
    }
}
