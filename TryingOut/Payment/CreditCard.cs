namespace TryingOut.Payment;

//Method to send requests to the bank
//Method Log all the transactions

//IoC
internal class CreditCard
{
    private readonly IBankService _bankService;

    public CreditCard(IBankService bankService)
    {
        _bankService = bankService;
    }

    public void Pay(string creditCard, string cvv, double amount)
    {
        var companyAccount = "XXX-XXXX";
        _bankService.SendToTheBank(creditCard, cvv, amount, companyAccount);
    }
}

#region Bank Service
public class BankService : IBankService
{
    public void SendToTheBank(string creditCard,
        string cvv, double amount,
        object companyAccount)
    {
        //Authenticate the bank
        //Send requests
        //Handle Response
    }
}

public class QNBBankService : IBankService
{
    public void SendToTheBank(string creditCard,
        string cvv, double amount,
        object companyAccount)
    {
        //Authenticate the bank
        //Send requests
        //Handle Response
    }
}

public class AhlyBankService : IBankService
{
    public void SendToTheBank(string creditCard,
        string cvv, double amount,
        object companyAccount)
    {
        //Authenticate the bank
        //Send requests
        //Handle Response
    }
}

public interface IBankService
{
    void SendToTheBank(string creditCard, string cvv, double amount, object companyAccount);
}

#endregion
