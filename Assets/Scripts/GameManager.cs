using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text pointText;
    private int point = 0;
    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        pointText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = point.ToString();
    }

    public void GetPoint()
    {
        point += 1;
    }
}
