using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorShoot;
    [SerializeField] private Texture2D cursorReload;
    private Vector2 hotspot = new Vector2(16, 48); //điều chỉnh vị trí con trỏ chuột
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorShoot, hotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorShoot, hotspot, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursorShoot, hotspot, CursorMode.Auto);
        }
        else if (Input.GetKey(KeyCode.R))
        {
            Cursor.SetCursor(cursorReload, hotspot, CursorMode.Auto);
            StartCoroutine(ResetCursorAfterDelay(0.5f));
        }
    }

    private IEnumerator ResetCursorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Cursor.SetCursor(cursorShoot, hotspot, CursorMode.Auto);
    }
}
