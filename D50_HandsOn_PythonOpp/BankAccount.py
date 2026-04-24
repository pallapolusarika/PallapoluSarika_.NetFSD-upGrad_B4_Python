#Bank Account System

class BankAccount:
    def __init__(self, balance=0):
        self.balance = balance

    def deposit(self, amt):
        self.balance += amt

    def withdraw(self, amt):
        if amt <= self.balance:
            self.balance -= amt

    def check_balance(self):
        return self.balance

a = BankAccount(10000)
a.deposit(500)
a.withdraw(2000)
print(a.check_balance())