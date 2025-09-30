using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    Vector3 initialPos;
    int flag;
    public int Bot_score = 0, Player_score =0;
    public TextMeshProUGUI botScoreText;
    public TextMeshProUGUI playerScoreText;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            if (flag == 1)
            {
                Bot_score += 1;
                UnityEngine.Debug.Log("bot scored. Score:"+Bot_score);
                UpdateScoreDisplay();
            }
            if (flag == 0)
            {
                Player_score += 1;
                UnityEngine.Debug.Log("player scored. Score:"+Player_score);
                UpdateScoreDisplay();
            }
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = initialPos;
        }
        
    }
    public void UpdateScoreDisplay()
    {
        // This converts the integer variables to text and updates the UI
        botScoreText.text = $"Bot: {Bot_score}";
        playerScoreText.text = $"Player: {Player_score}";
    }
}
