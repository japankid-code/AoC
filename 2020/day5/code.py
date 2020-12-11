# https://adventofcode.com/2020/day/5
# borrowed from https://github.com/Akumatic/Advent-of-Code/blob/master/2020/05/code.py :)
# just typing out and leaving notes 

def readFile() -> list:
    with open(f"{__file__.rstrip('code.py')}input.txt", "r") as f:
        return [int(line[:-1].replace("F", "0").replace("B", "1").replace("L", "0").replace("R", "1"), 2) for line in f.readlines()]
        # this converts the passenger string into binary code, 

def part1(seat_ids: list) -> int:
    # this looks through the list, finds the highest boarding pass no. for part 1, returning an integer
    return max(seat_ids)

def part2(seat_ids: list) -> int:
    for i in range(min(seat_ids), max(seat_ids)):
        if i not in seat_ids and (i - 1) in seat_ids and (i + 1) in seat_ids:
            return i
            # this finds the missing id from the list, after all 
            # "Your seat wasn't at the very front or back, though; 
            # the seats with IDs +1 and -1 from yours will be in your list."

if __name__ == "__main__":
    seat_ids = readFile()
    print(f"Part 1 : {part1(seat_ids)}\nPart 2 : {part2(seat_ids)}")