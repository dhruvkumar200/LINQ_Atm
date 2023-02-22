using System;
public class Program
{
    public static void Main()
    {
        try
        {
            List<Costumer> emps = new List<Costumer>();
            emps.Add(new Costumer { Pin = 1, Name = "Karan", AccountNumber = 361, Balance = 30000, IsLocked = false });
            emps.Add(new Costumer { Pin = 2, Name = "Rohan", AccountNumber = 382, Balance = 35000, IsLocked = false });
            emps.Add(new Costumer { Pin = 3, Name = "Kiran", AccountNumber = 362, Balance = 40000, IsLocked = false });
            int account = Convert.ToInt32(Console.ReadLine());
            var Accountholder = (from e in emps
                                 where e.AccountNumber == account
                                 select new CostumerResult
                                 {
                                     Balance = e.Balance,
                                     Pin = e.Pin,
                                     Name = e.Name
                                 }).FirstOrDefault();
           while (Accountholder == null)
            {
                Console.WriteLine("Please Enter valid Account Number");
                 account = Convert.ToInt32(Console.ReadLine());
                 Accountholder = (from e in emps
                                 where e.AccountNumber == account
                                 select new CostumerResult
                                 {
                                     Balance = e.Balance,
                                     Pin = e.Pin,
                                     Name = e.Name,
                                     IsLocked=e.IsLocked
                                 }).FirstOrDefault();
                
            }

           
            
                Console.WriteLine("Enter your Pin");
                int password;
                
                for(int i=0;i<3;i++)
                {
                    password = Convert.ToInt32(Console.ReadLine());
                    if (Accountholder.Pin == password)
                    {
                        Console.WriteLine("Hello" + Accountholder.Name);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Try again");
                        i++;
                    }
                    if (i == 3)
                    {
                        Console.WriteLine("lock");
                        Accountholder.IsLocked=true;
                    }

                    
                }
                if(Accountholder.IsLocked==false)
                {
                    Console.WriteLine("Please enter amount");
                    decimal WithdrawAmt = Convert.ToInt32(Console.ReadLine());
                    while (WithdrawAmt > 5000)
                    {
                        Console.WriteLine("You cannot withdraw beyond limit");
                        WithdrawAmt = Convert.ToInt32(Console.ReadLine());
                    }
                    while (WithdrawAmt > Accountholder.Balance)
                    {
                        Console.WriteLine("Insufficient Balance");
                        WithdrawAmt = Convert.ToInt32(Console.ReadLine());
                    }
                    decimal remainingBalance = Accountholder.Balance - WithdrawAmt;
                    Console.WriteLine("Remaining balance = " + remainingBalance);
                    Console.WriteLine("Thanks for Using our Service");
                }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}