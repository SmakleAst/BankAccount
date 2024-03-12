﻿using BankAccount.Domain.Enum;

namespace BankAccount.Domain.ViewModels
{
    public class UpdateAccountViewModel
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public DateTime OpeningDate { get; set; }
        public float Balance { get; set; }
        public AccountType AccountType { get; set; }
        public int? CreditLimit { get; set; }
        public int? ClientId { get; set; }
    }
}
