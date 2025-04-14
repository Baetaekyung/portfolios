
using CardGame;
using System.Linq.Expressions;
using UnityEngine;

public class CardUI : BaseCard
{
    public bool isOnDeck = false;
    public int cardCnt;
    public bool IsInDeckCards = false;
    private bool isHold = false;
    public int childIdx = -1;
    private void OnEnable()
    {
        OnPointerDownEvent += OnPointerDownHandler;
        OnPointerUpEvent += OnPointerUpHandler;
        isOnDeck = false;
    }

    private void OnPointerDownHandler()
    {
        isHold = true;

        bool canAddCard = LobbyDeckCardManager.Instance.IsArentExceed(this);

        if (canAddCard && IsInDeckCards == false) //ī�带 �߰��� �� �ְ� ī�尡 ���� ���� ���� ��������
        {
            Debug.Log("����������(����ī������ī�帮��Ʈ��¶�");
            IsInDeckCards = true;
            LobbyDeckCardManager.Instance.AddCardToDeckCardList(this);
        }
        else if(IsInDeckCards == true) //ī�尡 ���� �ִµ� �� �� �� ������
        {
            Debug.Log("����������(������ī����굦ī�帮��Ʈ��¶�");
            LobbyDeckCardManager.Instance.RemoveCardOfDeckCardList(this);
            IsInDeckCards = false;
        }
    }

    private void OnPointerUpHandler()
    {
        isHold = false;
    }

    private void OnDestroy()
    {
        OnPointerDownEvent -= OnPointerDownHandler;
        OnPointerUpEvent -= OnPointerUpHandler;
    }
}
