using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {

    private int max_x = 0;
    private int min_x = 0;
    private int max_y = 0;
    private int min_y = 0;
    private int cameraSize = 10;

    List<Card> field = new List<Card>();

    // Use this for initialization
    void Start() {
        field.Add(new Startpoint());

    }

    // Update is called once per frame
    void Update() {

    }

    private Vector3 GetCenter() {
        int center_x = min_x + max_x / 2;
        int center_y = min_y + max_y / 2;
        Vector3 result = new Vector3(center_x, center_y, 10);
        return result;
    }

    private int GetCameraSize() {
        int size_x = max_x - min_x;
        int size_y = max_y - min_y;
        if (size_x > size_y) {
            if (size_x > 10) {
            return size_x / 2;
            } else {
                return 5;
            }
        } else {
            if (size_y > 10) {
                return size_y / 2;
            } else {
                return 5;
            }
        }
    }

    private void CenterCamera() {
        Camera.main.transform.position = GetCenter();
        Camera.main.orthographicSize = GetCameraSize();
    }

    private void GetSize() {

    }

    private int GetCardData(int x, int y) {
        field.Find(index => x == 0 && y == 0);
        return 0;
    }
}
