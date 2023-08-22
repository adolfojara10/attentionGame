using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class testw2 : MonoBehaviour
{
    public List<Image> images2;
    public Sprite OtherSprite;
    public Sprite OtherSprite1;
    public int number = 1;
    Image[] images;

    void Start()
    {
        number = Random.Range(1, 3);
        images = gameObject.GetComponentsInChildren<Image>();

        foreach (Image image in images)
        {
            StartCoroutine(Count());
            //image.sprite = OtherSprite;
        }
    }
    IEnumerator Count()
    {


        foreach (Image image in images)
        {

            image.sprite = OtherSprite;
            if (number == 1)
            {
                image.sprite = OtherSprite;
            }
            else if (number == 2)
            {
                image.sprite = OtherSprite1;
            }
            yield return new WaitForSeconds(2);
            Application.LoadLevel(0);
        }
    }
}