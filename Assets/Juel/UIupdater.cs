using TMPro;
using UnityEngine;

public class UIupdater : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI TrashInBag;
    public TextMeshProUGUI BagSize;

    public GameObject PlayerControllerScriptValues;

    public int _trashInBag;
    public int _bagSize;
    public int _score;

    [SerializeField] private string scoreDisp;
    [SerializeField] private string TrashDisp;
    [SerializeField] private string BagSizeDisp;

    private void Update()
    {
        _bagSize = PlayerControllerScriptValues.GetComponent<PlayerController>().BagSize;
        _trashInBag = PlayerControllerScriptValues.GetComponent<PlayerController>().numOfTrashInBag;
        _score = PlayerControllerScriptValues.GetComponent<PlayerController>().score;

        scoreDisp = "Score: " + _score;
        TrashDisp = "Trash in bag: " + _trashInBag;
        BagSizeDisp = "Bag Size: " + _bagSize;


        score.GetComponent<TextMeshProUGUI>().text = scoreDisp;
        TrashInBag.GetComponent<TextMeshProUGUI>().text = TrashDisp;
        BagSize.GetComponent<TextMeshProUGUI>().text = BagSizeDisp;
    }



}
