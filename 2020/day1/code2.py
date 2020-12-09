# https://adventofcode.com/2020/day/1
# borrowed from: idk can find the link now (:

from itertools import permutations

with open("input.txt") as f:
    numbers = [int(x) for x in f.read().split()]
target_number = 2020

solutions2 = [pair for pair in permutations(numbers, 2) if sum(pair) == 2020]
print('Pair Solutions:', solutions2)

for pair in permutations(numbers, 2):
    if sum(pair) == 2020:
        print('Pair Multiplification Result:', pair[0] * pair[1])
        break

solutions3 = [pair for pair in permutations(numbers, 3) if sum(pair) == 2020]
print('Thruple Solutions:', solutions3)

with open("input.txt") as f:
    numbers = [int(x) for x in f.read().split()]
target_number = 2020


for thruple in permutations(numbers, 3):
  if sum(thruple) == 2020:
    print('Thruple Multiplification Result:', thruple[0] * thruple[1] * thruple[2])
    break