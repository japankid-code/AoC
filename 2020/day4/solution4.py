# https://adventofcode.com/2020/day/4
# https://github.com/Akumatic/Advent-of-Code/blob/master/2020/04/code.py borrowed this code :)

import re

def readFile() -> list:
    result = list()
    with open(f"{__file__.rstrip('code.py')}input.txt", "r") as f:
        for data in f.read()[:-1].split("\n\n"): # this splits passports up, since new pp starts after 2 \n
            result.append(dict(d.split(":") for d in data.replace("\n", " ").split()))
            # this adds new dictionary entries for each passport,
            # removes all new lines inside each pp, 
        return result

def assert_fields(data: dict) -> bool:
    # this parses the dictionary
    return all((k in data for k in ("byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid")))
    
def part1(vals: list) -> int:
    return len(vals)
    
def part2(vals: list) -> int:
    patterns = {
        "byr": "19[2-9][0-9]|200[0-2]",
        "iyr": "20(1[0-9]|20)",
        "eyr": "20(2[0-9]|30)",
        "hgt": "1([5-8][0-9]|9[0-3])cm|(59|6[0-9]|7[0-6])in",
        "hcl": "#[0-9a-f]{6}",
        "ecl": "amb|blu|brn|gry|grn|hzl|oth",
        "pid": "[0-9]{9}",
        "cid": ".*"
    }
    return sum((all((re.fullmatch(patterns[v], val[v]) for v in val)) for val in vals))

if __name__ == "__main__":
    vals = readFile()
    valid_passes = [val for val in vals if assert_fields(val)]
    print(f"Part 1: {part1(valid_passes)}\nPart 2: {part2(valid_passes)}")