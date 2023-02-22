public class Costumer
{
     public decimal Balance{get;set;}
    public string Name {get;set;}
    public int Pin{get;set;}
    public int AccountNumber{get;set;}
    public bool IsLocked{get;set;}
}
public class CostumerResult
{
    public int Pin{get;set;}
    public string Name {get;set;}
    public decimal Balance{get;set;}
    public bool IsLocked{get;set;}
}