import subsequence
import backpack
A = [1,9,2,8,3,5]
#subsequence.gis(A)
#subsequence.levenstein("колокол", "молоко")
#print(subsequence.pref_func("abcabcaainfkanpamsdfbuyabmmamfsdupnf"))
#subsequence.find_substr("abcabcacbacbabcbacbacbabcabcbacbacbabcbacbacbacbabcabcabcabc","abc")

#item_weights = [2,1,3]
#item_values = [4,2,5]
#res = backpack.backpack(4,item_weights, item_values)
#print(backpack.get_chosen_items(res, item_weights, 4))

print("Эта программа показывает практическое применение для дискретной задачи о рюкзаке")
print("Предположим, N программистам надо лететь на легком самолете в Сербию. Все не влезут в самолет. При этом все знают, что лучшие программисты - бэкендщики!")
mmax = int(input("Введите максимальную суммарную жирность программистов, которую может утащить самолетик: "))
N = int(input("Введите количество программистов: "))
item_weights = [0]*N
item_values = [0]*N
names = {}
for i in range(N):
    (name, weight, value) = input("Введите данные о программисте "+ str(i) + " в формате 'имя жирность знание_бэка': ").split()
    item_weights[i] = int(weight)
    item_values[i] = int(value)
    names[i] = name
res = backpack.backpack(mmax, item_weights, item_values)
chosen = backpack.get_chosen_items(res, item_weights, mmax)
print(". . .")
print("Итак, великий Алгоритм провел вычисления и вынес вердикт!")
print("На самолете полетят: ")
for item in chosen:
    print(names[item])