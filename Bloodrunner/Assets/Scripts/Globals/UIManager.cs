using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    public GameObject fadeOutBlackImage;

    public GameObject fadeInBlackImage;

    public void FadeToBlack()
    {
        fadeOutBlackImage.SetActive(true);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        fadeInBlackImage.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
