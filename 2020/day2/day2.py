# https://adventofcode.com/2020/day/1
# borrowed from: https://github.com/AidanGlickman/Advent-2020/day2 :)

def readTokens(line):
    tokens = line.rstrip().split(' ') # splits each line at the space character, creating 3 tokens
    first, second = map(int, tokens[0].split('-'))
    # map(function, iterable,...) applies called func (split on hyphen) to all iterables (tokens[0]) in parallel,
    # this splits the token[0] into an integer token from the first number and another token from number after the hyphen
    letter = tokens[1][0]
    password = tokens[2]
    return first, second, letter, password

def part1(line):
    min, max, letter, password = readTokens(line)
    if min <= password.count(letter) <= max:
        return 1
    return 0

def part2(line):
    first, second, letter, password = readTokens(line)
    if (password[first - 1] == letter) != (password[second - 1] == letter):
        return 1
    return 0

def main():
    count1 = 0
    count2 = 0
    with open('input.txt') as infile:
        for line in infile:
            count1 += part1(line)
            count2 += part2(line)
    print(f'Part 1: {count1}\nPart 2: {count2}')

main()


