# def f(v, i, S, memo):
#   if i >= len(v): return 1 if S == 0 else 0
#   if (i, S) not in memo:  # <-- Check if value has not been calculated.
#     count = f(v, i + 1, S, memo)
#     count += f(v, i + 1, S - v[i], memo)
#     memo[(i, S)] = count  # <-- Memoize calculated result.
#   return memo[(i, S)]     # <-- Return memoized value.

# def g(v, S, memo):
#   subset = []
#   for i, x in enumerate(v):
#     # Check if there is still a solution if we include v[i]
#     if f(v, i + 1, S - x, memo) > 0:
#       subset.append(x)
#       S -= x
#   return subset

# v = [408, 1614, 1321, 1028, 1018, 2008, 1061, 1433, 1434, 1383, 1645, 1841, 1594, 1218, 1729, 1908, 1237, 1152, 1771, 1837, 1709, 1449, 1876, 1763, 1676, 1491, 1983, 1743, 1845, 999, 1478, 1929, 1819, 1385, 1308, 1703, 1246, 1831, 1964, 1469, 1977, 1488, 1698, 1640, 1513, 1136, 1794, 1685, 1802, 1520,1807, 1654, 1547, 1917, 1792, 1949, 1268, 1626, 1493, 1534, 1700, 1844, 1146, 1049, 1811, 1627,1630, 1755, 1887, 1290, 1446, 1968, 168, 1749, 1479, 1651, 1646, 1839, 14, 1918, 1568, 1554, 1926, 1942, 1862, 1966, 1536, 1599, 1439, 1766,1643, 1045, 1537, 1786, 1596, 1954, 1390, 1981, 1362, 1292, 1573, 1541, 1515, 1567, 1860, 1066, 1879, 1800, 1309, 1533, 1812, 1774, 1119, 1602, 1677, 482, 1054, 1424, 1631, 1829, 1550, 1636, 1604, 185, 1642, 1304, 1843, 1773, 1667, 1530, 1047, 1584, 1958, 1160, 1570, 1705, 1582, 1692, 1886, 1673, 1842, 1402, 1517, 1805, 1386, 1165, 1867, 1153, 1467, 1473, 1803, 1967, 1485, 1448, 1922, 1258, 1590, 1996, 1208, 1241,1412, 1610, 1219, 523, 1813, 1123, 1916, 1861, 1020, 1783, 1052, 1140, 1994, 1761, 747, 1885, 1675, 1957, 1476, 1382, 1878, 1099, 1882, 855, 1905, 1037]
# sum = 2020
# memo = dict()
# if f(v, 0, sum, memo) == 0: print("There are no valid subsets.")
# else: print(g(v, sum, memo))
#                  above code returns the 3 numbers that add to 2020!!

numbers = [408, 1614, 1321, 1028, 1018, 2008, 1061, 1433, 1434, 1383, 1645, 1841, 1594, 1218, 1729, 1908, 1237, 1152, 1771, 1837, 1709, 1449, 1876, 1763, 1676, 1491, 1983, 1743, 1845, 999, 1478, 1929, 1819, 1385, 1308, 1703, 1246, 1831, 1964, 1469, 1977, 1488, 1698, 1640, 1513, 1136, 1794, 1685, 1802, 1520, 1807, 1654, 1547, 1917, 1792, 1949, 1268, 1626, 1493, 1534, 1700, 1844, 1146, 1049, 1811, 1627, 1630, 1755, 1887, 1290, 1446, 1968, 168, 1749, 1479, 1651, 1646, 1839, 14, 1918, 1568, 1554, 1926, 1942, 1862, 1966, 1536, 1599, 1439, 1766, 1643, 1045, 1537, 1786, 1596, 1954, 1390, 1981, 1362, 1292, 1573, 1541, 1515, 1567, 1860, 1066, 1879, 1800, 1309, 1533, 1812, 1774, 1119, 1602, 1677, 482, 1054, 1424, 1631, 1829, 1550, 1636, 1604, 185, 1642, 1304, 1843, 1773, 1667, 1530, 1047, 1584, 1958, 1160, 1570, 1705, 1582, 1692, 1886, 1673, 1842, 1402, 1517, 1805, 1386, 1165, 1867, 1153, 1467, 1473, 1803, 1967, 1485, 1448, 1922, 1258, 1590, 1996, 1208, 1241, 1412, 1610, 1219, 523, 1813, 1123, 1916, 1861, 1020, 1783, 1052, 1140, 1994, 1761, 747, 1885, 1675, 1957, 1476, 1382, 1878, 1099, 1882, 855, 1905, 1037, 1714, 1988, 1648, 1135, 1859 ,1798, 1333, 1158, 1909, 652, 1934, 1830, 1442, 1224]
target_number = 2020

for i, number in enumerate(numbers[:-1]):  # You do not have to check the last number; 
                                           #if there was a pair you would have already found it by then.
    complementary = target_number - number
    if complementary in numbers[i+1:]:  # Notice that the membership check (which is quite costly in lists) 
                                        # is optimized since it considers the slice numbers[i+1:] only. The
                                        #  previous numbers have been checked already. A positive side-effect
                                        #  of the slicing is that the existence of one 4 in the list, does not
                                        #  give a pair for a target value of 8.
        print("Solution Found: {} and {}".format(number, complementary))
        break
else:  # The else triggers only if the loop was not abruptly ended by a break.
    print("No solutions exist")


from itertools import permutations

with open("input.txt") as f:
    numbers = [int(x) for x in f.read().split()]
target_number = 2020

solutions = [pair for pair in permutations(numbers, 2) if sum(pair) == 2020]
print('Pair Solutions:', solutions)

solutions = [pair for pair in permutations(numbers, 3) if sum(numbers, 3) == 2020]
print('Thruple Solutions:', solutions)

