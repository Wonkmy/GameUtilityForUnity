using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Probability : MonoBehaviour
{
    private float[] ProbabilityValue;
    Dictionary<int, string> ObjectValue = new Dictionary<int, string>();
    private void Init()
    {
        //ProbabilityValue = new float[6] { 0.05f, 0.1f, 0.1f, 0.2f, 0.25f, 0.3f };
        ProbabilityValue = new float[2] { 0.3f, 0.7f };
    }
    private void IntProbabilityValue()
    {
        ObjectValue.Add(0, "Blue");
        ObjectValue.Add(1, "Red");
        //ObjectValue.Add(2, "Yellow");
        //ObjectValue.Add(3, "Black");
        //ObjectValue.Add(4, "White");
        //ObjectValue.Add(5, "Gray");
    }
    private int Inder(float[] ProbabilityValue)
    {
        float total = 0;
        //首先计算出概率的总值，用来计算随机范围
        for (int i = 0; i < ProbabilityValue.Length; i++)
        {
            total += ProbabilityValue[i];
        }
        float Nob = Random.Range(0, total);
        for (int i = 0; i < ProbabilityValue.Length; i++)
        {
            if (Nob < ProbabilityValue[i])
            {
                return i;
            }
            else
            {
                Nob -= ProbabilityValue[i];
            }
        }
        return ProbabilityValue.Length - 1;
    }
    //初始化
    void Start()
    {
        Init();
        IntProbabilityValue();
        test();
    }
    public void CreatObj()
    {
        string name = ObjectValue[Inder(ProbabilityValue)];
        Debug.Log(name);
    }
    //这个是测试方法，测出1万次模拟产生的各种球的数量。
    private void test()
    {
        int Blue = 0;
        int Red = 0;
        //int Yellow = 0;
        //int Black = 0;
        //int White = 0;
        //int Gray = 0;
        for (int i = 0; i < 100; i++)
        {
            string name = ObjectValue[Inder(ProbabilityValue)];
            switch (name)
            {
                case "Blue":
                    Blue++;
                    break;
                case "Red":
                    Red++;
                    break;
                //case "Yellow":
                //    Yellow++;
                //    break;
                //case "Black":
                //    Black++;
                //    break;
                //case "White":
                //    White++;
                //    break;
                //case "Gray":
                //    Gray++;
                //    break;
            }
        }
        //Debug.Log("Blue:" + Blue + "Red:" + Red + "Yellow:" + Yellow + "Black" + Black + "White:" + White + "Gray:" + Gray);
        Debug.Log("Blue:" + Blue + "Red:" + Red);
    }
}
