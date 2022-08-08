using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineId : MonoBehaviour
{
    //public으로 변수를 지정하여 인스펙터 창에서 관리할 수 있도록 생성
    //대사를 출력할 것인지 안할 것인지 결정하는 대사
    public bool takeLine = true;
    //LineSet 스크립트의 List 인덱스 번호를 저장하여 불러올 수 있도록 변수를 생성
    public int id;
}
