
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UpgradeShop : MonoBehaviour
{

    public Transform upgradeTextTf;

    public Transform coinIconTf;
    public Text costText;
    public Transform sawIcon;
    private Vector3 startPos;


    public List<int> priceProgression;
    [HideInInspector]
    public int currentPrice;

    private int sawRotSpeed = -1;

    private bool isDisabled;
    bool isInsideShop;
    // Start is called before the first frame update
    void Start()
    {

        startPos = upgradeTextTf.transform.localPosition;

        if (Data.PlayerSkinIdx.I() == 0 && Data.ShopPrice.I() == 0)
            Data.ShopPrice.Set(priceProgression[0]);
        currentPrice = Data.ShopPrice.I();

        SetPrice(currentPrice);

        if (Data.PlayerSkinIdx.I() >= priceProgression.Count - 1)
        {
            DisableShop();
        }

        FindObjectOfType<Trimmer>().onEnterShop += (trimmer) =>
        {

            isInsideShop = true;
            AddCoin(trimmer);

        };

        FindObjectOfType<Trimmer>().onExitShop += (trimmer) =>
        {
            isInsideShop = false;
        };
    }

    private void AddCoin(Trimmer trimmer)
    {
        if (!isInsideShop) return;
        if (isDisabled) return;
        if (Data.Coin.I() <= 0)
        {
            // DOTween.To(() => costText.color, (color) => costText.color = color, Col.red, 1f).SetEase(Ease.InOutBounce);
            return;
        }

        var coinPf = Resources.Load<GameObject>("Coin");
        Data.Coin.Set(Data.Coin.I() - 1);
        A.CC.HudCoin(Data.Coin.I());

        var coin = Instantiate(coinPf, trimmer.coinSpawn.position, Q.O);
        coin.Gc<Collider>().enabled = false;



        coin
        .transform
        .DOMove(coinIconTf.position, 0.1f)
        .SetEase(Ease.InSine)
        .OnComplete(() =>
        {
            if (currentPrice > 1)
                SetPrice(currentPrice -= 1);
            else
            {
                trimmer.UpgradeTrimmer();

                if (Data.PlayerSkinIdx.I() < priceProgression.Count)
                    SetPrice(priceProgression[Data.PlayerSkinIdx.I()]);
                else
                    DisableShop();
            }
            Destroy(coin);
            AddCoin(trimmer);
        });


    }

    // Update is called once per frame
    void Update()
    {

        upgradeTextTf.localPosition = startPos + Vector3.up * 0.2f * Mathf.Cos(Time.time);
        sawIcon.transform.rotation = Quaternion.Euler(0, 0, sawRotSpeed) * sawIcon.transform.rotation;
    }

    public void SetPrice(int value)
    {
        currentPrice = value;
        costText.text = "" + value;
    }


    public void DisableShop()
    {
        isDisabled = true;
        upgradeTextTf.Gc<Text>().text = "";
        coinIconTf.Gc<Image>().color = Col.gray;
        transform.GetChild(2).Gc<Image>().color = Col.gray;
        costText.text = "";
        // sawRotSpeed = 0;
        sawIcon.gameObject.SetActive(false);
    }



}
