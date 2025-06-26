using Microservices.SharedKernel.Domain.Entities;

namespace Microservices.Demo.Products.Service.Domain.Products.Entities;

public class Question: Entity<Guid>
{
    public Question()
    {
    }

    protected Question(string code, int index, string text)
    {
        Id = Guid.NewGuid();
        Code = code;
        Index = index;
        Text = text;
    }

    //public Guid Id { get; protected set; }
    public string Code { get; protected set; }
    public int Index { get; protected set; }
    public string Text { get; protected set; }

    public Product Product { get; protected set; }
}



