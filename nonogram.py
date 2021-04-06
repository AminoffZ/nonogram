import random

size = 4

gridDict = {"X": [], "Y": []}
numberList = {"X": [], "Y": []}

def AddXList():
    xDict = []
    for i in range(size):
        xList = []
        for i in range(size):
            xList.append(random.choice([True, False]))
        xDict.append(xList)
        
    gridDict["X"] = xDict

def AddYList():
    yDict = []
    count = 0
    for xList in gridDict["X"]:
        yList = []
        for xList in gridDict["X"]:
            yList.append(xList[count])
        count += 1    
        yDict.append(yList)
    gridDict["Y"] = yDict

def CreateNumberList(gridList):
    numberList = []
    count = 0
    for i in gridList:
        if i:
            count += 1
        
        elif count > 0:
            numberList.append(count)
            count = 0
    
    if count > 0:
        numberList.append(count)

    # If list is empty
    if not numberList:
        numberList.append(0)
    
    return numberList

def AddClueList():
    for key in gridDict:
        for gridList in gridDict[key]:
            numberList[key].append(CreateNumberList(gridList))

AddXList()
AddYList()
AddClueList()

gridDict
numberList



