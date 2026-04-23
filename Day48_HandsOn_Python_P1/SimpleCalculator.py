def calculator(a, b, op):
    result = None

    if op == '+':
        result = a + b
    elif op == '-':
        result = a - b
    elif op == '*':
        result = a * b
    elif op == '/':
        if b == 0:
            return "Error: Division by zero"
        result = a / b
    else:
        return "Invalid operator"

    return result


# Example
print("Calculator Output:", calculator(10, 5, '+'))