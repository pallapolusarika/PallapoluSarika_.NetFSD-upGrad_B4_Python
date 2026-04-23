def find_largest(a, b, c):
    if a >= b and a >= c:
        return a
    elif b >= a and b >= c:
        return b
    else:
        return c
x = 10
y = 45
z = 22

print("Largest Number:", find_largest(x, y, z))