export interface Budget 
{
    budgetId: number,
    budgetUid: string,
    budgetName: string,
    frequency: TransactionFrequency,
    type: TransactionType,
    createdDate: Date,
    updatedDate: Date,
    amount: number
}

enum TransactionFrequency
{
    weekly = 0,
    biweekly = 1,
    monthly = 2,
    bimonthly = 3,
    semiannually = 4,
    annually = 5,
    none = 6
}

enum TransactionType
{
    credit = 0,
    debit = 1
}