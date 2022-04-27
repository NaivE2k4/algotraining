import subsequence
import backpack
A = [1,9,2,8,3,5]
#subsequence.gis(A)
#subsequence.levenstein("колокол", "молоко")
#print(subsequence.pref_func("abcabcaainfkanpamsdfbuyabmmamfsdupnf"))
subsequence.find_substr("abcabcacbacbabcbacbacbabcabcbacbacbabcbacbacbacbabcabcabcabc","abc")

item_weights = [2,1,3]
item_values = [4,2,5]
backpack.backpack(5,item_weights, item_values)