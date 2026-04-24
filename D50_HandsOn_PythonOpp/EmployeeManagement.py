#: Employee Management System using Inheritance

class Employee:
    def __init__(self, name, salary):
        self.name = name
        self.salary = salary

    def display(self):
        print(self.name, self.salary)


class Manager(Employee):
    def __init__(self, name, salary, department, bonus):
        super().__init__(name, salary)
        self.department = department
        self.bonus = bonus

    def total_salary(self):
        return self.salary + self.bonus

m = Manager("Ravi", 50000, "IT", 10000)
m.display()
print(m.department)
print(m.total_salary())