
[System.Serializable]
public class Question
{
    public string question, qAnswer;

    public Question(string name, string answer)
    {
        this.question = name;
        this.qAnswer = answer;
    }
}
