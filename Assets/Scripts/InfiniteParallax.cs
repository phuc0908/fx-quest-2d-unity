using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class InfiniteParallax : MonoBehaviour
{
    public Camera cam;
    public float parallaxEffect = 0f; // 0 = đứng yên, 1 = di chuyển cùng camera

    private float spriteWidth;
    private SpriteRenderer sr;
    private Vector3 startPos;

    private GameObject leftClone;
    private GameObject rightClone;

    void Start()
    {
        if (cam == null) cam = Camera.main;
        sr = GetComponent<SpriteRenderer>();
        spriteWidth = sr.bounds.size.x;
        startPos = transform.position;

        CreateClones();
    }

    void LateUpdate()
    {
        // Di chuyển layer theo camera (hiệu ứng parallax)
        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos.x + distance, transform.position.y, transform.position.z);

        // Lấy biên trái/phải của camera trong world space
        float halfCamWidth = cam.orthographicSize * cam.aspect;
        float camLeftEdge = cam.transform.position.x - halfCamWidth;
        float camRightEdge = cam.transform.position.x + halfCamWidth;

        // Nếu sprite ra khỏi khung hình bên phải → dịch qua trái
        if (transform.position.x - spriteWidth / 2 > camRightEdge)
        {
            startPos.x -= spriteWidth * 2f;
        }
        // Nếu sprite ra khỏi khung hình bên trái → dịch qua phải
        else if (transform.position.x + spriteWidth / 2 < camLeftEdge)
        {
            startPos.x += spriteWidth * 2f;
        }
    }

    private void CreateClones()
    {
        if (leftClone == null)
        {
            leftClone = Instantiate(gameObject, transform.parent);
            leftClone.name = name + "_Left";
            leftClone.transform.position = transform.position - new Vector3(spriteWidth, 0, 0);
            DestroyImmediate(leftClone.GetComponent<InfiniteParallax>());
        }

        if (rightClone == null)
        {
            rightClone = Instantiate(gameObject, transform.parent);
            rightClone.name = name + "_Right";
            rightClone.transform.position = transform.position + new Vector3(spriteWidth, 0, 0);
            DestroyImmediate(rightClone.GetComponent<InfiniteParallax>());
        }
    }
}
