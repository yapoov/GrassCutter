
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeShop : MonoBehaviour
{

    public Transform upgradeTextTf;
    public Text costText;
    public Transform sawIcon;
    private Vector3 startPos;

    public int currentPrice;
    // Start is called before the first frame update
    void Start()
    {

        startPos = upgradeTextTf.transform.position;
        SetPrice(currentPrice);
    }

    // Update is called once per frame
    void Update()
    {

        upgradeTextTf.transform.position = startPos + Vector3.up * 0.2f * Mathf.Cos(Time.time);
        sawIcon.transform.rotation = Quaternion.Euler(0, 0, -1) * sawIcon.transform.rotation;
    }

    public void SetPrice(int value)
    {
        currentPrice = value;
        costText.text = "" + value;
    }
}
