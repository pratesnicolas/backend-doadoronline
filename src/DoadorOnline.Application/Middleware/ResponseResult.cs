namespace DoadorOnline.Application;

public class ResponseResult
{
    public string Title { get; set; }
    public int Status { get; set; }
    public ResponseErrorMessages Errors { get; set; } = new();
}

public class ResponseErrorMessages
{
    public ResponseErrorMessages()
    {
    }

    public ResponseErrorMessages(params string[] erros)
    {
        foreach (var erro in erros)
            foreach (var item in erro.Split(Environment.NewLine))
                this.Messages.Add(item);
    }

    public List<string> Messages { get; set; } = new List<string>();
}
