def readFile() -> list:
    with open(f"{__file__.rstrip('code.py')}input.txt", "r") as f:
        return [line.split() for line in f.read().strip().split("\n\n")]
    
def count(groups: list, everyone: bool) -> int:
    result = 0
    for group in groups:
        answers = {chr(c):0 for c in range(97, 123)}

        for answer in group:
            for letter in answer:
                answers[letter] += 1
        
        if everyone:
            result += sum([1 for letter in answers[letter] == len(group)])
            