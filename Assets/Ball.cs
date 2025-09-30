using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    Vector3 initialPos;
    public int Flag;
    public int Bot_score = 0, Player_score = 0;
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
            UnityEngine.Debug.Log("Flag value" + Flag);
            if (Flag == 0)
            {
                UnityEngine.Debug.Log("Entered bot flag");
                Bot_score += 1;
                UnityEngine.Debug.Log("bot scored. Score:"+Bot_score);
                UpdateScoreDisplay();
            }
            else if (Flag == 1)
            {
                UnityEngine.Debug.Log("Entered player flag");
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
        botScoreText.text = $"Bot: {Bot_score}";
        playerScoreText.text = $"Player: {Player_score}";
    }
}
