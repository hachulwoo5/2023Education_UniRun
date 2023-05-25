using UnityEngine;

// 왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트
public class BackgroundLoop : MonoBehaviour {
    private float width; // 배경의 가로 길이
    BoxCollider2D boxCollider2D;
    private void Awake() {
        boxCollider2D = GetComponent<BoxCollider2D>();
        width = boxCollider2D.size.x;
        // 가로 길이를 측정하는 처리
    }

    private void Update() {

        // 현재 위치에서 -20, 즉 폭 이상으로 이동한다면 ?
        if (transform.position.x <= -width)
        {
            Reposition();
        }
       
    }

    // 위치를 리셋하는 메서드
    private void Reposition() {
        // 2개의 이미지므로 wid소dml 2배 이동
        Vector2 offset = new Vector2(width * 2f, 0f); 
        transform.position = (Vector2)transform.position + offset;
    }
}