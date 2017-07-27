using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    public Camera MainCam;
    //public Camera BGCam;
    public Field Field;

    private int max_x = 0;
    private int min_x = 0;
    private int max_y = 0;
    private int min_y = 0;
    private int cameraSize = 10;

    // Use this for initialization
    void Start() {
        CenterCamera();
    }

    // Update is called once per frame
    void Update() {

    }
    private Vector3 GetCenter() {
        int center_x = min_x + max_x / 2;
        int center_y = min_y + max_y / 2;
        Vector3 result = new Vector3(center_x, center_y, -10);
        return result;
    }

    private int GetCameraSize() {
        int size_x = max_x - min_x;
        int size_y = max_y - min_y;
        if (size_x > size_y) {
            if (size_x > 10) {
                return size_x / 2;
            } else {
                return 6;
            }
        } else {
            if (size_y > 10) {
                return size_y / 2;
            } else {
                return 6;
            }
        }
    }

    public void CenterCamera() {
        //CalculateSize();
        MainCam.transform.position = GetCenter();
        //MainCam.orthographicSize = GetCameraSize();
        //BGCam.orthographicSize = GetCameraSize();
    }

    //private void CalculateSize() {

    //    List<Card> CardsOnField = Field.cardsOnField;
    //    foreach (Card card in CardsOnField) {
    //        if (card.x > max_x) {
    //            max_x = card.x;
    //        }
    //        if (card.x < min_x) {
    //            min_x = card.x;
    //        }
    //        if (card.y > max_y) {
    //            max_y = card.y;
    //        }
    //        if (card.y > min_y) {
    //            min_y = card.y;
    //        }
    //    }

    //    print(min_x + "" + min_y + "" + max_x + "" + max_y);
    //}

    //public Image BackGround = new Image();
    //int canvasWidth = 1173;
    //int canvasHeight = 601;

    //void AdjustBG() {
    //    float canvasWidthRatio = canvasWidth / Screen.width;
    //    float canvasHeightRatio = canvasHeight / Screen.height;
    //    float cameraWidth = BackGround.rectTransform.rect.width / canvasWidthRatio;
    //    float cameraHeight = BackGround.rectTransform.rect.height / canvasHeightRatio;
    //    float cameraX = BackGround.rectTransform.transform.position.x - cameraWidth / 2;
    //    float cameraY = BackGround.rectTransform.transform.position.y - cameraHeight / 2;
    //    this.MainCam.pixelRect = new Rect(cameraX, cameraY, cameraWidth, cameraHeight);
    //}


    //http://answers.unity3d.com/questions/620699/scaling-my-background-sprite-to-fill-screen-2d-1.html
    //function ResizeSpriteToScreen() {
    //    var sr = GetComponent(SpriteRenderer);
    //    if (sr == null) return;

    //    transform.localScale = Vector3(1, 1, 1);

    //    var width = sr.sprite.bounds.size.x;
    //    var height = sr.sprite.bounds.size.y;

    //    var worldScreenHeight = Camera.main.orthographicSize * 2.0;
    //    var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

    //    transform.localScale.x = worldScreenWidth / width;
    //    transform.localScale.y = worldScreenHeight / height;
    //}


}
