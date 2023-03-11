

using TryingOut.Payment;

IBankService s = new AhlyBankService();

var creditCardManager = new CreditCard(s);

creditCardManager.Pay("", "", 10);