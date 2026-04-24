#: Create Student Class

class Student:
    def __init__(self, name, age):
        self.name = name
        self.age = age
    def show_details(self):
        print("Name:", self.name)
        print("Age:", self.age)
s1 = Student("Sarika", 22)
s1.show_details()
