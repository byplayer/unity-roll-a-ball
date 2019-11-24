using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 20;
    public Text scoreText;
    public Text winText;

    private Rigidbody rb;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();

        score = 0;
        SetContext();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Ridigbody に力を与えて玉を動かす
        rb.AddForce(movement * speed);
    }

    // trigger event
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);

            score += 1;
            SetContext();
        }
    }

    void SetContext()
    {
        scoreText.text = "Count: " + score.ToString();

        if(score >= 12)
        {
            winText.text = "You won !";
        }
    }
}
