def reverse_string(text):
    reversed_text = ""
    for ch in text:
        reversed_text = ch + reversed_text   # build reverse
    return reversed_text
print("Reversed:", reverse_string("python"))