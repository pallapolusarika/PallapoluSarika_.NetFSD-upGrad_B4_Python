def analyze_marks(file_name):
    total_marks = 0
    student_count = 0
    topper_name = ""
    highest_marks = 0
    with open(file_name, "r") as file:
        for line in file:
            name, marks = line.strip().split(",")
            marks = int(marks)
            total_marks += marks
            student_count += 1
            if marks > highest_marks:
                highest_marks = marks
                topper_name = name
    average_marks = total_marks / student_count
    print("Topper:", topper_name)
    print("Average:", round(average_marks, 1))
analyze_marks("students.csv")