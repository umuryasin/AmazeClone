using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 35;
    public float scaleAnimMagnitude = 0.25f;
    public float scaleAnimTime = 0.25f;
    public float InitscaleAnimMagnitude = 0.5f;
    public float InitscaleAnimTime = 0.5f;

    public PlayerBallViewControl playerBallViewControl;

    public GridVector currentPos;
    public GridVector direction;
    public bool isPlayerMoving => _startMove;

    private Vector3 _targetPos;
    private bool _startMove;


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

        float moveDist = speed * Time.deltaTime;
        float dist = Vector3.Distance(currentPosWord, _targetPos);
        if (dist < moveDist)
        {
            transform.position = _targetPos;
            currentPos = Tools.ConvertWordToGrid(_targetPos);
            _startMove = false;

            playerBallViewControl.MoveEndScaleAnimation(direction, scaleAnimMagnitude, scaleAnimTime);

            EventManager.OnGridPosChanged(currentPos);
            EventManager.OnPlayerMoveEnd();
        }
        else
        {
            Vector3 nextPosWord = Vector3.MoveTowards(currentPosWord,
            _targetPos, speed * Time.deltaTime);
            transform.position = nextPosWord;

            GridVector nextPosGrid = Tools.ConvertWordToGrid(nextPosWord);
            if (nextPosGrid != currentPos)
            {
                int gridDist = GridVector.GetManhattanDistance(currentPos, nextPosGrid);
                for (int i = 0; i < gridDist; i++)
                {
                    currentPos += direction;
                    EventManager.OnGridPosChanged(nextPosGrid);
                }
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

    public void InitColor(Color color)
    {
        playerBallViewControl.SetColor(color);
    }

    public void StartMove(GridVector targetPosGrid, GridVector dir, float initPosZ = -0.5f)
    {
        Vector3 targetPosWord = Tools.ConvertGridToWord(targetPosGrid);
        targetPosWord.z = initPosZ;
        _targetPos = targetPosWord;
        _startMove = true;
        direction = dir;

    }

    public void SetPlayerActive(bool isActive)
    {
        playerBallViewControl.SetActive(isActive, InitscaleAnimMagnitude, InitscaleAnimTime);
    }


}
