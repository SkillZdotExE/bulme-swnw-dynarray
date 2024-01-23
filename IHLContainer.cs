
using System;
using System.Collections;

interface IHLContainer
{
int Count();
object First(); // Nachbearbeiten
object Next();
    
void AddHead(object aObj);
object RemoveHead();
void AddTail(object aObj);
object RemoveTail();

object At(int aPos);
object Find(object aTestObject, IComparer aCmp);
object Remove(object aObj);
object RemoveAt(int aIdx); // Nachbearbeiten
    
void InsertSorted(object aObj, IComparer aCmp);
void InsertAtPos(object aObj, int aPos);
void Print();
}