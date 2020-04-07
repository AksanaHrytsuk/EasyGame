using UnityEngine;

public class BasketScript : MonoBehaviour
{
    [Header("Config Parameters")]
    public  float minX = -8f;

    public  float maxX = 8f;

    private void Update()
    {
            MoveWithMouse();
    }
    private void MoveWithMouse()
    {
        Vector3  mousePos = Input.mousePosition;
        // позиция мыши в координатах камеры
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        // позиция мыши в координатах игрового мира
        float mouseX = mouseWorldPos.x;
        float clampedMouseX = Mathf.Clamp(mouseX, minX, maxX);
        float platformY = transform.position.y;
        transform.position = new Vector3(clampedMouseX, platformY, 2);
    }
}
