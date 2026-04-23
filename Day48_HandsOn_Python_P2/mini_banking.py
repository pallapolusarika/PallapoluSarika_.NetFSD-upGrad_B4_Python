def deposit(balance, amount):
    if amount <= 0:
        print("Invalid deposit amount!")
        return balance
    return balance + amount
def withdraw(balance, amount):
    if amount <= 0:
        print("Invalid withdrawal amount!")
        return balance

    if amount > balance:
        print("Insufficient balance")
        return balance

    return balance - amount
def check_balance(balance):
    print("Current Balance:", balance)
name = input("Enter your name: ")
balance = float(input("Enter initial balance: "))
print("\nWelcome,", name)

while True:
    print("\n1. Deposit")
    print("2. Withdraw")
    print("3. Check Balance")
    print("4. Exit")

    choice = input("Choose option: ")

    if choice == "1":
        amount = float(input("Enter deposit amount: "))
        balance = deposit(balance, amount)
        print("Balance updated:", balance)

    elif choice == "2":
        amount = float(input("Enter withdrawal amount: "))
        balance = withdraw(balance, amount)

    elif choice == "3":
        check_balance(balance)

    elif choice == "4":
        print("Thank you! Exiting...")
        break

    else:
        print("Invalid option. Try again.")