﻿namespace BankAccount.Domain.Enum
{
    public enum StatusCode
    {
        ClientAlreadyExists = 1,
        ClientNotFound = 2,

        AccountAlreadyExists = 10,
        AccountNotFound = 11,

        LegalClientAlreadyExists = 21,
        LegalClientNotFound = 22,

        IndividualClientAlreadyExists = 21,
        IndividualClientNotFound = 22,

        Ok = 200,
        InternalServerError = 500
    }
}
