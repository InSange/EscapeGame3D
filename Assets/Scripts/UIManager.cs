using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /* // �̱��� // * instance��� ������ static���� ������ �Ͽ� �ٸ� ������Ʈ ���� ��ũ��Ʈ������ instance�� �ҷ��� �� �ְ� �մϴ� */
    public static UIManager UIcanvas = null; 
    private void Awake()
    {
        if (UIcanvas == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������ 
        {
            UIcanvas = this; //���ڽ��� instance�� �־��ݴϴ�. 
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ���� 
        } 
        else 
        { 
            if (UIcanvas != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ� 
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ���� 
        } 
    }

}