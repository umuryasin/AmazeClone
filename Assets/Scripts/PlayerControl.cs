using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject parent;
    public GridVector currentPos;
    public bool isPlayerMoving => _startMove;

    private Vector3 _targetPos;
    private bool _startMove;
    private float _speed = 35;

    // Start is called before the first frame update
    void Start()
    {
        _startMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_startMove)
            return;

        Vector3 currentPosWord = transform.position;

        float moveDist = _speed * Time.deltaTime;
        float dist = Vector3.Distance(currentPosWord, _targetPos);
        if (dist < moveDist)
        {
            transform.position = _targetPos;
            currentPos = Tools.ConvertWordToGrid(_targetPos);
            _startMove = false;
            EventManager.OnGridPosChanged(currentPos);
            EventManager.OnPlayerMoveEnd();
        }
        else
        {
            Vector3 nextPosWord = Vector3.MoveTowards(currentPosWord,
            _targetPos, _speed * Time.deltaTime);
            transform.position = nextPosWord;

            GridVector nextPosGrid = Tools.ConvertWordToGrid(nextPosWord);
            if (nextPosGrid != currentPos)
            {
                currentPos = nextPosGrid;
                EventManager.OnGridPosChanged(nextPosGrid);
            }
        }
    }

    public void InitPos(GridVector initPos, float initPosZ = -0.5f)
    {
        currentPos = initPos;
        Vector3 posWord = Tools.ConvertGridToWord(initPos);
        posWord.z = initPosZ;
        transform.position = posWord;
    }

    public void StartMove(GridVector targetPosGrid, float initPosZ = -0.5f)
    {
        Vector3 targetPosWord = Tools.ConvertGridToWord(targetPosGrid);
        targetPosWord.z = initPosZ;
        _targetPos = targetPosWord;
        _startMove = true;
    }

    public void SetActive(bool isActive)
    {
        parent.SetActive(isActive);
    }

}
