using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    

    void Start()
    {
        scoreText.text = "You Scored:\n" + ScoreKeeper.Instance.GetScore();

        ASM_MN.Instance.YC1(1234, "Dung", 200, ASM_MN.Instance.listRegion[3]);
        Debug.Log("YC2: Xuất danh sách người chơi");
        ASM_MN.Instance.YC2();
        Debug.Log("YC3: Xuất người chơi có score bé hơn Player");
        ASM_MN.Instance.YC3();
        Debug.Log("YC4: Tìm player theo Id Player");
        ASM_MN.Instance.YC4();
        Debug.Log("YC5: Xuất thông tin người chơi theo thứ tự score giảm dần");
        ASM_MN.Instance.YC5();
        Debug.Log("YC6: Xuất 5 người chơi có score thấp nhất");
        ASM_MN.Instance.YC6();
        Debug.Log("YC7: Tính score trung bình dựa trên Region và lưu vào tập tin");
        ASM_MN.Instance.YC7();
    }

    


}
