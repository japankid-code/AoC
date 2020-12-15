# https://adventofcode.com/2020/day/6
# borrowed from https://github.com/Akumatic/Advent-of-Code/blob/master/2020/06/code.py :)
# just typing out and leaving notes


def readFile() -> list:
    with open(f"{__file__.rstrip('code.py')}input.txt", "r") as f:
        return [line.split() for line in f.read().strip().split("\n\n")]
        # ok so this splits up the input into groups,
        # Each group's answers are separated by a blank line, 
        # and within each group, each person's answers are on a single line.
    
def count(groups: list, everyone: bool) -> int:
    result = 0
    for group in groups:
        answers = {chr(c):0 for c in range(97, 123)} # the range here is used to indicate the alphabet, not integers
        # list(map(chr, range(97, 123))) returns a list with the alphabet.

        for answer in group:
            for letter in answer:
                answers[letter] += 1
        # 

        if everyone:
            result += sum([1 for letter in answers if answers[letter] == len(group)])
        else:
            result += sum([1 for letter in answers if answers[letter]])

    return result

def part1(groups: list) -> int:
    return count(groups, False)

def part2(seat_ids: list) -> int:
    return count(groups, True)

if __name__ == "__main__":
    groups = readFile()
    print(f"Part 1: {part1(groups)}\nPart 2: {part2(groups)}")